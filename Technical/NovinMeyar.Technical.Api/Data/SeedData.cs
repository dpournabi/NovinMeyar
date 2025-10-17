using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using NovinMeyar.Technical.DataLayer;
using NovinMeyar.Technical.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Data
{
    public class SeedData
    {
        private readonly DataContext dataContext;
        private readonly IExecutionStrategy executionStrategy;
        public SeedData(DataContext dataContext)
        {
            this.dataContext = dataContext;
            this.executionStrategy = dataContext.Database.CreateExecutionStrategy();
        }

        public async Task CreateDatabases(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
            if (dataContext != null && dataContext.Database != null)
            {
                dataContext.Database.Migrate();
            }
        }

        /// <summary>
        /// شرکت فروشنده
        /// </summary>
        public async Task SeedInstallationCompanyAsync()
        {
            if (!dataContext.InstallatinCompanies.Any())
            {
                var listBalanceWeightAntiShockTypes = new List<InstallatinCompany>
                {
                    new InstallatinCompany{  Code="01", Name="شرکت تست", DesigningCertificateId=1, RegistrationOfficeCertificate=1, CreateDate=DateTime.Now},
                };
                await dataContext.AddRangeAsync(listBalanceWeightAntiShockTypes);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// انواع وضعیت آخرین گواهینامه
        /// </summary>
        public async Task SeedLatestCertificateTypeAsync()
        {
            if (!dataContext.LatestCertificateTypes.Any())
            {
                var list = new List<LatestCertificateType>
                {
                    new LatestCertificateType{ Title = "صادره از نما" },
                    new LatestCertificateType{ Title = "صادره از شرکت دیگر" }
                };
                await dataContext.AddRangeAsync(list);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// انواع جنس دیوار کابین
        /// </summary>
        public async Task SeedWallMaterialTypeAsync()
        {
            if (!dataContext.WallMaterialTypes.Any())
            {
                var list = new List<WallMaterialType>
                {
                    new WallMaterialType{  Title = "استیل"},
                    new WallMaterialType{  Title = "شیشه"},
                    new WallMaterialType{  Title = "MDF"},
                    new WallMaterialType{  Title = "فرمیکا"}
                };
                await dataContext.AddRangeAsync(list);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// انواع جنس کف کابین
        /// </summary>
        public async Task SeedBedMaterialTypeAsync()
        {
            if (!dataContext.BedMaterialTypes.Any())
            {
                var list = new List<BedMaterialType>
                {
                    new BedMaterialType{  Title = "سنگ"},
                    new BedMaterialType{  Title = "شیشه"},
                    new BedMaterialType{  Title = "فلز"}
                };
                await dataContext.AddRangeAsync(list);
                await dataContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// انواع جنس فلکه هرزگرد
        /// </summary>
        public async Task SeedPulleyMaterialTypeAsync()
        {
            if (!dataContext.PulleyMaterialTypes.Any())
            {
                var list = new List<PulleyMaterialType>
                {
                    new PulleyMaterialType{  Title = "چدن"},
                    new PulleyMaterialType{  Title = "پلیمری"}
                };
                await dataContext.AddRangeAsync(list);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// نوع ضربه گیر وزنه تعادل
        /// </summary>
        public async Task SeedBalanceWeightAntiShockTypeAsync()
        {
            if (!dataContext.CounterWeightAntiShockTypes.Any())
            {
                var listBalanceWeightAntiShockTypes = new List<CounterWeightAntiShockType>
                {
                    new CounterWeightAntiShockType{  Title = "پلی ارتان"},
                    new CounterWeightAntiShockType{  Title = "هیدرولیک"},
                    new CounterWeightAntiShockType{  Title = "فنری"}
                };
                await dataContext.AddRangeAsync(listBalanceWeightAntiShockTypes);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// نوع وزنه تعادل
        /// </summary>
        public async Task SeedBalanceWeightTypeAsync()
        {
            if (!dataContext.CounterWeightTypes.Any())
            {
                var listBalanceWeightTypes = new List<CounterWeightType>
                {
                    new CounterWeightType{  Title = "چدن"},
                    new CounterWeightType{  Title = "گالوانیزه"},
                    new CounterWeightType{  Title = "بتن"}
                };
                await dataContext.AddRangeAsync(listBalanceWeightTypes);
                await dataContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// نوع ترمز
        /// </summary>
        public async Task SeedBrakeTypeAsync()
        {
            if (!dataContext.BrakeTypes.Any())
            {
                var listBrakeTypes = new List<BrakeType>
                {
                    new BrakeType{  Title = "تدریجی"},
                    new BrakeType{  Title = "آنی"},
                    new BrakeType{  Title = "آنی با اثر ضربه گیری"}
                };
                await dataContext.AddRangeAsync(listBrakeTypes);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// نوع ضربه گیر کابین
        /// </summary>
        public async Task SeedCabinAntiShockTypeAsync()
        {
            if (!dataContext.CabinAntiShockTypes.Any())
            {
                var listCabinAntiShockTypes = new List<CabinAntiShockType>
                {
                    new CabinAntiShockType{  Title = "پلی ارتان"},
                    new CabinAntiShockType{  Title = "هیدرولیک"},
                    new CabinAntiShockType{  Title = "فنری"}
                };
                await dataContext.AddRangeAsync(listCabinAntiShockTypes);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// نوع درب
        /// </summary>
        public async Task SeedDoorTypeAsync()
        {
            if (!dataContext.DoorTypes.Any())
            {
                var listDoorTypes = new List<DoorType>
                {

                    new DoorType{  Title = "اتوبوسی", IsCabin = true},//درب کابین
                    new DoorType{  Title = "تلسکوپی دو لنگه", IsCabin = true},
                    new DoorType{  Title = "تلسکوپی سه لنگه", IsCabin = true},
                    new DoorType{  Title = "سانترال دو لنگه", IsCabin=true},
                    new DoorType{  Title = "سانترال چهار لنگه", IsCabin = true},
                    new DoorType{  Title = "سانترال شش لنگه", IsCabin = true},
                    new DoorType{  Title = "تلسکوپی هشت لنگه", IsCabin = true},

                    new DoorType{  Title = "لولایی", IsCabin = false}, //درب طبقه
                    new DoorType{  Title = "تلسکوپی دو لنگه-اتوماتیک", IsCabin = false},
                    new DoorType{  Title = "تلسکوپی سه لنگه-اتوماتیک", IsCabin = false},
                    new DoorType{  Title = "سانترال-اتوماتیک", IsCabin = false},
                    new DoorType{  Title = "سانترال چهارلنگه-اتوماتیک", IsCabin = false},
                    new DoorType{  Title = "سانترال شش لنگه-اتوماتیک", IsCabin = false},
                    new DoorType{  Title = "سانترال هشت لنگه-اتوماتیک", IsCabin = false},
                };
                await dataContext.AddRangeAsync(listDoorTypes);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// نوع آسانسور
        /// </summary>
        public async Task SeedElevatorTypeAsync()
        {
            if (!dataContext.ElevatorTypes.Any())
            {

                var listElevatorTypes = new List<ElevatorType>
                {
                    new ElevatorType{ Id = 1, Code="01", Name = "آسانسور کششی"},
                    new ElevatorType{ Id = 2, Code="02", Name = "آسانسور هیدرولیکی"}
                };
               

                await executionStrategy.Execute(async
                    () =>
                {
                    using (var transaction = await dataContext.Database.BeginTransactionAsync())
                    {
                        await dataContext.AddRangeAsync(listElevatorTypes);
                        await dataContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [NovinMeyar.Technical].[dbo].[ElevatorTypes] ON");
                        await dataContext.SaveChangesAsync();
                        await dataContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [NovinMeyar.Technical].[dbo].[ElevatorTypes] OFF");
                        await transaction.CommitAsync();
                    }
                });
            }
        }

        /// <summary>
        /// نوع موقعیت
        /// </summary>
        public async Task SeedLocationTypeAsync()
        {
            if (!dataContext.LocationTypes.Any())
            {
                var listLocationTypes = new List<LocationType>
                {
                    new LocationType { Title = "بالا", LocationEnum=1},
                    new LocationType { Title = "پایین", LocationEnum=1},

                    new LocationType { Title = "فاصله انداز سمت کابین", LocationEnum=2},
                    new LocationType { Title = "فاصله انداز سمت وزنه تعادل", LocationEnum=2},
                    new LocationType { Title = "متحرک روی کابین", LocationEnum=2},
                    new LocationType { Title = "متحرک روی وزنه تعادل", LocationEnum=2},


                    new LocationType { Title = "راست", LocationEnum=3},
                    new LocationType { Title = "چپ", LocationEnum=3},
                    new LocationType { Title = "جلو", LocationEnum=3},//غیرقابل ویرایش باشد. به صورت default
                    new LocationType { Title = "پشت", LocationEnum=3},

                    new LocationType { Title = "راست", LocationEnum=4},
                    new LocationType { Title = "چپ", LocationEnum=4},
                    new LocationType { Title = "جلو", LocationEnum=4},//غیرقابل ویرایش باشد. به صورت default
                    new LocationType { Title = "پشت", LocationEnum=4},

                    new LocationType { Title = "راست", LocationEnum=5},
                    new LocationType { Title = "چپ", LocationEnum=5},
                    new LocationType { Title = "پشت", LocationEnum=5},

                    new LocationType { Title = "Left-Up-Vertical", LocationEnum=6},
                    new LocationType { Title = "Left-Up-Horizental", LocationEnum=6},
                    new LocationType { Title = "Left-Up-Atilt", LocationEnum=6},

                    new LocationType { Title = "Right-Up-Vertical", LocationEnum=6},
                    new LocationType { Title = "Right-Up-Horizental", LocationEnum=6},
                    new LocationType { Title = "Right-Up-Atilt", LocationEnum=6},

                    new LocationType { Title = "Left-Down-Vertical", LocationEnum=6},
                    new LocationType { Title = "Left-Down-Horizental", LocationEnum=6},
                    new LocationType { Title = "Left-Down-Atilt", LocationEnum=6},

                    new LocationType { Title = "Right-Down-Vertical", LocationEnum=6},
                    new LocationType { Title = "Right-Down-Horizental", LocationEnum=6},
                    new LocationType { Title = "Right-Down-Atilt", LocationEnum=6},


                    new LocationType { Title = "بالا چاه", LocationEnum=7},
                    new LocationType { Title = "میانه چاه", LocationEnum=7},
                    new LocationType { Title = "داخل چاهک", LocationEnum=7},

                };
                await dataContext.AddRangeAsync(listLocationTypes);
                await dataContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// نوع کفشک های راهنما
        /// </summary>
        public async Task SeedShoesTypeAsync()
        {
            if (!dataContext.WeightShoesTypes.Any())
            {
                var listWeightShoesTypes = new List<ShoesType>
                {
                    new ShoesType { Title = "غلطکی"},
                    new ShoesType { Title = "لغزشی با روغن"},
                    new ShoesType { Title = "لغزشی بدون روغن"},
                };
                await dataContext.AddRangeAsync(listWeightShoesTypes);
                await dataContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// نوع بازرسی
        /// </summary>
        public async Task SeedInspectionTypeAsync()
        {
            if (!dataContext.InspectionTypes.Any())
            {
                var listWeightShoesTypes = new List<InspectionType>
                {
                    new InspectionType { Id =1, Title = "اولیه"},
                    new InspectionType { Id = 2, Title = "ادواری"}
                };
                await executionStrategy.Execute(async
                    () =>
                {
                    using (var transaction = await dataContext.Database.BeginTransactionAsync())
                    {
                        await dataContext.AddRangeAsync(listWeightShoesTypes);
                        await dataContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [NovinMeyar.Technical].[dbo].[InspectionTypes] ON");
                        await dataContext.SaveChangesAsync();
                        await dataContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [NovinMeyar.Technical].[dbo].[InspectionTypes] OFF");
                        await transaction.CommitAsync();
                    }
                });
            }
        }

        public async Task SeedInspectionTariffsAsync()
        {
            ///هزینه ایاب و ذهاب
            /// 1.339.000 ريال
            
            if (!dataContext.InspectionTariffs.Any())
            {
                var currentDate = DateTime.Now.Date;
                var startDate = new DateTime(2022, 5, 10);

                await dataContext.InspectionTariffs.AddRangeAsync(
                    //اولیه
                   new InspectionTariff {
                        InspectionTypeId = 1,
                        Step=1,
                        Amount = 12051000,
                        AdditionalPayPerStopCount = 669500,
                        StartDate =startDate, 
                       CreateDate=currentDate, 
                       UserCreatorName="administrator", 
                       Deleted=false,
                       
                   },
                   new InspectionTariff
                   {
                       InspectionTypeId = 1,
                       Step = 2,
                       Amount = 6695000,
                       AdditionalPayPerStopCount = 669500,
                       StartDate = startDate,
                       CreateDate = currentDate,
                       UserCreatorName = "administrator",
                       Deleted = false
                   },
                   new InspectionTariff
                   {
                       InspectionTypeId = 1,
                       Step = 3,
                       Amount = 4017000,
                       AdditionalPayPerStopCount = 669500,
                       StartDate = startDate,
                       CreateDate = currentDate,
                       UserCreatorName = "administrator",
                       Deleted = false
                   },

                   

                   //ادواری
                   new InspectionTariff
                   {
                       InspectionTypeId = 2,
                       Step = 1,
                       Amount = 6695000,
                       AdditionalPayPerStopCount = 329492,
                       StartDate = startDate,
                       CreateDate = currentDate,
                       UserCreatorName = "administrator",
                       Deleted = false
                   },
                   new InspectionTariff
                   {
                       InspectionTypeId = 2,
                       Step = 2,
                       Amount = 4017000,
                       AdditionalPayPerStopCount = 329492,
                       StartDate = startDate,
                       CreateDate = currentDate,
                       UserCreatorName = "administrator",
                       Deleted = false
                   },
                   new InspectionTariff
                   {
                       InspectionTypeId = 2,
                       Step = 3,
                       Amount = 2678000,
                       AdditionalPayPerStopCount = 329492,
                       StartDate = startDate,
                       CreateDate = currentDate,
                       UserCreatorName = "administrator",
                       Deleted = false
                   }
                );

                await dataContext.SaveChangesAsync();
            }


        }
    }
}
