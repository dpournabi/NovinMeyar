using System;
using Serilog;
using System.IO;
using MassTransit;
using System.Linq;
using Newtonsoft.Json;
using System.Threading;
using NovinMeyar.Common;
using System.Threading.Tasks;
using NovinMeyar.Common.Mimes;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Technical.DataLayer;
using NovinMeyar.Technical.Api.Models;
using NovinMeyar.Technical.Domain.DTO;
using NovinMeyar.Technical.Api.Helper;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.Technical.Domain.Views;
using Microsoft.Extensions.Configuration;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Technical.Domain.Contracts;

namespace NovinMeyar.Technical.Api.Services.ver_1._0.Implementation
{
    public class FastRegisrationRequestService : IFastRegisrationRequestService
    {
        private readonly DataContext dataContext;
        private readonly ILogger logger;
        private readonly IRequestClient<RequestRegistrationBroker> registrationBrokerClient;
        private readonly IRequestClient<UpdateRequestBroker> UpdateRequestBrokerClient;
        private readonly IRequestClient<GetPaymentTokenBroker> paymentTokenBrokerClient;
        private readonly IElevatorInspectionService elevatorInspectionService;
        private readonly IInstallatinCompanyService installatinCompanyService;
        private readonly IPaymentCalculator paymentCalculator;

        private readonly IConfiguration configuration;
        public FastRegisrationRequestService(DataContext dataContext,
            IRequestClient<RequestRegistrationBroker> registrationBrokerClient,
            IRequestClient<UpdateRequestBroker> UpdateRequestBrokerClient,
            IRequestClient<GetPaymentTokenBroker> paymentTokenBrokerClient,
            ILogger logger,
            IElevatorInspectionService elevatorInspectionService,
            IInstallatinCompanyService installatinCompanyService,
            IConfiguration configuration,
            IPaymentCalculator paymentCalculator)
        {
            this.dataContext = dataContext;
            this.logger = logger;
            this.registrationBrokerClient = registrationBrokerClient;
            this.paymentTokenBrokerClient = paymentTokenBrokerClient;
            this.elevatorInspectionService = elevatorInspectionService;
            this.installatinCompanyService = installatinCompanyService;
            this.configuration = configuration;
            this.paymentCalculator = paymentCalculator;
            this.UpdateRequestBrokerClient = UpdateRequestBrokerClient;
        }

        public async Task<ResponseModel<VMFastRegistration>> SearchAsync(FastRegistrationSearch search, long branchId, bool currentRoleIsAdmin, string currentUserRole, string userName)
        {
            var validation = await OnValidateSearchParams(search);
            if (!validation.Succeed)
                return validation;

            var query = dataContext.VMFastRegistrations.Where(x => !x.Deleted).AsQueryable();

            if (currentUserRole == AssessorsManager.Client)
                query = query.Where(x => x.UserCreatorName == userName);

            if (!currentRoleIsAdmin && branchId > 0)
                query = query.Where(x => x.BranchId == branchId);

            if (search.Id != null)
            {
                long _id = 0;
                long.TryParse(search.Id, out _id);
                if (_id <= 0)
                    _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(search.Id)));
                query = query.Where(x => x.Id == _id);
            }

            if (!string.IsNullOrWhiteSpace(search.BuildingCertificateNo))
                query = query.Where(x => x.BuildingCertificateNo.Contains(search.BuildingCertificateNo));

            if (!string.IsNullOrWhiteSpace(search.DocumentNumber))
                query = query.Where(x => x.DocumentNumber.Contains(search.DocumentNumber));

            if (!string.IsNullOrWhiteSpace(search.ResponsibleFullName))
                query = query.Where(x => x.ResponsibleFullName.Contains(search.ResponsibleFullName));

            if (search.InstallatinCompanyId.HasValue)
                query = query.Where(x => x.InstallatinCompanyId == search.InstallatinCompanyId);

            if (search.FromCreateDate.HasValue)
                query = query.Where(x => x.CreateDate >= search.FromCreateDate);

            if (search.ToCreateDate.HasValue)
                query = query.Where(x => x.CreateDate >= search.ToCreateDate);

            var totalCount = await query.AsNoTracking().CountAsync();
            var data = await query.AsNoTracking().OrderBy(x => x.DocumentNumber).ThenByDescending(x => x.CreateDate)
                                .Skip((search.PageIndex - 1) * search.PageSize)
                                .Take(search.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<VMFastRegistration>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel> GetDisplayInvoiceAsync(Guid tag) => await GetInvoiceInformation(tag);
        public async Task<ResponseModel> PrepareToPayAsync(Guid tag, string userName, CancellationToken cancellationToken)
        {
            var invoice = await GetInvoiceInformation(tag);
            if (invoice == null)
                return new ResponseModel { Succeed = false, Message = "Record not found" };
            var data = (dynamic)invoice.Data;
            var amount = decimal.Parse(((string)data.TotalPayment).Replace(",", ""));
            var input = new GetPaymentTokenBroker
            {
                Amount = amount,
                InvoiceNumber = data.InvoiceNumber,
                CreatorUserName = userName,
                CreateDate = DateTime.Now,
                SourceTable = data.SourceTable,
                SourceKey = data.SourceKey.ToString(),
                Tag = data.DocumentNumber,
                DataFlag = Common.Security.Helper.EncryptString(amount.ToString())
            };
            var response = await paymentTokenBrokerClient.GetResponse<ResponseModel>(input, cancellationToken, int.MaxValue);
            return response.Message;
        }
        public async Task<ResponseModel> SaveAsync(FastRegistrationModel model, string userName, long branchId, string branchCode, string branchName, string currentRoleName, bool currentRoleIsAdmin)
        {
            var validation = await OnValidateModel(model);
            if (!validation.Succeed)
                return validation;

            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };
            long _branchId = branchId;
            if (_branchId <= 0 && model.BranchId.HasValue)
                _branchId = model.BranchId.Value;
            var installationCompany = await dataContext.InstallatinCompanies.FindAsync(model.InstallatinCompanyId);
            var executionStrategy = dataContext.Database.CreateExecutionStrategy();

            return await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await dataContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        ElevatorInformation elevatorInfo = await dataContext.ElevatorInformations.FirstOrDefaultAsync(x => x.Id == model.Id);
                        var latestElevatorInfo = await dataContext.ElevatorInformations.Where(x => !string.IsNullOrEmpty(x.DocumentNumber) && x.DocumentNumber != "8000").OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                        if (elevatorInfo is null)
                        {
                            elevatorInfo = new ElevatorInformation
                            {
                                BranchId = _branchId,
                                InspectionTypeId = model.InspectionTypeId.Value,
                                ProvinceId = model.ProvinceId.Value,
                                CityId = model.CityId.Value,
                                Address = model.Address,
                                InstallatinCompanyId = model.InstallatinCompanyId.Value,
                                LatestCertificateTypeId = model.LatestCertificateTypeId.HasValue ? model.LatestCertificateTypeId.Value : null,
                                CustomerId = model.CustomerId.Value,
                                CustomerType = model.CustomerType,
                                IsActive = true,
                                ISIRINo = model.ISIRINo,
                                ResponsibleCell = model.ResponsibleCell,
                                ResponsibleFullName = model.ResponsibleFullName,
                                BuildingPleque = model.BuildingPleque,
                                BuildingAreaNo = model.BuildingAreaNo,
                                BuildingCertificateNo = model.BuildingCertificateNo,
                                BuildingIssueDate = model.BuildingIssueDate.Value,
                                CreateDate = DateTime.Now,
                                UserCreatorName = userName ?? "",
                                Deleted = false,
                                ElevatorTypeId = model.ElevatorTypeId.Value,
                                ElevatorNationalNo = model.ElevatorNationalNo,
                                ScanDocumentId = model.ScanDocumentId,
                                ProjectDocumentId = model.ProjectDocumentId,
                                CertificateId = model.CertificateId,
                                BuildingCertificateImageId = model.BuildingCertificateImageId,
                                IsiriRequestImageId = model.IsiriRequestImageId,
                                StopCount = model.StopCount.HasValue ? model.StopCount.Value : 0,
                                CreatorRoleName = currentRoleName
                            };

                            await dataContext.AddAsync(elevatorInfo);
                            await dataContext.SaveChangesAsync();

                            if (currentRoleName != AssessorsManager.Client)
                            {
                            RetryPoint:
                                var generatedDocnumber = DocumentPartNumber.GenerateDocumentNumber(branchCode, elevatorInfo, latestElevatorInfo?.DocumentNumber);
                                if (dataContext.ElevatorInformations.Any(x => x.DocumentNumber.Contains(generatedDocnumber)))
                                    goto RetryPoint;

                                elevatorInfo.DocumentNumber = generatedDocnumber;
                                await dataContext.SaveChangesAsync();

                            }
                            else
                            {
                                elevatorInfo.DocumentNumber = "";
                                await dataContext.SaveChangesAsync();
                            }

                            //publishing new message for create a new request in cartabl microservice.
                            var res = await registrationBrokerClient.GetResponse<ResponseModel>(new RequestRegistrationBroker
                            {
                                BranchId = _branchId,
                                SourceTableKey = elevatorInfo.Id,
                                RequestTitle = !string.IsNullOrEmpty(elevatorInfo.DocumentNumber) ? elevatorInfo.DocumentNumber : "",
                                RequestTypeId = model.RequestTypeId,
                                SystemName = SystemNames.Technical.GetDescription(),
                                UserName = userName ?? "",
                                RequestId = null,
                                BranchName = branchName,
                                CustomerFullName = model.ResponsibleFullName,
                                InstallationCompanyName = installationCompany.Name,
                                InstallationCompanyId = installationCompany.Id,
                                Url = $"fast-reg?id={elevatorInfo.Id.ToString()}"
                            });

                            if (!res.Message.Succeed)
                                throw new Exception(res.Message.Message);
                        }
                        else
                        {
                            elevatorInfo.InspectionTypeId = model.InspectionTypeId.Value;
                            elevatorInfo.ProvinceId = model.ProvinceId.Value;
                            elevatorInfo.CityId = model.CityId.Value;
                            elevatorInfo.Address = model.Address;
                            elevatorInfo.InstallatinCompanyId = model.InstallatinCompanyId.Value;
                            elevatorInfo.LatestCertificateTypeId = model.LatestCertificateTypeId.HasValue ? model.LatestCertificateTypeId.Value : null;
                            elevatorInfo.CustomerId = model.CustomerId.Value;
                            elevatorInfo.CustomerType = model.CustomerType;
                            elevatorInfo.IsActive = true;
                            elevatorInfo.ISIRINo = model.ISIRINo;
                            elevatorInfo.ResponsibleCell = model.ResponsibleCell;
                            elevatorInfo.ResponsibleFullName = model.ResponsibleFullName;
                            elevatorInfo.BuildingPleque = model.BuildingPleque;
                            elevatorInfo.BuildingAreaNo = model.BuildingAreaNo;
                            elevatorInfo.BuildingCertificateNo = model.BuildingCertificateNo;
                            elevatorInfo.BuildingIssueDate = model.BuildingIssueDate.Value;
                            elevatorInfo.UserModifiedDate = DateTime.Now;
                            elevatorInfo.UserCreatorName = userName ?? "";
                            elevatorInfo.Deleted = false;
                            elevatorInfo.ElevatorTypeId = model.ElevatorTypeId.Value;
                            elevatorInfo.ElevatorNationalNo = model.ElevatorNationalNo;
                            elevatorInfo.ScanDocumentId = model.ScanDocumentId;
                            elevatorInfo.ProjectDocumentId = model.ProjectDocumentId;
                            elevatorInfo.CertificateId = model.CertificateId;
                            elevatorInfo.StopCount = model.StopCount.HasValue ? model.StopCount.Value : 0;
                            elevatorInfo.BuildingCertificateImageId = model.BuildingCertificateImageId;
                            elevatorInfo.IsiriRequestImageId = model.IsiriRequestImageId;

                            if (elevatorInfo.ElevatorTypeId != model.ElevatorTypeId ||
                                elevatorInfo.InspectionTypeId != model.InspectionTypeId)
                            {
                                elevatorInfo.DocumentNumber = DocumentPartNumber.UpdateDocumentNumber(elevatorInfo);
                            }

                            if (currentRoleName != AssessorsManager.Client)
                            {
                                if (string.IsNullOrWhiteSpace(elevatorInfo.DocumentNumber) && branchId > 0)//چون کد شعبه برای ادمین خالی می باشد
                                {
                                RetryPoint:
                                    var generatedDocnumber = DocumentPartNumber.GenerateDocumentNumber(branchCode, elevatorInfo, latestElevatorInfo?.DocumentNumber);
                                    if (dataContext.ElevatorInformations.Any(x => x.DocumentNumber.Contains(generatedDocnumber)))
                                        goto RetryPoint;

                                    elevatorInfo.DocumentNumber = generatedDocnumber;
                                    await dataContext.SaveChangesAsync();
                                }

                                if (model.InspectionDate != null)
                                {
                                    var elevatorInspection = await dataContext.ElevatorInspections
                                                                    .Where(x => !x.Deleted && x.ElevatorInformationId == elevatorInfo.Id && x.PaymentId == null)
                                                                    .OrderByDescending(x => x.CreateDate)
                                                                    .FirstOrDefaultAsync();
                                    if (elevatorInspection != null)
                                    {
                                        elevatorInspection.InspectionDate = model.InspectionDate;
                                        await dataContext.SaveChangesAsync();
                                    }
                                }
                                //publishing new message for update request in cartabl microservice.
                                var res = await UpdateRequestBrokerClient.GetResponse<ResponseModel>(new UpdateRequestBroker
                                {
                                    SourceTableKey = elevatorInfo.Id,
                                    DocumentNumber = elevatorInfo.DocumentNumber,
                                    BranchName = model.BranchName
                                });

                                if (!res.Message.Succeed)
                                    throw new Exception(res.Message.Message);
                            }
                        }

                        await dataContext.SaveChangesAsync();

                        //Commit all changes
                        await transaction.CommitAsync();

                        response.Message = "عملیات ثبت با موفقیت انجام شد";
                        response.Succeed = true;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.ExteraInformation = elevatorInfo.Id.ToString();
                        return response;

                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        logger.Error($"{DateTime.Now} - {nameof(FastRegisrationRequestService)} --> {nameof(SaveAsync)} --> Error deatail: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                        response.Message = $"در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود. ErrorDetails: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}";
                        response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                    }
                    return response;
                }
            });
        }
        public async Task<ResponseModel> UpdateTechnicalInformationAsync(TechnicalInformationModel model, string userName)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            if (model == null)
            {
                response.Message = "مدل ارسالی صحیح نمی باشد";
                return response;
            }

            ElevatorInformation elevatorInfo = await dataContext.ElevatorInformations.FirstOrDefaultAsync(x => x.Id == model.ElevatorInformationId);

            try
            {
                if (elevatorInfo == null)
                {
                    response.Message = "پرونده مورد نظر یافت نشد";
                    return response;
                }

                elevatorInfo.TechnicalInformation = JsonConvert.SerializeObject(model);
                elevatorInfo.UserModifiedName = userName;
                elevatorInfo.UserModifiedDate = DateTime.Now;
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات ثبت با موفقیت انجام شد";
                response.Succeed = true;
                return response;
            }
            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} - {nameof(FastRegisrationRequestService)} --> {nameof(UpdateTechnicalInformationAsync)} --> Error deatail: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}");
                response.Message = $"در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود. ErrorDetails: {(ex.InnerException != null ? ex.InnerException.Message : ex.Message)}";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<ResponseModel> DeactiveAsync(long id, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (id <= 0)
                    return response;

                var obj = await dataContext.ElevatorInformations.FindAsync(id);

                obj.Deleted = true;
                obj.UserModifiedName = userName ?? "";
                obj.UserModifiedDate = DateTime.Now;
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف پرونده با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(FastRegisrationRequestService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel> LockRequest(long Id, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.UnprocessableEntity };

            try
            {
                if (Id <= 0)
                    return response;

                var obj = await dataContext.ElevatorInformations.FindAsync(Id);

                obj.IsLock = true;
                obj.UserModifiedName = userName ?? "";
                obj.UserModifiedDate = DateTime.Now;
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات قفل پرونده با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(FastRegisrationRequestService)} --> {nameof(LockRequest)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel<string>> GetDocumentCategoriesAsync(string currentRole)
        {
            string currentPath = string.Empty;
            if(currentRole== AssessorsManager.Client)
                currentPath = $@"{System.IO.Directory.GetCurrentDirectory()}\Documents\Client";
            else if (currentRole == AssessorsManager.Administrator || currentRole == AssessorsManager.Root)
                currentPath = $@"{System.IO.Directory.GetCurrentDirectory()}\Documents\Admin";
            else
                currentPath = $@"{System.IO.Directory.GetCurrentDirectory()}\Documents\Employee";

            var directories = System.IO.Directory.GetDirectories(currentPath).Select(x=> new DirectoryInfo(x).Name).ToList();

            return await Task.FromResult(new ResponseModel<string>
            {
                Succeed = true,
                ResponseList = directories
            });
        }
        public async Task<ResponseModel<string>> GetDocumentsAsync(string currentRole, string folderName)
        {
            string currentPath = string.Empty;
            if (currentRole == AssessorsManager.Client)
                currentPath = $@"{Directory.GetCurrentDirectory()}\Documents\Client\{folderName}";
            else if (currentRole == AssessorsManager.Administrator || currentRole == AssessorsManager.Root)
                currentPath = $@"{System.IO.Directory.GetCurrentDirectory()}\Documents\Admin\{folderName}";
            else
                currentPath = $@"{Directory.GetCurrentDirectory()}\Documents\Employee\{folderName}";

            var files = Directory.GetFiles(currentPath).Select(x=> Path.GetFileName(x)).ToList();

            return await Task.FromResult(new ResponseModel<string>
            {
                Succeed = true,
                ResponseList = files
            });
        }
        public async Task<ResponseModel> DownloadFileAsync(string currentRole, string folderName, string fileName)
        {
            string currentPath = string.Empty;
            if (currentRole == AssessorsManager.Client)
                currentPath = $@"{Directory.GetCurrentDirectory()}\Documents\Client\{folderName}\{fileName}";
            else if (currentRole == AssessorsManager.Administrator || currentRole == AssessorsManager.Root)
                currentPath = $@"{System.IO.Directory.GetCurrentDirectory()}\Documents\Admin\{folderName}\{fileName}";
            else
                currentPath = $@"{Directory.GetCurrentDirectory()}\Documents\Employee\{folderName}\{fileName}";
            var fileBytes = await File.ReadAllBytesAsync(currentPath);
            var fileInfo = new FileInfo(currentPath);
            return await Task.FromResult(new ResponseModel {
                Succeed = true,
                Data = fileBytes,
                ExteraInformation = DefaultMimeTypes.GetContentType(fileInfo.Extension)
            });
        }

        #region Private Methods...

        private async Task<ResponseModel<VMFastRegistration>> OnValidateSearchParams(FastRegistrationSearch model)
        {
            var response = new ResponseModel<VMFastRegistration> { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            if (model == null)
            {
                response.Message = "مدل ارسالی صحیح نمی باشد";
                return await Task.FromResult(response);
            }

            if (model.InstallatinCompanyId.HasValue && model.InstallatinCompanyId.Value <= 0)
            {
                response.Message = "شناسه ارسالی شرکت فروشنده صحیح نمی باشد";
                return await Task.FromResult(response);
            }

            response.Succeed = true;
            response.HttpStatusCode = System.Net.HttpStatusCode.OK;

            return await Task.FromResult(response);
        }
        private async Task<ResponseModel> OnValidateModel(FastRegistrationModel model)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            if (model == null)
            {
                response.Message = "مدل ارسالی صحیح نمی باشد";
                return await Task.FromResult(response);
            }

            if (!model.RequestTypeId.HasValue)
            {
                response.Message = "انتخاب نوع درخواست اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.ProvinceId.HasValue)
            {
                response.Message = "انتخاب استان اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.CityId.HasValue)
            {
                response.Message = "انتخاب شهر اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.Address.Trim()))
            {
                response.Message = "آدرس محل بازدید اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.ElevatorTypeId.HasValue)
            {
                response.Message = "انتخاب نوع آسانسور اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.InspectionTypeId.HasValue)
            {
                response.Message = "انتخاب نوع بازرسی اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.InstallatinCompanyId.HasValue)
            {
                response.Message = "انتخاب نصاب اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (model.InspectionTypeId.Value == 2)
            {
                if (!model.LatestCertificateTypeId.HasValue)
                {
                    response.Message = "انتخاب نوع گواهینامه قبلی اجباری می باشد";
                    return await Task.FromResult(response);
                }
            }

            if (string.IsNullOrWhiteSpace(model.BuildingAreaNo))
            {
                response.Message = "منطقه شهرداری اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.BuildingCertificateNo))
            {
                response.Message = "شماره پروانه ساختمانی اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.BuildingPleque))
            {
                response.Message = "شماره پلاک ثبتی اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.BuildingIssueDate.HasValue)
            {
                response.Message = "تاریخ صدور پروانه ساختمان اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.ElevatorNationalNo))
            {
                response.Message = "شناسه ملی آسانسور اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.ISIRINo))
            {
                response.Message = "کد رهگیری سامانه مدیریت اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (!model.CustomerId.HasValue)
            {
                response.Message = "انتخاب مشتری اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.ResponsibleCell))
            {
                response.Message = "تلفن همراه هماهنگی اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(model.ResponsibleFullName))
            {
                response.Message = "نام و نام خانوادگی هماهنگ کننده اجباری می باشد";
                return await Task.FromResult(response);
            }

            if (model.StopCount == null || !model.StopCount.HasValue)
            {
                response.Message = "مقدار تعداد توقف اجباری می باشد";
                return await Task.FromResult(response);
            }

            response.Succeed = true;
            response.HttpStatusCode = System.Net.HttpStatusCode.OK;

            return await Task.FromResult(response);
        }
        private async Task<ResponseModel> GetInvoiceInformation(Guid tag)
        {
            var findElevatorInspectionResult = await this.elevatorInspectionService.FindAsync(tag);

            Log.Information($"The findElevatorInspectionResult was {System.Text.Json.JsonSerializer.Serialize(findElevatorInspectionResult)}");

            if (findElevatorInspectionResult.Data == null)
                return findElevatorInspectionResult;

            var elevatorInspection = (ElevatorInspection)(findElevatorInspectionResult.Data);
            var elevatorInformation = await this.dataContext.ElevatorInformations.FindAsync(elevatorInspection.ElevatorInformationId);
            var installationCompany = (await this.installatinCompanyService.SearchAsync(new InstallatinCompanySearch { Id = elevatorInformation.InstallatinCompanyId }, true, null, null)).ResponseList.First();
            var paymentResponse = await paymentCalculator.CalculateAsync(elevatorInspection.ElevatorInformationId);
            if (!paymentResponse.Succeed)
            {
                findElevatorInspectionResult.Message = paymentResponse.Message;
                return findElevatorInspectionResult;
            }

            var payment = (PaymentCalculatorResponse)paymentResponse.Data;

            return new ResponseModel
            {
                Succeed = true,
                Data = new InvoiceInfoModel
                {
                    ResponsibleFullName = elevatorInformation.ResponsibleFullName,
                    ResponsibleCell = elevatorInformation.ResponsibleCell,
                    Address = elevatorInformation.Address,
                    DocumentNumber = elevatorInformation.DocumentNumber,
                    Row = elevatorInspection.Row,
                    InvoiceNumber = long.Parse($"{elevatorInspection.Id}{DateTime.Now.Hour.ToString().PadLeft(2, '0')}{DateTime.Now.Minute.ToString().PadLeft(2, '0')}{DateTime.Now.Second.ToString().PadLeft(2, '0')}"),
                    InstallationCompanyName = installationCompany.Name,
                    Amount = String.Format("{0:n0}", payment.TariffValue),
                    TravelExpenses = String.Format("{0:n0}", LocalConstants.TravelExpenses),
                    AdditionalStopCount = payment.AddtionalStopCount,
                    AdditionalPayment = String.Format("{0:n0}", (payment.AddtionalStopCount * payment.AdditionalPayPerStepValue)),
                    Tax = String.Format("{0:n0}", payment.TaxValue),
                    Date = DateTime.Now.ConvertToPersianDate(),
                    TotalPayment = String.Format("{0:n0}", payment.TotalPaymenyValue),
                    SourceTable = nameof(ElevatorInspection),
                    SourceKey = elevatorInspection.Id.ToString()
                }
            };
        }

        #endregion
    }
}
