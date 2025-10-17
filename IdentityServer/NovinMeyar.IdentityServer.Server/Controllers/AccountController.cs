using System.Collections.Generic;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NovinMeyar.IdentityServer.Server.Services;
using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Domain.DTO;
using System;
using NovinMeyar.IdentityServer.Domain.View;
using System.Threading;

namespace NovinMeyar.IdentityServer.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController : BaseController
    {
        private readonly ILogger logger;
        public IConfiguration configuration { get; }
        private static AppSettings _appSettings;
        private readonly IAccountService accountService;

        public AccountController(IConfiguration configuration,
                              ILogger logger,
                              IAccountService accountService)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.accountService = accountService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _appSettings = configuration.Get<AppSettings>();
            string baseUrl = $"{_appSettings.IdentityServerAddress}/connect/token";
            var response = await accountService.LoginAsync(loginRequest, baseUrl);
            return Ok(response);
        }

        [HttpPost("Logout")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.TechnicalManager + "," + AssessorsManager.TechnicalExpert + "," + AssessorsManager.BranchManager)]
        public async Task<IActionResult> Logout()
        {
            var response = await accountService.LogoutAsync();
            return Ok(response);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterClient client, CancellationToken cancellationToken)
        {
            var response = await accountService.RegisterClientAsync(client);
            if (response.Succeed)
            {
                var generateConfirmationToken = await accountService.GenerateSmsConfirmationTokenAsync(client.Username);
                if (!generateConfirmationToken.Succeed)
                    return Ok(generateConfirmationToken);

                var sendingMessageResult = await accountService.SendVerificationCode(client.Username, generateConfirmationToken.Data.ToString(), cancellationToken);
                if (!sendingMessageResult.Succeed)
                    return Ok(sendingMessageResult);
            }
            
            return Ok(response);
        }

        [HttpPost("VerifyRegisterationCode")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyRegisterationCode([FromBody] VerifyCode verifyCode)
        {
            var response = await accountService.VerifyRegisterationCode(verifyCode);
            return Ok(response);
        }

        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = await accountService.ChangePasswordAsync(request, User.Identity.UserName());
            return Ok(response);
        }

        [HttpPost("ForgetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
        {
            var response = await accountService.GenerateForgetPasswordTokenAsync(request);
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);

            var token = response.Message;
            var link = Url.Action("ResetPassword", "Account", new { Token = token, Username = request.Username }, Request.Scheme);
            //"Please click the below link for reset your password \n {0}";
            //Send SMS to client
            string message = $"جهت بازنشانی کلمه عبور خود روی لینک ذیل کلیک نمایید \n {link}";
            //TODO: Send message to client

            response.Message = "ارسال لینک بازیابی کلمه عبور با موفقیت انجام شد";
            response.Succeed = true;

            return Ok(response);

        }

        [HttpPost("Administrator/ResetPasswordByAdmin"), Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> ResetPasswordByAdmin(string userName)
        {
            var response = await accountService.ResetPasswordByAdminAsync(userName, "Aa@123456");
            return Ok(response);
        }

        [HttpPost("Administrator/UnlockUserByAdmin"), Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> UnlockUserByAdminAsync(string userName)
        {
            var response = await accountService.UnlockUserByAdminAsync(userName);
            return Ok(response);
        }

        [HttpPost("Administrator/VerifyClientByAdmin")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> VerifyClientByAdmin([FromBody] Guid UserId)
        {
            var response = await accountService.VerifyClientByAdmin(UserId);
            return Ok(response);
        }

        [HttpPost("Administrator/DeactivateUser")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> DeactivateUser([FromBody] Guid UserId)
        {
            var response = await accountService.DeactivateUserAsync(UserId);
            return Ok(response);
        }

        [HttpPost("Administrator/AddClaim")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> AddClaim([FromBody] AddClaimRequest claim)
        {
            var response = await accountService.AddClaimAsync(claim, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/RemoveClaim")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> RemoveClaim([FromBody] NewClaimRequest claim)
        {
            var response = await accountService.RemoveClaimAsync(claim, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/AddClaims")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> AddClaims([FromBody] IEnumerable<NewClaimRequest> claims)
        {
            var response = await accountService.AddClaimsAsync(claims, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/RemoveClaims")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> RemoveClaims([FromBody] IEnumerable<NewClaimRequest> claims)
        {
            var response = await accountService.RemoveClaimsAsync(claims, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/AddUserToRole")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> AddUserToRole([FromBody] string role)
        {
            var response = await accountService.AddUserToRoleAsync(role, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/RemoveUserFromRole")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> RemoveUserFromRole([FromBody] string role)
        {
            var response = await accountService.RemoveUserFromRoleAsync(role, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/AddUserToRoles")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> AddUserToRoles([FromBody] AddUserToRolesRequest request)
        {
            var response = await accountService.AddUserToRolesAsync(request, User.Identity.Name);
            return Ok(response);
        }

        [HttpPost("Administrator/RemoveUserFromRoles")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> RemoveUserFromRoles([FromBody] AddUserToRolesRequest request)
        {
            var response = await accountService.RemoveUserFromRolesAsync(request, User.Identity.Name);
            return Ok(response);
        }

        #region Queries

        [HttpGet("GetCurrentUserAccessLevels")]
        [Authorize]
        public async Task<IActionResult> GetAccessLevels()
        {
            var response = await accountService.GetAccessLevelsAsync(User.Identity.Name, null);
            return Ok(response);
        }

        [HttpGet("GetAccessLevels")]
        [Authorize(Roles = AssessorsManager.Root)]
        public async Task<IActionResult> GetAccessLevels(string userName, string roleName)
        {
            var response = await accountService.GetAccessLevelsAsync(userName, roleName);
            return Ok(response);
        }

        [HttpGet("GetAllNewClients/{confirmByAdmin}")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator + "," + AssessorsManager.BranchManager + "," + AssessorsManager.TechnicalManager)]
        public async Task<IActionResult> GetAllNewClients(bool confirmByAdmin)
        {
            var response = await accountService.GetAllNewClientsAsync(confirmByAdmin);
            return Ok(response);
        }

        [HttpPost("Administrator/GetUserClaims")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetUserClaims(GetUserClaimsRequest request)
        {
            var response = await accountService.GetUserClaimsAsync(request);
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);
            return Ok(response);
        }

        [HttpPost("Administrator/GetUserRoles")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetUserRoles(GetUserRolesRequest request)
        {
            var response = await accountService.GetUserRolesAsync(request);
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);
            return Ok(response);
        }

        [HttpPost("Administrator/GetRoleUsers")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetRoleUsers(GetRoleUsersRequest request)
        {
            var response = await accountService.GetRoleUsersAsync(request);
            if (!response.Succeed)
                return StatusCode((int)response.HttpStatusCode, response.Message);
            return Ok(response);
        }

        [HttpPost("Administrator/GetAllUsers")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetAllUsers(string phrase) => Ok(await accountService.GetAllUsersAsync(phrase));

        [HttpGet("Administrator/GetAllRoles")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetAllRoles() => Ok(await accountService.GetAllRolesAsync());

        [HttpGet("Administrator/GetAllUserClaims")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetAllUserClaims() => Ok(await accountService.GetAllUserClaimsAsync());

        [HttpGet("Administrator/GetAllRoleClaims")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> GetAllRoleClaims() => Ok(await accountService.GetAllRoleClaimsAsync());

        [HttpPost("Administrator/UpdateUser")]
        [Authorize(Roles = AssessorsManager.Root + "," + AssessorsManager.Administrator)]
        public async Task<IActionResult> UpdateUserAsync(UserManagementReposne user) => Ok(await accountService.UpdateUserAsync(user));

        #endregion
    }
}
