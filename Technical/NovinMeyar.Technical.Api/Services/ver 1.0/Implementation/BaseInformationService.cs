using System;
using Serilog;
using System.Linq;
using System.Threading.Tasks;
using NovinMeyar.Technical.DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NovinMeyar.Technical.Domain.Entities;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Views;
using NovinMeyar.Common;

namespace NovinMeyar.Technical.Api.Services.ver_1._0.Implementation
{
    public class BaseInformationService : IBaseInformationService
    {
        private readonly DataContext dataContext;
        private readonly ILogger logger;
        public BaseInformationService(DataContext dataContext,
            ILogger logger)
        {
            this.dataContext = dataContext;
            this.logger = logger;
        }
        public async Task<ResponseModel<ObjectDetail>> SearchAsync(BaseInformationSearch search)
        {
            var validate = await OnValidateSearchParamsAsync(search);
            if (!validate.Succeed)
                return validate;

            if (!search.Deleted.HasValue)
                search.Deleted = false;

            var query = (from objectDetail in dataContext.ObjectDetails
                                              .Include(x => x.ObjectDetailProperties)
                                              .ThenInclude(x => x.Property)
                         where objectDetail.Deleted == search.Deleted
                         select objectDetail).AsQueryable();

            
            if (search.Id.HasValue)
                query = query.Where(x => x.Id == search.Id);

            if (!string.IsNullOrWhiteSpace(search.Code))
                query = query.Where(x => x.Code.Contains(search.Code));

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));

            if (search.ElevatorTypeId.HasValue)
                query = query.Where(x => x.ElevatorTypeId == search.ElevatorTypeId);

            if (search.ParentId.HasValue)
                query = query.Where(x => x.ParentId == search.ElevatorTypeId);

            if (search.PropertyId.HasValue)
                query = query.Where(x => x.ObjectDetailProperties.Any(p => p.Property.Id == search.PropertyId));

            if (search.PageSize <= 0)
                search.PageSize = 10;

            var data = await query.AsNoTracking()
                                .Skip((search.PageIndex - 1) * search.PageSize)
                                .Take(search.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<ObjectDetail>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<ObjectDetailItem>> GetObjectDetailItemsAsync(long objectDetailId)
        {
            if(objectDetailId <=0)
            {
                return new ResponseModel<ObjectDetailItem>
                {
                    Succeed = false,
                    Message = "شناسه ارسالی صحیح نمی باشد"
                };
            }

            var data = await (from o in dataContext.ObjectDetailProperties
                                              .Include(x=>x.Property)
                         where !o.Deleted &&
                               o.ObjectDetailId == objectDetailId
                         select new ObjectDetailItem 
                         { 
                             Id = o.Id,
                             PropertyId=o.PropertyId,  
                             PropertyName = o.Property.Name,
                             Value = o.Value,
                             PropertyType = o.Property.Type
                         })
                         .ToListAsync()
                         .ConfigureAwait(false); 

            return new ResponseModel<ObjectDetailItem>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<Property>> SearchPropertyAsync(SearchProperty search)
        {
            var validate = await OnValidateSearchPropertyParamsAsync(search);
            if (!validate.Succeed)
                return validate;

            var query = (from p in dataContext.Properties
                         where p.Deleted == search.Deleted &&
                               (search.Type == null || p.Type.Contains(search.Type)) &&
                               (search.Name == null || p.Name.Contains(search.Name))
                         select p).AsQueryable();

            var totalCount = await query.AsNoTracking().CountAsync();

            search.PageIndex = search.PageIndex == 0 ? 0 : search.PageIndex - 1;
            var data = await query.AsNoTracking()
                                .Skip((search.PageIndex) * search.PageSize)
                                .Take(search.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<Property>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel<ObjectDetail>> GetTreeAsync()
        {
            var result = new ResponseModel<ObjectDetail>() { Succeed=false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };
            var data = new List<ObjectDetail>();

            var firstNode = await dataContext.ObjectDetails
                .Select(x => new ObjectDetail
                {
                    Id = x.Id,
                    Code = x.Code,
                    ElevatorTypeId = x.ElevatorTypeId,
                    Level = x.Level,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    Deleted = x.Deleted
                })
                .FirstOrDefaultAsync(x => x.ParentId == null && x.Level == 0 && !x.Deleted);

            if (firstNode == null)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.NoContent;
                result.Succeed = true;
                return result;
            }

            var tree= await MakeTree(firstNode);
            data.Add(tree);

            return new ResponseModel<ObjectDetail>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel> SaveAsync(ObjectDetail model, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            var executionStrategy = dataContext.Database.CreateExecutionStrategy();

            return await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await dataContext.Database.BeginTransactionAsync())
                {

                    try
                    {
                        var validation = await OnValidateAsync(model);

                        if (!validation.Succeed)
                            return validation;

                        if (await dataContext.ObjectDetails.AnyAsync(x => x.Id == model.Id))
                        {
                            var obj = await dataContext.ObjectDetails.FindAsync(model.Id);
                            obj.Name = model.Name;
                            obj.UserModifiedDate = DateTime.Now;
                            obj.UserModifiedName = userName;
                            await dataContext.SaveChangesAsync();
                        }
                        else
                        {
                            model.Code = GenerateUniqueCode(model);
                            model.CreateDate = DateTime.Now;
                            model.UserCreatorName = userName;
                            await dataContext.ObjectDetails.AddAsync(model);
                        }

                        await dataContext.SaveChangesAsync();

                        if (model.ObjectDetailProperties.Any())
                        {
                            foreach (var item in model.ObjectDetailProperties)
                            {
                                if (await dataContext.ObjectDetailProperties.AnyAsync(x => x.Id == item.Id))//Edit
                                {
                                    var obj = await dataContext.ObjectDetailProperties.FindAsync(item.Id);
                                    obj.Value = item.Value;
                                    await dataContext.SaveChangesAsync();
                                }
                                else//Insert
                                {
                                    item.CreateDate = DateTime.Now;
                                    item.UserCreatorName = userName;
                                    await dataContext.ObjectDetailProperties.AddAsync(item);
                                }
                            }

                            await dataContext.SaveChangesAsync();
                        }

                        //Commit all changes
                        await transaction.CommitAsync();

                        response.Succeed = true;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.ExteraInformation = model.Id;
                        response.Message = "عملیات ثبت با موفقیت انجام شد";
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        logger.Error($"{DateTime.Now} - {nameof(BaseInformationService)} --> {nameof(SaveAsync)} --> Error deatail: {ex.Message}");
                        response.Message = "در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود";
                        response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                    }
                    return response;
                }
            });
        }
        public async Task<ResponseModel> SavePropertyAsync(Property model, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (model == null)
                {
                    response.Message = "مدل ارسالی صحیح نمی باشد";
                    return response;
                }

                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    response.Message = "مقدار نام ویژگی الزامی است";//Name
                    return response;
                }

                if (string.IsNullOrWhiteSpace(model.Type))
                {
                    response.Message = "تعیین نوع ویژگی الزامی است";//Data type
                    return response;
                }

                if (await dataContext.Properties.AnyAsync(x => x.Id == model.Id))
                {
                    var obj = await dataContext.Properties.FindAsync(model.Id);
                    obj.Name = model.Name;
                    obj.Type = model.Type;
                    obj.Deleted = false;
                    obj.UserModifiedDate = DateTime.Now;
                    obj.UserModifiedName = userName;

                    await dataContext.SaveChangesAsync();
                }
                else
                {
                    model.CreateDate = DateTime.Now;
                    model.UserCreatorName = userName;
                    await dataContext.Properties.AddAsync(model);
                }

                await dataContext.SaveChangesAsync();

                response.Succeed = true;
                response.Message = "عملیات ثبت با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} - {nameof(BaseInformationService)} --> {nameof(SavePropertyAsync)} --> Error deatail: {ex.Message}");
                response.Message = "در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<ResponseModel> DeletePropertyAsync(long id, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (id<=0)
                {
                    response.Message = "ارسال شناسه ویژگی الزامی است";//Name
                    return response;
                }

                if (await dataContext.Properties.AnyAsync(x => x.Id == id))
                {
                    var obj = await dataContext.Properties.FindAsync(id);
                    obj.Deleted = true;
                    await dataContext.SaveChangesAsync();

                    response.Succeed = true;
                    response.Message = "عملیات حذف ویژگی با موفقیت انجام شد";
                    return response;
                }
               
                response.Succeed = false;
                response.Message = "عملیات حذف ویژگی با خطا مواجه شد";
            }
            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} - {nameof(BaseInformationService)} --> {nameof(SavePropertyAsync)} --> Error deatail: {ex.Message}");
                response.Message = "در ثبت اطلاعات مشکلی به وجود آمده است. همکاران بخش فناوری در اسرع وقت نسبت به رفع مشکل اقدام خواهند نمود";
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
        public async Task<ResponseModel> DeactiveAsync(long objectDetailId, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (objectDetailId <= 0)
                    return response;

                var obj = await dataContext.ObjectDetails.FindAsync(objectDetailId);

                obj.Deleted = true;
                obj.UserModifiedDate = DateTime.Now;
                obj.UserModifiedName = userName;

                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel> DeactiveObjectDetailPropertyAsync(long objectDetailPropertyId, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (objectDetailPropertyId <= 0)
                    return response;

                var obj = await dataContext.ObjectDetailProperties.FindAsync(objectDetailPropertyId);

                obj.Deleted = true;
                obj.UserModifiedDate = DateTime.Now;
                obj.UserModifiedName = userName;

                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(BaseInformationService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel<InspectionType>> GetInspectionTypesAsync()
        {
            var data = await dataContext.InspectionTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<InspectionType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<LatestCertificateType>> GetLatestCertificateTypesAsync()
        {
            var data = await dataContext.LatestCertificateTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<LatestCertificateType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<ElevatorType>> GetElevatorTypesAsync()
        {
            var data = await dataContext.ElevatorTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<ElevatorType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<BrakeType>> GetBrakeTypesAsync()
        {
            var data = await dataContext.BrakeTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<BrakeType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<CabinAntiShockType>> GetCabinAntiShockTypesAsync()
        {
            var data = await dataContext.CabinAntiShockTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<CabinAntiShockType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<CounterWeightAntiShockType>> GetCounterWeightAntiShockTypesAsync()
        {
            var data = await dataContext.CounterWeightAntiShockTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<CounterWeightAntiShockType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<CounterWeightType>> GetCounterWeightTypesAsync()
        {
            var data = await dataContext.CounterWeightTypes.AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<CounterWeightType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<DoorType>> GetDoorTypesAsync(bool isCabin)
        {
            var data = await dataContext.DoorTypes
                                .Where(x=> x.IsCabin==isCabin)
                                .AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<DoorType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<InstallationType>> GetInstallationTypesAsync()
        {
            var data = await dataContext.InstallationTypes
                                .AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<InstallationType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<LocationType>> GetLocationTypesAsync(byte LocationEnum)
        {
            if(LocationEnum<=0)
            {
                return await Task.FromResult( new ResponseModel<LocationType>
                {
                    Succeed = false,
                    Message = "پارامتر ارسالی در بازه صحیح بیشتر از صفر نمی باشد"
                });
            }

            var data = await dataContext.LocationTypes
                                .Where(x => x.LocationEnum == LocationEnum)
                                .AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<LocationType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel> FindLocationTypeAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return await Task.FromResult(new ResponseModel<LocationType>
                {
                    Succeed = false,
                    Message = "عنوان ارسالی نمی تواند تهی باشد"
                });
            }

            var data = await dataContext.LocationTypes
                                .FirstOrDefaultAsync(x => x.Title == title);

            if (data == null)
            {
                return await Task.FromResult(new ResponseModel<LocationType>
                {
                    Succeed = false,
                    Message = "عنوان ارسالی صحیح نمی باشد"
                });
            }

            return new ResponseModel
            {
                Succeed = true,
                ExteraInformation = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }
        public async Task<ResponseModel<ShoesType>> GetWeightShoesTypesAsync()
        {
            var data = await dataContext.WeightShoesTypes
                                .AsNoTracking()
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<ShoesType>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };
        }

        #region Private Methods
        private async Task<ObjectDetail> MakeTree(ObjectDetail node)
        {
            var childs = await dataContext.ObjectDetails
                .Select(x => new ObjectDetail
                {
                    Id = x.Id,
                    Code = x.Code,
                    ElevatorTypeId = x.ElevatorTypeId,
                    Level = x.Level,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    Deleted = x.Deleted
                })
                .Where(x => x.ParentId == node.Id && !x.Deleted)
                .ToListAsync();

            foreach (var child in childs)
            {
                node.Childs.Add(child);
                await MakeTree(child);
            }
            return node;
        }
        private string GenerateUniqueCode(ObjectDetail objectDetail = null)
        {
            var random = new Random();

        RetryPoint:
            var key = random.Next(1, 10000);

            if (objectDetail == null || !dataContext.ObjectDetails.Any())
                return $"{(0).GetLevelCharacter()}-{key}";

            string generatedCode = $"{objectDetail.Level.GetLevelCharacter()}-{key}";

            if (dataContext.ObjectDetails.Any(x => x.Code == generatedCode))
                goto RetryPoint;

            return generatedCode;
        }
        private async Task<ResponseModel> OnValidateAsync(ObjectDetail model)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.OK };

            if (model is null)
                return await Task.FromResult(response);

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                response.Message = "ارسال مقدار نام الزامی است";
                return await Task.FromResult(response);
            }

            if (model.ParentId.HasValue && model.ParentId.Value<=0)
            {
                response.Message = "مقدار شناسه والد صحیح نمی باشد";
                return await Task.FromResult(response);
            }

            response.Succeed = true;
            return await Task.FromResult(response);
        }
        private async Task<ResponseModel<Property>> OnValidateSearchPropertyParamsAsync(SearchProperty search)
        {
            var response = new ResponseModel<Property> { Succeed = true };

            if (search is null)
            {
                response.Message = "مدل ارسالی صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.Type == "")
            {
                response.Message = "مقدار تایپ ارسالی صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.Name == "")
            {
                response.Message = "مقدار نام صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            return await Task.FromResult(response);
        }
        private async Task<ResponseModel<ObjectDetail>> OnValidateSearchParamsAsync(BaseInformationSearch search)
        {
            var response = new ResponseModel<ObjectDetail> { Succeed = true };

            if (search is null)
            {
                response.Message = "مدل ارسالی صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.Id.HasValue && search.Id.Value <= 0)
            {
                response.Message = "مقدار شناسه صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.Code == "")
            {
                response.Message = "مقدار کد صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.Name == "")
            {
                response.Message = "مقدار نام صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.ParentId.HasValue && search.ParentId.Value <= 0)
            {
                response.Message = "مقدار شناسه والد صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.PropertyId.HasValue && search.PropertyId.Value <= 0)
            {
                response.Message = "مقدار شناسه ویژگی صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            if (search.ElevatorTypeId.HasValue && search.ElevatorTypeId.Value <= 0)
            {
                response.Message = "مقدار شناسه نوع آسانسور صحیح نمی باشد";
                response.Succeed = false;
                return await Task.FromResult(response);
            }

            return await Task.FromResult(response);
        }
        #endregion
    }
}
