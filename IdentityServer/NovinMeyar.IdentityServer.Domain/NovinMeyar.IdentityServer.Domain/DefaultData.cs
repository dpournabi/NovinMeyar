using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Domain.DTO;
using NovinMeyar.IdentityServer.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NovinMeyar.IdentityServer.Domain
{
    public class DefaultData
    {
        public static IEnumerable<ApplicationRole> DefaultRoles
        {
            get
            {
                yield return new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = AssessorsManager.Root,
                    LocalName = AssessorsManager.Root
                };

                yield return new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = AssessorsManager.Administrator,
                    LocalName = "مدیر سیستم"
                };

                yield return new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = AssessorsManager.TechnicalManager,
                    LocalName = "مدیر فنی"
                };

                yield return new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = AssessorsManager.BranchManager,
                    LocalName = "مدیر شعبه"
                };

                yield return new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = AssessorsManager.TechnicalExpert,
                    LocalName = "بازرس"
                };

                yield return new ApplicationRole
                {
                    Id = Guid.NewGuid(),
                    Name = AssessorsManager.Client,
                    LocalName = "مشتری"
                };
            }
        }
        public static IEnumerable<DefaultUser> DefaultUsers
        {
            get
            {
                yield return new DefaultUser
                {
                    Username = "9128890105",
                    Password = "Dp9128890105",
                    FirstName = "Root",
                    LastName = "User",
                    DateOfBirth = DateTime.Parse("1984-02-11"),
                    IsActive = true,
                    BranchCode = null,
                    Role = AssessorsManager.Root
                };
                yield return new DefaultUser
                {
                    Username = "9129458472",
                    Password = "Abc$12345678",
                    FirstName = "admin",
                    LastName = "istrator",
                    DateOfBirth = DateTime.Parse("1984-02-11"),
                    IsActive = true,
                    BranchCode = null,
                    Role = AssessorsManager.Administrator
                };
                yield return new DefaultUser
                {
                    Username = "9188166069",
                    Password = "Mr253600",
                    FirstName = "مجید",
                    LastName = "رجبی",
                    DateOfBirth = DateTime.Parse("1984-02-11"),
                    IsActive = true,
                    BranchCode = "81",
                    Role = AssessorsManager.BranchManager
                };
                yield return new DefaultUser
                {
                    Username = "9113150960",
                    Password = "Mzn532038@@",
                    FirstName = "دکتر حمید",
                    LastName = "جوانیان",
                    DateOfBirth = DateTime.Parse("1986-01-01"),
                    IsActive = true,
                    BranchCode = "11",
                    Role = AssessorsManager.BranchManager
                };

                //yield return new DefaultUser
                //{
                //    Username = "9929119462",
                //    Password = "KRm10391",
                //    FirstName = "-",
                //    LastName = "ویسی",
                //    DateOfBirth = DateTime.Parse("1986-01-01"),
                //    IsActive = true,
                //    BranchCode = "83",
                //    Role = AssessorsManager.BranchManager
                //};

                yield return new DefaultUser
                {
                    Username = "9144880120",
                    Password = "@Ramin1993",
                    FirstName = "رامین",
                    LastName = "مظفری",
                    DateOfBirth = DateTime.Parse("1986-01-01"),
                    IsActive = true,
                    BranchCode = "44",
                    Role = AssessorsManager.BranchManager//ارومیه
                };

                yield return new DefaultUser
                {
                    Username = "9143101757",
                    Password = "@Tamanna1234",
                    FirstName = "مسعود",
                    LastName = "تمنا",
                    DateOfBirth = DateTime.Parse("1986-01-01"),
                    IsActive = true,
                    BranchCode = "41",
                    Role = AssessorsManager.BranchManager//تبریز
                };

                yield return new DefaultUser
                {
                    Username = "9123946040",
                    Password = "Tehran2021@@",
                    FirstName = "آرمین",
                    LastName = "موافقی",
                    DateOfBirth = DateTime.Parse("1986-01-01"),
                    IsActive = true,
                    BranchCode = "21",
                    Role = AssessorsManager.TechnicalManager
                };

                yield return new DefaultUser
                {
                    Username = "9125582214",
                    Password = "Tehran2021##",
                    FirstName = "محمد",
                    LastName = "پورنعمتی",
                    DateOfBirth = DateTime.Parse("1986-01-01"),
                    IsActive = true,
                    BranchCode = "21",
                    Role = AssessorsManager.TechnicalExpert
                };
            }
        }
        public static IEnumerable<Branch> DefaultBranches 
        {
            get
            {
                yield return new Branch { Code = "81", Name = "شعبه همدان" };
                yield return new Branch { Code = "21", Name = "دفتر مرکزی-شعبه تهران" };
                yield return new Branch { Code = "11", Name = "شعبه مازندران" };
                yield return new Branch { Code = "83", Name = "شعبه کرمانشاه" };
                yield return new Branch { Code = "44", Name = "شعبه ارومیه" };
                yield return new Branch { Code = "41", Name = "شعبه تبریز" };
            }
        }
        public static IEnumerable<string> DefaultRoleClaims
        {
            get
            {
               yield return "BaseInformation.Search";
               yield return "BaseInformation.GetObjectDetailItems";
               yield return "BaseInformation.SearchProperty";
               yield return "BaseInformation.GetTree";
               yield return "BaseInformation.GetInspectionTypes";
               yield return "BaseInformation.GetLatestCertificateTypes";
               yield return "BaseInformation.GetElevatorTypes";
               yield return "BaseInformation.GetBrakeTypes";
               yield return "BaseInformation.GetCabinAntiShockTypes";
               yield return "BaseInformation.GetCounterWeightAntiShockTypes";
               yield return "BaseInformation.GetCounterWeightTypes";
               yield return "BaseInformation.GetDoorTypes";
               yield return "BaseInformation.GetInstallationTypes";
               yield return "BaseInformation.GetWeightShoesTypes";
               yield return "BaseInformation.GetLocationTypes";
               yield return "BaseInformation.FindLocationType";
               yield return "BaseInformation.SearchRequest";
               yield return "CompleteRegistration.Save";
               yield return "CompleteRegistration.Get";
               yield return "ElevatorInspection.Get";
               yield return "ElevatorInspection.Save";
               yield return "FastRegisration.Search";
               yield return "FastRegisration.Save";
               yield return "InstallatinCompany.Search";
               yield return "InstallatinCompany.RegisterNew";
               yield return "InstallatinCompany.Edit";
               yield return "InstallatinCompany.UpdateProfile";
               yield return "BaseInformation.GetRequestTypes";
               yield return "Customer.SearchLegalCustomers";
               yield return "Customer.SaveLegalCustomer";
               yield return "Customer.SearchRealCustomers";
               yield return "Customer.SaveRealCustomer";
               yield return "FileManagment.SaveStream";
               yield return "FileManagment.SaveLargeStream";
               yield return "FileManagment.DownloadFile";
               yield return "FileManagment.GenerateDownloadKey";
               yield return "FileManagment.DeleteStream";
            }
        }
        public static IEnumerable<string> DefaultRoleClaimsForClients
        {
            get
            {
                yield return "FileManagment.SaveStream";
                yield return "FileManagment.GenerateDownloadKey";
                yield return "FileManagment.DeleteStream";
                yield return "InstallatinCompany.UpdateProfile";
                yield return "BaseInformation.GetInspectionTypes";
                yield return "BaseInformation.GetLatestCertificateTypes";
                yield return "BaseInformation.GetElevatorTypes";
                yield return "Customer.SearchLegalCustomers";
                yield return "Customer.SaveLegalCustomer";
                yield return "Customer.SearchRealCustomers";
                yield return "Customer.SaveRealCustomer";
                yield return "FastRegisration.Save";
                yield return "FastRegisration.Search";
                yield return "ElevatorInspection.Get";
                yield return "ElevatorInspection.Save";
            }
        }
    }
}
