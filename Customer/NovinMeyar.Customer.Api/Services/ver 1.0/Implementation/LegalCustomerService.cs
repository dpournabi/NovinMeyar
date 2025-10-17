using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using NovinMeyar.Customer.DataLayer;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.Common;
using NovinMeyar.Customer.Domain;
using NovinMeyar.Customer.Domain.Entities;

namespace NovinMeyar.Customer.Api.Services.ver_1._0.Implementation
{
    public class LegalCustomerService : ILegalCustomerService
    {
        private readonly DataContext dataContext;
        public LegalCustomerService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ResponseModel<LegalCustomer>> SearchAsync(LegalSearch search, long branchId, bool currentRoleIsAdmin, string userName, string currentRoleName)
        {
            var query = (from p in dataContext.LegalCustomers
                         where !p.Deleted
                         select p).AsQueryable();

            if(currentRoleName == AssessorsManager.Client)
                query = query.Where(x => x.UserCreatorName == userName);

            if (!currentRoleIsAdmin)
                query = query.Where(x => x.BranchId == branchId);

            if (search.Id.HasValue)
                query = query.Where(x => x.Id == search.Id);

            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));

            if (!string.IsNullOrWhiteSpace(search.NationalCode))
                query = query.Where(x => x.NationalCode == search.NationalCode);

            if (!string.IsNullOrWhiteSpace(search.RegisterNo))
                query = query.Where(x => x.RegisterNo == search.RegisterNo);

            if (!string.IsNullOrWhiteSpace(search.EconomicCode))
                query = query.Where(x => x.EconomicCode == search.EconomicCode);

            if (!string.IsNullOrWhiteSpace(search.CEOFirstName))
                query = query.Where(x => x.CEOFirstName.Contains(search.EconomicCode));

            if (!string.IsNullOrWhiteSpace(search.CEOLastName))
                query = query.Where(x => x.CEOLastName.Contains(search.CEOLastName));
            
            if (search.PageSize <= 0)
                search.PageSize = 10;

            var totalCount = await query.AsNoTracking().CountAsync();
            var data = await query.AsNoTracking()
                                .Skip((search.PageIndex - 1) * search.PageSize)
                                .Take(search.PageSize)
                                .ToListAsync()
                                .ConfigureAwait(false);

            return new ResponseModel<LegalCustomer>
            {
                Succeed = true,
                ResponseList = data,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ExteraInformation = totalCount
            };
        }
        public async Task<ResponseModel> SaveAsync(LegalCustomer customer, long branchId, string userName)
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

                    await dataContext.LegalCustomers.AddAsync(customer);
                }
                else
                {
                    var objCustomer = await dataContext.LegalCustomers.FindAsync(customer.Id);

                    objCustomer.CEOBirthday = customer.CEOBirthday;
                    objCustomer.CEOFirstName = customer.CEOFirstName;
                    objCustomer.CEOLastName = customer.CEOLastName;
                    objCustomer.EconomicCode = customer.EconomicCode;
                    objCustomer.CEOCell = customer.CEOCell;
                    objCustomer.Name = customer.Name;
                    objCustomer.NationalCode = customer.NationalCode;
                    objCustomer.RegisterNo = customer.RegisterNo;
                    objCustomer.TellPhone = customer.TellPhone;
                    objCustomer.UserModifiedDate = DateTime.Now;
                    objCustomer.UserModifiedName = userName;
                }

                await dataContext.SaveChangesAsync();

                response.Message = "عملیات ثبت مشتری با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                response.ExteraInformation = customer.Id;
            }
            catch (Exception ex)
            {
                response.Message = $"Raised error on --> {nameof(LegalCustomerService)} --> {nameof(SaveAsync)} at {DateTime.Now}";
                Log.Error(ex, response.Message);
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

                var objCustomer = await dataContext.LegalCustomers.FindAsync(customerId);

                objCustomer.Deleted = true;
                objCustomer.UserModifiedDate = DateTime.Now;
                objCustomer.UserModifiedName = userName;
                await dataContext.SaveChangesAsync();

                response.Message = "عملیات حذف مشتری با موفقیت انجام شد";
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Message = $"Raised error on --> {nameof(LegalCustomerService)} --> {nameof(DeactiveAsync)} at {DateTime.Now}";
                Log.Error(ex, response.Message);
            }

            return response;
        }

        #region Private Methods

        private async Task<ResponseModel> OnValidateAsync(LegalCustomer customer)
        {
            var response = new ResponseModel { Succeed = false, HttpStatusCode = System.Net.HttpStatusCode.OK };

            if (customer is null)
                return await Task.FromResult(response);

            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                response.Message = "ورود نام شرکت/موسسه الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.EconomicCode))
            {
                response.Message = "ورود کد اقتصادی شرکت/موسسه الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.RegisterNo))
            {
                response.Message = "ورود شماره ثبت شرکت/موسسه الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.NationalCode))
            {
                response.Message = "ورود شناسه ملی شرکت/موسسه الزامیست";
                return await Task.FromResult(response);
            }

            if (string.IsNullOrWhiteSpace(customer.TellPhone))
            {
                response.Message = "ورود شماره تلفن شرکت/موسسه الزامیست";
                return await Task.FromResult(response);
            }

            response.Succeed = true;
            return await Task.FromResult(response);
        }
        #endregion
    }
}
