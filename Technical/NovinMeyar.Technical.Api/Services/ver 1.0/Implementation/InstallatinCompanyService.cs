using System;
using System.Linq;
using System.Threading.Tasks;
using NovinMeyar.Technical.DataLayer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MassTransit;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Common;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace NovinMeyar.Technical.Api.Services.ver_1._0.Implementation
{
    public class InstallatinCompanyService : IInstallatinCompanyService
    {
        private readonly DataContext dataContext;
        private readonly ILogger logger;
        public InstallatinCompanyService(DataContext dataContext,
            ILogger logger)
        {
            this.dataContext = dataContext;
            this.logger = logger;
        }
        public async Task<ResponseModel<InstallatinCompany>> SearchAsync(InstallatinCompanySearch search, bool currentRoleIsAdmin, IEnumerable<string> currentBranchUsers, string currentUserRole)
        {
            var query = (from ic in dataContext.InstallatinCompanies
                         where !ic.Deleted &&
                                 (!search.Id.HasValue || ic.Id == search.Id.Value) &&
                                 (string.IsNullOrEmpty(search.Code) || ic.Code == search.Code) &&
                                 (string.IsNullOrEmpty(search.EconomicCode) || ic.EconomicCode.Contains(search.EconomicCode)) &&
                                 (string.IsNullOrEmpty(search.Name) || ic.Name.Contains(search.Name)) &&
                                 (string.IsNullOrEmpty(search.NationalNo) || ic.NationalNo.Contains(search.NationalNo)) &&
                                 (string.IsNullOrEmpty(search.RegistrationNo) || ic.RegistrationNo.Contains(search.RegistrationNo)) &&
                                 (currentRoleIsAdmin || currentUserRole== AssessorsManager.TechnicalManager || search.Id.HasValue || currentBranchUsers.Contains(ic.UserCreatorName))
                         select ic).OrderBy(x=>x.Name).AsQueryable();

            var totalCount = await query.AsNoTracking().CountAsync();
            var data = await query.AsNoTracking()
                                .Skip((search.PageIndex - 1) * search.PageSize)
                                .Take(search.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<InstallatinCompany>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel> RegisterNewAsync(InstallatinCompany installatinCompany, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                var validation = await OnValidateAsync(installatinCompany, null);

                if (userName != "System" && !validation.Succeed)
                    return validation;

                installatinCompany.UserCreatorName = userName;
                installatinCompany.CreateDate = DateTime.Now;

                await dataContext.InstallatinCompanies.AddAsync(installatinCompany);
                await dataContext.SaveChangesAsync();

                response.Data = installatinCompany.Id;
                response.Message = "عملیات ثبت شرکت فروشنده با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(InstallatinCompanyService)} --> {nameof(RegisterNewAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel> EditAsync(InstallatinCompany installatinCompany, string userName, int? installationCompanyId)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                var validation = await OnValidateAsync(installatinCompany, installationCompanyId);

                if (!validation.Succeed)
                    return validation;

                var objInstallatinCompany = await dataContext.InstallatinCompanies.FindAsync(installatinCompany.Id);

                objInstallatinCompany.Code = installatinCompany.Code;
                objInstallatinCompany.Name = installatinCompany.Name;
                objInstallatinCompany.NationalNo = installatinCompany.NationalNo;
                objInstallatinCompany.EconomicCode = installatinCompany.EconomicCode;
                objInstallatinCompany.RegistrationNo = installatinCompany.RegistrationNo;
                objInstallatinCompany.Address = installatinCompany.Address;
                objInstallatinCompany.CTOFirstName = installatinCompany.CTOFirstName;
                objInstallatinCompany.CTOLastName = installatinCompany.CTOLastName;
                objInstallatinCompany.CTOBirthDate = installatinCompany.CTOBirthDate;
                objInstallatinCompany.CTOCell = installatinCompany.CTOCell;
                objInstallatinCompany.TellPhone = installatinCompany.TellPhone;
                objInstallatinCompany.RegistrationOfficeCertificate = installatinCompany.RegistrationOfficeCertificate;
                objInstallatinCompany.DesigningCertificateId = installatinCompany.DesigningCertificateId;
                objInstallatinCompany.UserModifiedDate = DateTime.Now;
                objInstallatinCompany.UserModifiedName = userName;

                await dataContext.SaveChangesAsync();

                response.Message = "عملیات ویرایش شرکت فروشنده با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(InstallatinCompanyService)} --> {nameof(EditAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel> DeactiveAsync(long installatinCompanyId, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (installatinCompanyId <= 0)
                    return response;

                var entity = await dataContext.InstallatinCompanies.FindAsync(installatinCompanyId);

                entity.Deleted = true;
                entity.UserModifiedName = userName;
                entity.UserModifiedDate = DateTime.Now;
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف مشتری با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(InstallatinCompanyService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
            }

            return response;
        }

        public async Task<ResponseModel> PhysicalDeleteAsync(long installatinCompanyId, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (installatinCompanyId <= 0)
                    return response;

                var entity = await dataContext.InstallatinCompanies.FindAsync(installatinCompanyId);
                dataContext.InstallatinCompanies.Remove(entity);
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف فیزیکی مشتری با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(InstallatinCompanyService)} --> {nameof(PhysicalDeleteAsync)} at {DateTime.Now}";
            }

            return response;
        }

        #region Private Methods

        private async Task<ResponseModel> OnValidateAsync(InstallatinCompany installatinCompany, int? installationCompanyId)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.OK };

            if (installatinCompany is null)
                return await Task.FromResult(response);

            if (installationCompanyId.HasValue && installatinCompany.Id != installationCompanyId)
            {
                response.Message = "شما مجاز به بروزرسانی اطلاعات پروفایل خود نمی باشید";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrEmpty(installatinCompany.Name))
            {
                response.Message = "ورود نام شرکت الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrEmpty(installatinCompany.NationalNo))
            {
                response.Message = "ورود شناسه ملی الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrEmpty(installatinCompany.RegistrationNo))
            {
                response.Message = "ورود شماره ثبت الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrEmpty(installatinCompany.EconomicCode))
            {
                response.Message = "ورود کد اقتصادی الزامیست";
                return await Task.FromResult(response);
            }

            if (!string.IsNullOrEmpty(installatinCompany.CTOCell))
            {
                if (!Regex.IsMatch(installatinCompany.CTOCell, Constants.CellPattern, RegexOptions.IgnoreCase))
                {
                    response.Message = "فرمت شماره همراه مدیرعامل صحیح نمی باشد";
                    return await Task.FromResult(response);
                }
            }

            if(installatinCompany.CTOBirthDate.HasValue)
            {
                if(installatinCompany.CTOBirthDate.Value>DateTime.Now.AddYears(-20))
                {
                    response.Message = "تاریخ تولد مدیرعامل صحیح نمی باشد";
                    return await Task.FromResult(response);
                }
            }

            response.Succeed = true;
            return await Task.FromResult(response);
        }
        #endregion
    }
}
