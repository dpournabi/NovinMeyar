using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Customer.DataLayer;
using NovinMeyar.Common;
using NovinMeyar.Customer.Domain;
using NovinMeyar.Customer.Domain.Entities;

namespace NovinMeyar.Customer.Api.Services.ver_1._0.Implementation
{
    public class RealCustomerService : IRealCustomerService
    {
        private readonly DataContext dataContext;
        public RealCustomerService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ResponseModel<RealCustomer>> SearchAsync(RealSearch search, long branchId, bool currentRoleIsAdmin, string userName, string currentRoleName)
        {
            var query = (from p in dataContext.RealCustomers
                         where !p.Deleted
                         select p).AsQueryable();

            if (currentRoleName == AssessorsManager.Client)
                query = query.Where(x => x.UserCreatorName == userName);

            if (!currentRoleIsAdmin)
                query = query.Where(x => x.BranchId == branchId);

            if (search.Id.HasValue)
                query = query.Where(x => x.Id == search.Id);

            if (!string.IsNullOrWhiteSpace(search.FirstName) && 
                !string.IsNullOrWhiteSpace(search.LastName) && 
                search.FirstName==search.LastName)
            {
                query = query.Where(x => x.FirstName.Contains(search.FirstName) || x.LastName.Contains(search.LastName));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(search.FirstName))
                    query = query.Where(x => x.FirstName.Contains(search.FirstName));

                if (!string.IsNullOrWhiteSpace(search.LastName))
                    query = query.Where(x => x.LastName.Contains(search.LastName));
            }

            if (!string.IsNullOrWhiteSpace(search.NationalCode))
                query = query.Where(x => x.NationalCode == search.NationalCode);

            if (!string.IsNullOrWhiteSpace(search.TellPhone))
                query = query.Where(x => x.TellPhone.Contains(search.TellPhone));

            if (search.PageSize <= 0)
                search.PageSize = 10;

            var totalCount = await query.AsNoTracking().CountAsync();
            var data = await query.AsNoTracking()
                                .Skip((search.PageIndex-1) * search.PageSize)
                                .Take(search.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<RealCustomer>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel> SaveAsync(RealCustomer customer, long branchId, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                var validation = await OnValidateAsync(customer);

                if (!validation.Succeed)
                    return validation;

                if (customer.Id <= 0)
                {
                    customer.BranchId = branchId;
                    customer.UserCreatorName = userName;
                    customer.CreateDate = DateTime.Now;

                    await dataContext.RealCustomers.AddAsync(customer);
                }
                else
                {
                    var objCustomer = await dataContext.RealCustomers.FindAsync(customer.Id);

                    objCustomer.FirstName = customer.FirstName;
                    objCustomer.LastName = customer.LastName;
                    objCustomer.NationalCode = customer.NationalCode;
                    objCustomer.Code = customer.Code;
                    objCustomer.BirthDate = customer.BirthDate;
                    objCustomer.Address = customer.Address;
                    objCustomer.CellPhone = customer.CellPhone;
                    objCustomer.TellPhone = customer.TellPhone;
                    objCustomer.Email = customer.Email;
                    objCustomer.Address = customer.Address;
                    objCustomer.PostalCode = customer.PostalCode;
                    objCustomer.UserModifiedName = userName;
                    objCustomer.UserModifiedDate = DateTime.Now;
                    objCustomer.NationalCartId = customer.NationalCartId;
                }
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات ثبت مشتری با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                response.ExteraInformation = customer.Id;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception Caught");
                response.Message = $"Raised error on --> {nameof(LegalCustomerService)} --> {nameof(SaveAsync)} at {DateTime.Now}";
            }

            return response;
        }
        public async Task<ResponseModel> DeactiveAsync(long customerId, string userName)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                if (customerId <= 0)
                    return response;

                var objCustomer = await dataContext.RealCustomers.FindAsync(customerId);

                objCustomer.Deleted = true;
                objCustomer.UserModifiedName = userName;
                objCustomer.UserModifiedDate = DateTime.Now;

                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف مشتری با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Message = $"Raised error on --> {nameof(RealCustomerService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
                Log.Error(ex, response.Message);
            }

            return response;
        }

        #region Private Methods

        private async Task<ResponseModel> OnValidateAsync(RealCustomer customer)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.OK };

            if (customer is null)
                return await Task.FromResult(response);

            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                response.Message = "ورود نام الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                response.Message = "ورود نام خانوادگی الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.NationalCode))
            {
                response.Message = "ورود کد ملی الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.TellPhone))
            {
                response.Message = "ورود شماره تلفن الزامیست";
                return await Task.FromResult(response);
            }

            response.Succeed = true;
            return await Task.FromResult(response);
        }
        #endregion
    }
}
