using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NovinMeyar.Common;
using NovinMeyar.Common.CustomAuthorize;
using NovinMeyar.Technical.Api.Services.ver_1._0;
using NovinMeyar.Technical.Domain.Contracts;
using NovinMeyar.Technical.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace NovinMeyar.Technical.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class InstallatinCompanyController : BaseController
    {
        private readonly IInstallatinCompanyService installatinCompanyService;
        private readonly IRequestClient<Common.MessageBrokers.CustomMessageBroker> messageBrokerClient;
        private readonly IConfiguration configuration;
        public InstallatinCompanyController(IInstallatinCompanyService installatinCompanyService,
            IRequestClient<Common.MessageBrokers.CustomMessageBroker> messageBrokerClient,
            IConfiguration configuration)
        {
            this.installatinCompanyService = installatinCompanyService;
            this.messageBrokerClient = messageBrokerClient;
            this.configuration = configuration;
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> GetAsync()
        {
            var response = await installatinCompanyService.SearchAsync(new InstallatinCompanySearch {  Id = User.Identity.ClientId()}, User.Identity.CurrentRoleIsAdmin(), User.Identity.CurrentBranchUsers(), User.Identity.CurrentUserRole());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchAsync([FromBody] InstallatinCompanySearch search)
        {
            var response = await installatinCompanyService.SearchAsync(search, User.Identity.CurrentRoleIsAdmin(), User.Identity.CurrentBranchUsers(), User.Identity.CurrentUserRole());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterNewAsync([FromBody] InstallatinCompany model)
        {
            var response = await installatinCompanyService.RegisterNewAsync(model, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([FromBody] InstallatinCompany model)
        {
            var response = await installatinCompanyService.EditAsync(model, User.Identity.UserName(), null);
            return Ok(response);
        }

        [HttpPost]
        [ClaimRequirement]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfileAsync([FromBody] InstallatinCompany model, CancellationToken cancellationToken)
        {
            var response = await installatinCompanyService.EditAsync(model, User.Identity.UserName(), User.Identity.ClientId());
            if (response.Succeed)
            {
                string reciverNo = this.configuration.Get<AppSettings>().Admin;
                
                await this.messageBrokerClient.GetResponse<ResponseModel>(new Common.MessageBrokers.CustomMessageBroker
                {
                    MobileNumber = reciverNo,
                    TextMessage = $"شرکت {model.Name} در سامانه ثبت نام کرده و منتظر تایید ادمین می باشد."

                }, cancellationToken, int.MaxValue);
                response.Message = "تکمیل پروفایل با موفقیت انجام شد";
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactiveAsync(long installatinCompanyId)
        {
            var response = await installatinCompanyService.DeactiveAsync(installatinCompanyId, User.Identity.UserName());
            return Ok(response);
        }
    }
}
