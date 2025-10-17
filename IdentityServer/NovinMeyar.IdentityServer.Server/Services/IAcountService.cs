using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Domain.DTO;
using NovinMeyar.IdentityServer.Domain.View;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace NovinMeyar.IdentityServer.Server.Services
{
    public interface IAccountService
    {
        Task<ResponseModel> UpdateUserAsync(UserManagementReposne userManagement);
        Task<ResponseModel> UnlockUserByAdminAsync(string userName);
        Task<ResponseModel> SendVerificationCode(string mobile, string verifyCode, CancellationToken cancellationToken);
        Task<IEnumerable<UserAccessLevelVM>> GetAccessLevelsAsync(string userName, string roleName);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest, string baseUrl);
        Task<ResponseModel> LogoutAsync();
        Task<ResponseModel> GenerateSmsConfirmationTokenAsync(string userName);
        Task<ResponseModel> RegisterClientAsync(RegisterClient client);
        Task<ResponseModel> VerifyClientByAdmin(Guid userId);
        Task<ResponseModel> VerifyRegisterationCode(VerifyCode verifyCode);
        Task<ResponseModel> DeactivateUserAsync(Guid UserId);
        Task<ResponseModel> ChangePasswordAsync(ChangePasswordRequest request, string username);
        Task<ResponseModel> GenerateForgetPasswordTokenAsync(ForgetPasswordRequest request);
        Task<ResponseModel> ResetPasswordAsync(string userName, string token);
        Task<ResponseModel> ResetPasswordByAdminAsync(string userName, string newPassword);
        Task<ResponseModel> AddClaimAsync(AddClaimRequest claim, string username);
        Task<ResponseModel> RemoveClaimAsync(NewClaimRequest claim, string username);
        Task<ResponseModel> AddClaimsAsync(IEnumerable<NewClaimRequest> claims, string username);
        Task<ResponseModel> RemoveClaimsAsync(IEnumerable<NewClaimRequest> claims, string username);
        Task<ResponseModel> AddUserToRoleAsync(string role, string username);
        Task<ResponseModel> RemoveUserFromRoleAsync(string role, string username);
        Task<ResponseModel> AddUserToRolesAsync(AddUserToRolesRequest request, string username);
        Task<ResponseModel> RemoveUserFromRolesAsync(AddUserToRolesRequest request, string username);
        Task<ResponseModel<Claim>> GetUserClaimsAsync(GetUserClaimsRequest request);
        Task<ResponseModel<GetAllUsersResponse>> GetAllNewClientsAsync(bool confirmByAdmin);
        Task<ResponseModel<string>> GetUserRolesAsync(GetUserRolesRequest request);
        Task<ResponseModel<GetRoleUsersResponse>> GetRoleUsersAsync(GetRoleUsersRequest request);
        Task<ResponseModel<GetAllRolesResponse>> GetAllRolesAsync();
        Task<ResponseModel<UserManagementReposne>> GetAllUsersAsync(string phrase);
        Task<ResponseModel<GetAllRoleClaimsResponse>> GetAllRoleClaimsAsync();
        Task<ResponseModel<GetAllUserClaimsResponse>> GetAllUserClaimsAsync();
    }
}
