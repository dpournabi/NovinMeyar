using Serilog;
using System.Threading.Tasks;
using NovinMeyar.Cartabl.DataLayer;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Common;
using NovinMeyar.Cartabl.Domain.Entities;
using NovinMeyar.Cartabl.Domain.SearchModels;
using System.Linq;
using System;
using NovinMeyar.Cartabl.Api.Enums;
using NovinMeyar.Cartabl.Domain.CommentModels;
using NovinMeyar.Cartabl.Api.Models;
using MassTransit;
using NovinMeyar.Common.MessageBrokers;

namespace NovinMeyar.Cartabl.Api.Services.ver_1._0.Implementation
{
    public class BaseInformationService : IBaseInformationService
    {
        private readonly DataContext dataContext;
        private readonly ILogger logger;
        private readonly IRequestClient<LockRequestBroker> lockRequestClient;
        public BaseInformationService(DataContext dataContext,
            ILogger logger,
            IRequestClient<LockRequestBroker> lockRequestClient)
        {
            this.dataContext = dataContext;
            this.logger = logger;
            this.lockRequestClient = lockRequestClient;
        }

        public async Task<ResponseModel> ConfirmationAsync(string id, string currentUserRole)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                long _id = 0;
                long.TryParse(id, out _id);
                if (_id <= 0)
                    _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(id)));
                var obj = await dataContext.Requests.FirstOrDefaultAsync(x => x.SourceTableKey == null ? x.Url.Contains(_id.ToString()) : x.SourceTableKey == _id).ConfigureAwait(false);
                if (obj == null)
                {
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = "رکوردی یافت نشد",
                        HttpStatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }

                switch (currentUserRole)
                {
                    case "Technical Expert":
                        if (obj.States == -1)
                            obj.States &= (int)CartablStates.TechnicalExpertAccept;
                        else
                            obj.States |= (int)CartablStates.TechnicalExpertAccept;
                        obj.LastState = (int)CartablStates.TechnicalExpertAccept;
                        break;

                    case "Branch Manager":
                        obj.States |= (int)CartablStates.BranchManagerAccept;
                        obj.LastState = (int)CartablStates.BranchManagerAccept;
                        break;

                    case "Administrator":
                    case "Root":
                    case "Technical Manager":
                        var lockRequestReposne = await lockRequestClient.GetResponse<ResponseModel>(new LockRequestBroker
                        {
                            ElevatorInformationId = _id,
                        });

                        if (!lockRequestReposne.Message.Succeed)
                        {
                            response.Succeed = lockRequestReposne.Message.Succeed;
                            response.Message = lockRequestReposne.Message.Message;
                            return response;
                        }

                        if ((CartablStates)obj.LastState == CartablStates.TechnicalExpertAccept)
                        {
                            obj.States |= (int)CartablStates.BranchManagerAccept;
                        }
                        else
                        {
                            if (obj.States == -1)
                                obj.States &= (int)CartablStates.TechnicalExpertAccept;
                            else
                                obj.States |= (int)CartablStates.TechnicalExpertAccept;
                            obj.States |= (int)CartablStates.BranchManagerAccept;
                        }
                        obj.States |= (int)CartablStates.TechnicalManagerAccept;
                        obj.LastState = (int)CartablStates.TechnicalManagerAccept;
                        
                        break;
                }

                await dataContext.SaveChangesAsync();

                return new ResponseModel
                {
                    Succeed = true,
                    Message = "درخواست با موفقیت تایید گردید",
                    HttpStatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(ConfirmationAsync)} at {DateTime.Now}";
            }
            return response;
        }
        public async Task<ResponseModel> CreateCommentAsync(string id, string name, RequestComment model)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                long _id = 0;
                long.TryParse(id, out _id);
                if (_id <= 0)
                    _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(id)));
                var obj = await dataContext.Requests.FirstOrDefaultAsync(x => x.SourceTableKey == null ? x.Url.Contains(_id.ToString()) : x.SourceTableKey == _id).ConfigureAwait(false);
                if (obj == null)
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = "رکوردی یافت نشد",
                        HttpStatusCode = System.Net.HttpStatusCode.NotFound
                    };

                await dataContext.Comments.AddAsync(new Comment
                {
                    Deleted = false,
                    Descrption = model.Body,
                    RequestId = obj.Id,
                    UserCreatorName = name,
                    CreateDate = DateTime.Now,
                });

                await dataContext.SaveChangesAsync();

                return new ResponseModel
                {
                    Succeed = true,
                    Message = "ثبت با موفقیت انجام شد",
                    HttpStatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(CreateCommentAsync)} at {DateTime.Now}";
            }
            return response;
        }
        public async Task<ResponseModel<dynamic>> GetCommentsAsync(string id)
        {
            long _id = 0;
            long.TryParse(id, out _id);
            if (_id <= 0)
                _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(id)));
            var obj = await dataContext.Requests.FirstOrDefaultAsync(x => x.SourceTableKey == null ? x.Url.Contains(_id.ToString()) : x.SourceTableKey == _id).ConfigureAwait(false);
            var comments = await dataContext.Comments.Where(x => x.RequestId == obj.Id && x.Deleted == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Body = x.Descrption,
                    UserName = x.UserCreatorName
                }).ToListAsync();

            return new ResponseModel<dynamic>
            {
                Data = comments,
                Succeed = true,
                Message = "ثبت با موفقیت انجام شد",
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<RequestType>> GetRequestTypesAsync()
        {
            var data = await dataContext.RequestTypes.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return new ResponseModel<RequestType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel> RejectAsync(string id, string currentUserRole)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                long _id = 0;
                long.TryParse(id, out _id);
                if (_id <= 0)
                    _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(id)));
                var obj = await dataContext.Requests.FirstOrDefaultAsync(x => x.SourceTableKey == null ? x.Url.Contains(_id.ToString()) : x.SourceTableKey == _id).ConfigureAwait(false);
                if (obj == null)
                {
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = "رکوردی یافت نشد",
                        HttpStatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }

                switch (currentUserRole)
                {
                    case AssessorsManager.BranchManager:
                        obj.States |= (int)CartablStates.BranchManagerReject;
                        obj.LastState = (int)CartablStates.BranchManagerReject;
                        break;
                    case AssessorsManager.Root:
                    case AssessorsManager.Administrator:
                    case AssessorsManager.TechnicalManager:
                        obj.States |= (int)CartablStates.TechnicalManagerReject;
                        obj.LastState = (int)CartablStates.TechnicalManagerReject;
                        break;
                }

                await dataContext.SaveChangesAsync();

                return new ResponseModel
                {
                    Succeed = true,
                    Message = "ثبت با موفقیت انجام شد",
                    HttpStatusCode = System.Net.HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(RejectAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel<RequestType>> RequestTypesPagedAsync(RequestTypesSearch requestTypesSearch)
        {
            var query = dataContext.RequestTypes.Where(t => true);

            if (!string.IsNullOrWhiteSpace(requestTypesSearch.Title))
                query = query.Where(x => x.Title.Contains(requestTypesSearch.Title));

            if (requestTypesSearch.PageSize <= 0)
                requestTypesSearch.PageSize = 10;

            var totalCount = await query.AsNoTracking().CountAsync();
            var data = await query.AsNoTracking()
                                .Skip((requestTypesSearch.PageIndex - 1) * requestTypesSearch.PageSize)
                                .Take(requestTypesSearch.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<RequestType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel<RequestVM>> SearchRequestAsync(RequestSearch search, long branchId, bool currentRoleIsAdmin, string userName, string currentRoleName)
        {
            var query = dataContext.Requests.Where(x => x.IsActive && !x.IsArchive).AsQueryable();

            if (currentRoleName == AssessorsManager.TechnicalExpert)
                query = query.Where(x => x.BranchId == branchId && (x.LastState == -1 ||
                                                                    x.LastState == (int)CartablStates.BranchManagerReject) ||
                                                                    x.LastState == (int)CartablStates.TechnicalManagerReject);

            if (currentRoleName == AssessorsManager.BranchManager)
                query = query.Where(x => x.BranchId == branchId && (x.LastState == -1 ||
                                                                    x.LastState == (int)CartablStates.TechnicalExpertAccept) ||
                                                                    x.LastState == (int)CartablStates.TechnicalManagerReject);

            if (currentRoleName == AssessorsManager.TechnicalManager)
                query = query.Where(x => x.LastState == (int)CartablStates.TechnicalExpertAccept ||
                                         x.LastState == (int)CartablStates.BranchManagerAccept ||
                                         x.LastState == (int)CartablStates.BranchManagerAccept ||
                                         x.LastState == (int)CartablStates.TechnicalManagerAccept);

            if (search.FromDate != null && search.FromDate != DateTime.MinValue)
                query = query.Where(x => x.CreateDate >= search.FromDate);
            if (search.ToDate != null && search.ToDate != DateTime.MinValue)
                query = query.Where(x => x.CreateDate <= search.ToDate);
            if (search.LastStateID != null)
                query = query.Where(x => x.LastState == search.LastStateID);
            if (search.StatesId != null)
                query = query.Where(x => x.States == search.StatesId);
            if (search.IsSeen != null)
                query = query.Where(x => x.IsSeen == search.IsSeen);
            if (search.IsActive != null)
                query = query.Where(x => x.IsActive == search.IsActive);
            if (search.RequestTypeId != null)
                query = query.Where(x => x.RequestTypeId == search.RequestTypeId);
            if (search.DocumentNumber != null)
                query = query.Where(x => x.RequestTitle.Contains(search.DocumentNumber) || x.CustomerFullName.Contains(search.DocumentNumber));
            if (search.InstallationCompanyId != null)
                query = query.Where(x => x.InstallationCompanyId == search.InstallationCompanyId);

            if (search.PageSize <= 0)
                search.PageSize = 10;

            query = query.OrderByDescending(t => t.CreateDate);

            var totalCount = await query.AsNoTracking().CountAsync();
            var data = await query.AsNoTracking()
                                .Skip((search.PageIndex - 1) * search.PageSize)
                                .Take(search.PageSize)
                                .Select(x => (RequestVM)x)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<RequestVM>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel> SeenRequestAsync(string id)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                long _id = 0;
                long.TryParse(id, out _id);
                if (_id <= 0)
                    _id = Convert.ToInt64((Common.Security.Helper.DecryptNumber(id)));
                var obj = await dataContext.Requests.FirstOrDefaultAsync(x => x.SourceTableKey == null ? x.Url.Contains(_id.ToString()) : x.SourceTableKey == _id).ConfigureAwait(false);
                if (obj == null)
                {
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = "رکوردی یافت نشد",
                        HttpStatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                obj.IsSeen = true;

                await dataContext.SaveChangesAsync();

                response.Message = "ثبت با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(SeenRequestAsync)} at {DateTime.Now}";
            }
            return response;
        }

        public async Task<ResponseModel> UndoRequestStateAsync(long id)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                var obj = await dataContext.Requests.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
                if (obj == null)
                {
                    return new ResponseModel
                    {
                        Succeed = false,
                        Message = "رکوردی یافت نشد",
                        HttpStatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
                obj.States = -1;
                obj.LastState = -1;
                obj.IsSeen = false;
                await dataContext.SaveChangesAsync();

                response.Message = "بازنشانی وضعیت درخواست با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(UndoRequestStateAsync)} at {DateTime.Now}";
            }
            return response;
        }
    }
}
