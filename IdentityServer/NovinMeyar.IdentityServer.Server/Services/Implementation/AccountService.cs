using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using NovinMeyar.IdentityServer.DataLayer;
using IdentityServer4.Models;
using IdentityModel.Client;
using MassTransit;
using NovinMeyar.Common.MessageBrokers;
using NovinMeyar.IdentityServer.Domain.Entities;
using NovinMeyar.IdentityServer.Domain.View;
using NovinMeyar.IdentityServer.Domain.DTO;
using NovinMeyar.Common;
using NovinMeyar.IdentityServer.Domain;
using System.Threading;

namespace NovinMeyar.IdentityServer.Server.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger logger;
        public IConfiguration configuration { get; }
        private ApplicationDbContext dbContext;
        private readonly IRequestClient<InstallatinCompanyBroker> installatinCompanyClient;
        private readonly IRequestClient<RemoveInstallationCompanyBroker> removeInstallatinCompanyClient;
        private readonly IRequestClient<VerificationCodeBroker> verificationCodeClient;
        private readonly IRequestClient<Common.MessageBrokers.CustomMessageBroker> messageBrokerClient;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;

        public AccountService(SignInManager<ApplicationUser> signInManager,
                              IConfiguration configuration,
                              ILogger logger,
                              ApplicationDbContext dbContext,
                              IRequestClient<InstallatinCompanyBroker> installatinCompanyClient,
                              IRequestClient<RemoveInstallationCompanyBroker> removeInstallatinCompanyClient,
                              IRequestClient<VerificationCodeBroker> verificationCodeClient,
                               IRequestClient<Common.MessageBrokers.CustomMessageBroker> messageBrokerClient,
                               IPasswordHasher<ApplicationUser> passwordHasher)
        {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.logger = logger;
            this.dbContext = dbContext;
            this.installatinCompanyClient = installatinCompanyClient;
            this.removeInstallatinCompanyClient = removeInstallatinCompanyClient;
            this.verificationCodeClient = verificationCodeClient;
            this.messageBrokerClient = messageBrokerClient;
            this.passwordHasher = passwordHasher;
        }

        public async Task<IEnumerable<UserAccessLevelVM>> GetAccessLevelsAsync(string userName, string roleName)
        {
            var roleClaims = await (from rc in dbContext.RoleClaims
                                    join r in dbContext.Roles on rc.RoleId equals r.Id
                                    where r.Name == roleName &&
                                          rc.ClaimType == "Permission"
                                    select new UserAccessLevelVM
                                    {
                                        Id = rc.Id,
                                        AccessType = "Role",
                                        ClaimType = rc.ClaimType,
                                        ClaimValue = rc.ClaimValue
                                    }).ToListAsync();

            var userClaims = await (from uc in dbContext.UserClaims
                                    join u in dbContext.Users on uc.UserId equals u.Id
                                    where u.UserName == userName
                                    select new UserAccessLevelVM
                                    {
                                        Id = uc.Id,
                                        AccessType = "User",
                                        ClaimType = uc.ClaimType,
                                        ClaimValue = uc.ClaimValue
                                    }).ToListAsync();

            return roleClaims.Union(userClaims);
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request, string baseUrl)
        {
            var validationResponse = LoginValidation(request);
            if (!validationResponse.Succeed)
                return validationResponse;

            var response = new LoginResponse()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.OK
            };

            try
            {
                var user = await signInManager.UserManager.FindByNameAsync(request.Username).ConfigureAwait(false);
                if (user == null)
                {
                    response.Message = MessageTemplates.IncorrectUserNameOrPassword;
                    return response;
                }

                if (!user.IsActive)
                {
                    response.Message = MessageTemplates.AccountDeactivated;
                    return response;
                }

                if (user.LockoutEnd != null)
                {
                    response.Message = MessageTemplates.ExpiredUser;
                    return response;
                }

                var result = await signInManager.PasswordSignInAsync(user, request.Password, request.RememberLogin, lockoutOnFailure: true).ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    response.Message = MessageTemplates.IncorrectUserNameOrPassword;
                    return response;
                }

                if (result.IsLockedOut)
                {
                    response.Message = MessageTemplates.AccountLocked;
                    return response;
                }

                response.Succeed = true;
                response.Claims = await GetUserClaims(user);
                response.Message = MessageTemplates.LoginSuccessfully;
                var tokenResponse = await GetAccessToken(new Domain.DTO.TokenRequest
                {
                    client_id = request.ClientId,
                    username = request.Username,
                    password = request.Password,
                    grant_type = GrantType.ResourceOwnerPassword
                }, baseUrl);

                if (!tokenResponse.IsError)
                {
                    response.TokenType = tokenResponse.TokenType;
                    response.AccessToken = tokenResponse.AccessToken;
                    response.RefreshToken = tokenResponse.RefreshToken;
                    response.ConfirmByAdmin = user.ConfirmByAdmin;
                    response.ExpireDate = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn);
                    response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.HttpStatusCode = System.Net.HttpStatusCode.Unauthorized;
                    response.Message = tokenResponse.Error;
                    response.Succeed = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(LoginAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }

        public async Task<ResponseModel> LogoutAsync()
        {
            await signInManager.SignOutAsync();
            return new ResponseModel { Succeed = true };
        }

        public async Task<ResponseModel> RegisterClientAsync(RegisterClient client)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            int installationCompanyId = 0;

            var executionStrategy = dbContext.Database.CreateExecutionStrategy();

            return await executionStrategy.Execute(async
                () =>
            {
                // execute your logic here
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var newInstallationCompany = new InstallatinCompanyBroker
                        {
                            Name = client.CompanyName,
                            Deleted = false,
                            NationalNo = client.NationalCode,
                            RegistrationNo = client.RegisterNo,
                            CreateDate = DateTime.Now
                        };

                        //Publish message for register new installation company.
                        var registerInstallationCompanyResult = await installatinCompanyClient.GetResponse<ResponseModel>(newInstallationCompany);
                        if (!registerInstallationCompanyResult.Message.Succeed)
                            throw new Exception(registerInstallationCompanyResult.Message.Message);

                        installationCompanyId = Convert.ToInt32(registerInstallationCompanyResult.Message.Data);

                        var user = new ApplicationUser
                        {
                            UserName = client.Username,
                            FirstName = client.CompanyName,
                            LastName = client.CompanyName,
                            PhoneNumber = client.Username,
                            PhoneNumberConfirmed = false,
                            IsActive = false
                        };

                        var currentUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == client.Username && x.IsActive);
                        if (currentUser != null)
                        {
                            response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                            response.Message = MessageTemplates.CreateUserSuccessfully;
                            response.Succeed = true;
                            return response;
                        }

                        var result = await signInManager.UserManager.CreateAsync(user, client.Password).ConfigureAwait(false);
                        if (result.Succeeded)//Add user to a role
                        {
                            var role = await dbContext.Roles.FirstAsync(x => x.Name == AssessorsManager.Client);
                            await dbContext.UserRoles.AddAsync(new UserRole { RoleId = role.Id, UserId = user.Id });
                            await AddClaimsAsync(new List<NewClaimRequest>
                                {
                                    new NewClaimRequest { ClaimType = "FirstName", ClaimValue = user.FirstName },
                                    new NewClaimRequest { ClaimType = "LastName", ClaimValue = user.LastName },
                                    new NewClaimRequest { ClaimType = "InstallationCompanyName", ClaimValue = newInstallationCompany.Name },
                                    new NewClaimRequest { ClaimType = "InstallationCompanyId", ClaimValue = installationCompanyId.ToString() },
                                    new NewClaimRequest { ClaimType = "RoleName", ClaimValue = role.Name }
                                }, user.UserName);

                            await dbContext.SaveChangesAsync();
                            transaction.Commit();
                            response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                            response.Message = MessageTemplates.CreateUserSuccessfully;
                            response.Succeed = true;
                            return response;
                        }

                        transaction.Rollback();
                        response.Message = ExtractErrorMessage(result);
                        response.Succeed = result.Succeeded;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(RegisterClientAsync)));
                        //undo
                        var removeInstallationCompany = await removeInstallatinCompanyClient.GetResponse<ResponseModel>(new RemoveInstallationCompanyBroker { Id = installationCompanyId });
                        if (!removeInstallationCompany.Message.Succeed)
                            logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, $"با خطا مواجه گردید. جزییات خطا{removeInstallationCompany.Message.Message} {installationCompanyId} عملیات حذف شرکت فروشنده با شناسه", nameof(RegisterClientAsync)));
                        response.Message = ex.Message.ToString();
                        response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                    }
                    return response;
                }
            });
        }
        public async Task<ResponseModel> VerifyRegisterationCode(VerifyCode verifyCode)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (verifyCode == null)
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(verifyCode.UserName.Trim()).ConfigureAwait(false);
                if (user != null)
                {
                    var isValid = BCrypt.Net.BCrypt.Verify(verifyCode.PlainCode, user.ConfirmationPhoneNumberCode);
                    if (!isValid)
                    {
                        response.Message = "کد تایید صحیح نمی باشد";
                        return response;
                    }

                    user.IsActive = true;
                    user.PhoneNumberConfirmed = user.IsActive;
                    user.PhoneNumberConfirmed = user.IsActive;

                    await signInManager.UserManager.UpdateAsync(user);

                    response.Message = MessageTemplates.ConfirmationUserSuccessfully;
                    response.Succeed = true;
                    return response;
                }

                response.Message = MessageTemplates.IncorrectUserName;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(VerifyRegisterationCode)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> SendVerificationCode(string mobile, string verifyCode, CancellationToken cancellationToken)
        {
            var response = await verificationCodeClient.GetResponse<ResponseModel>(new VerificationCodeBroker { Code = verifyCode, Mobile = $"0{mobile.TrimStart('0')}" }, cancellationToken, int.MaxValue);
            if (!response.Message.Succeed)
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, $"با خطا مواجه گردید. جزییات خطا{response.Message.Message} {verifyCode} عملیات ارسال پیام با کد", nameof(SendVerificationCode)));
            return response.Message;
        }
        public async Task<ResponseModel> GenerateSmsConfirmationTokenAsync(string userName)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (string.IsNullOrEmpty(userName))
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(userName.Trim()).ConfigureAwait(false);
                if (user != null)
                {
                    var rnd = new Random();
                    var digit = rnd.Next(10000, 99999);
                    var hashedDigit = BCrypt.Net.BCrypt.HashPassword(digit.ToString());
                    user.ConfirmationPhoneNumberCode = hashedDigit;
                    await signInManager.UserManager.UpdateAsync(user);
                    response.Data = digit.ToString();
                    response.Succeed = true;
                    return response;
                }

                response.Message = MessageTemplates.IncorrectUserName;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(GenerateSmsConfirmationTokenAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> VerifyClientByAdmin(Guid userId)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (userId == Guid.Empty)
                    return response;

                var user = await signInManager.UserManager.FindByIdAsync(userId.ToString()).ConfigureAwait(false);
                if (user == null)
                {
                    response.Message = MessageTemplates.IncorrectUserName;
                    return response;
                }

                //Confirm user by admin
                user.ConfirmByAdmin = true;
                await signInManager.UserManager.UpdateAsync(user);
                await messageBrokerClient.GetResponse<ResponseModel>(new CustomMessageBroker
                {
                    MobileNumber = user.UserName.PadLeft(11, '0'),
                    TextMessage = "کاربر محترم نام کاربری شرکت شما در سامانه جامع بازرسی شرکت نوین معیار فعال گردید"
                });
                response.Message = MessageTemplates.ConfirmationUserByAdminSuccessfully;
                response.Succeed = true;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(GenerateSmsConfirmationTokenAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> GenerateForgetPasswordTokenAsync(ForgetPasswordRequest request)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (string.IsNullOrEmpty(request.Username))
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(request.Username.Trim()).ConfigureAwait(false);
                if (user != null)
                {
                    response.Message = await signInManager.UserManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false);
                    response.Succeed = true;
                    return response;
                }

                response.Message = MessageTemplates.IncorrectUserName;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(GenerateForgetPasswordTokenAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> ChangePasswordAsync(ChangePasswordRequest request, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);
                var result = await signInManager.UserManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword).ConfigureAwait(false);
                if (!result.Succeeded)
                {
                    var sb = new StringBuilder();
                    foreach (var error in result.Errors)
                        sb.Append($"{error.Description} \n");
                    response.Message = sb.ToString();
                    return response;
                }

                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                response.Message = MessageTemplates.ChangedPasswordSuccessfully;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(ChangePasswordAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        public async Task<ResponseModel> ResetPasswordByAdminAsync(string userName, string newPassword)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                var user = await signInManager.UserManager.FindByNameAsync(userName.Trim()).ConfigureAwait(false);
                if (user == null)
                {
                    response.Message = "کاربر مورد نظر یافت نشد";
                    return response;
                }

                user.PasswordHash = passwordHasher.HashPassword(user, newPassword);
                await signInManager.UserManager.UpdateAsync(user);

                await messageBrokerClient.GetResponse<ResponseModel>(new CustomMessageBroker
                {
                    MobileNumber = user.UserName.PadLeft(11, '0'),
                    TextMessage = $"کاربر گرامی جناب {user.FirstName} {user.LastName} کلمه عبور شما با موفقیت به Aa@123456 بازنشانی گردید. لطفا پس از ورود به سامانه نسبت به تغییر آن اقدام نمایید."
                });

                response.Succeed = true;
                response.Message = "بازنشانی نام کاربری با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(ResetPasswordAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> UnlockUserByAdminAsync(string userName)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                var user = await signInManager.UserManager.FindByNameAsync(userName.Trim()).ConfigureAwait(false);
                if (user == null)
                {
                    response.Message = "کاربر مورد نظر یافت نشد";
                    return response;
                }

                user.LockoutEnd = null;
                user.AccessFailedCount = 0;
                await signInManager.UserManager.UpdateAsync(user);
                await signInManager.RefreshSignInAsync(user).ConfigureAwait(false);

                response.Succeed = true;
                response.Message = "فعالسازی کاربر با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(ResetPasswordAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> ResetPasswordAsync(string userName, string token)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                var user = await signInManager.UserManager.FindByNameAsync(userName.Trim()).ConfigureAwait(false);

                if (user != null)
                {
                    var result = await signInManager.UserManager.ResetPasswordAsync(user, token, "Aa@123456").ConfigureAwait(false);
                    if (result.Succeeded)
                    {
                        response.Succeed = result.Succeeded;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = MessageTemplates.ResetPasswordSuccessfully;
                        return response;
                    }

                    throw new Exception(ExtractErrorMessage(result));
                }

                response.Message = MessageTemplates.IncorrectUserName;

            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(ResetPasswordAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> DeactivateUserAsync(Guid UserId)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (UserId == Guid.Empty)
                    return response;

                var user = await signInManager.UserManager.FindByIdAsync(UserId.ToString()).ConfigureAwait(false);
                var result = await signInManager.UserManager.DeleteAsync(user).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    response.Succeed = result.Succeeded;
                    response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    response.Message = MessageTemplates.RemovedUser;
                    return response;
                }

                throw new Exception(ExtractErrorMessage(result));
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(DeactivateUserAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> AddClaimAsync(AddClaimRequest claim, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (string.IsNullOrEmpty(claim.NewClaimRequest.ClaimType) || string.IsNullOrEmpty(claim.NewClaimRequest.ClaimValue))
                    return response;


                bool hasDuplicate = false;
                if (claim.NewClaimRequest.AccessType.ToLower() == "role")
                {


                    var role = await dbContext.Roles.Where(t => t.Name == claim.UsernameOrRolename).FirstOrDefaultAsync().ConfigureAwait(false);
                    bool hasPermission = await dbContext.RoleClaims.AnyAsync(t => t.RoleId == role.Id && t.ClaimValue == claim.NewClaimRequest.ClaimValue && t.ClaimType == claim.NewClaimRequest.ClaimType).ConfigureAwait(false);
                    if (!hasPermission)
                    {
                        await dbContext.RoleClaims.AddAsync(new RoleClaim()
                        {
                            ClaimType = claim.NewClaimRequest.ClaimType
                                            ,
                            ClaimValue = claim.NewClaimRequest.ClaimValue
                                             ,
                            RoleId = role.Id
                        });
                        await dbContext.SaveChangesAsync();
                        response.Message = MessageTemplates.AddUserToRoleSuccessfully;

                    }
                    else
                    {
                        hasDuplicate = true;

                    }

                }
                else
                {
                    var user = await signInManager.UserManager.FindByNameAsync(claim.UsernameOrRolename).ConfigureAwait(false);
                    bool hasPermission = await dbContext.UserClaims.AnyAsync(t => t.UserId == user.Id && t.ClaimValue == claim.NewClaimRequest.ClaimValue && t.ClaimType == claim.NewClaimRequest.ClaimType).ConfigureAwait(false);
                    if (!hasPermission)
                    {
                        await signInManager.UserManager.AddClaimAsync(user, new Claim(claim.NewClaimRequest.ClaimType, claim.NewClaimRequest.ClaimValue)).ConfigureAwait(false);
                        response.Message = MessageTemplates.AddClaimToUserSuccessfully;

                    }
                    else
                    {
                        hasDuplicate = true;

                    }

                }


                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                if (hasDuplicate)
                {
                    response.Message = "دسترسی تکراری است";
                    response.Succeed = false;
                }
                else
                {
                    response.Succeed = true;


                }
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(AddClaimAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> RemoveClaimAsync(NewClaimRequest claim, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (string.IsNullOrEmpty(claim.ClaimType) ||
                    string.IsNullOrEmpty(claim.ClaimValue) ||
                    string.IsNullOrEmpty(claim.AccessType) ||
                    claim.Id <= 0)
                    return response;

                if (claim.AccessType == "Role")
                {
                    var roleClaim = await dbContext.RoleClaims.FindAsync(claim.Id);
                    dbContext.RoleClaims.Remove(roleClaim);
                }
                else
                {
                    var userClaim = await dbContext.UserClaims.FindAsync(claim.Id);
                    dbContext.UserClaims.Remove(userClaim);
                }

                await dbContext.SaveChangesAsync();

                response.Succeed = true;
                response.Message = MessageTemplates.RemoveUserClaimSuccessfully;
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(RemoveClaimAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> AddClaimsAsync(IEnumerable<NewClaimRequest> claims, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (claims.Any(x => x.ClaimType == null) || claims.Any(x => x.ClaimValue == null))
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);

                var _claims = new List<Claim>();
                foreach (var claim in claims)
                    _claims.Add(new Claim(claim.ClaimType, claim.ClaimValue));

                var result = await signInManager.UserManager.AddClaimsAsync(user, _claims).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    response.Succeed = result.Succeeded;
                    response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    response.Message = MessageTemplates.AddClaimsToUserSuccessfully;
                    return response;
                }

                throw new Exception(ExtractErrorMessage(result));
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(AddClaimsAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> RemoveClaimsAsync(IEnumerable<NewClaimRequest> claims, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (claims.Any(x => x.ClaimType == null) || claims.Any(x => x.ClaimValue == null))
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);

                var _claims = new List<Claim>();
                foreach (var claim in claims)
                    _claims.Add(new Claim(claim.ClaimType, claim.ClaimValue));

                var result = await signInManager.UserManager.RemoveClaimsAsync(user, _claims).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    response.Succeed = result.Succeeded;
                    response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    response.Message = MessageTemplates.RemoveUserClaimsSuccessfully;
                    return response;
                }

                throw new Exception(ExtractErrorMessage(result));
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(RemoveClaimsAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> AddUserToRoleAsync(string role, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (role is null)
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);

                if (user != null)
                {
                    var result = await signInManager.UserManager.AddToRoleAsync(user, role).ConfigureAwait(false);

                    if (result.Succeeded)
                    {
                        response.Succeed = result.Succeeded;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = MessageTemplates.AddUserToRoleSuccessfully;
                        return response;
                    }

                    throw new Exception(ExtractErrorMessage(result));
                }

                response.Message = MessageTemplates.IncorrectUserName;
                response.HttpStatusCode = System.Net.HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(AddUserToRoleAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> RemoveUserFromRoleAsync(string role, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (role is null)
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);

                if (user != null)
                {
                    var result = await signInManager.UserManager.RemoveFromRoleAsync(user, role).ConfigureAwait(false);

                    if (result.Succeeded)
                    {
                        response.Succeed = result.Succeeded;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = MessageTemplates.RemoveUserFromRoleSuccessfully;
                        return response;
                    }

                    throw new Exception(ExtractErrorMessage(result));
                }

                response.Message = MessageTemplates.IncorrectUserName;
                response.HttpStatusCode = System.Net.HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(RemoveUserFromRoleAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> AddUserToRolesAsync(AddUserToRolesRequest request, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (!request.Roles.Any())
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);

                if (user != null)
                {
                    var result = await signInManager.UserManager.AddToRolesAsync(user, request.Roles).ConfigureAwait(false);

                    if (result.Succeeded)
                    {
                        response.Succeed = result.Succeeded;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = MessageTemplates.AddUserToRolesSuccessfully;
                        return response;
                    }

                    throw new Exception(ExtractErrorMessage(result));
                }

                response.Message = MessageTemplates.IncorrectUserName;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(AddUserToRolesAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel> RemoveUserFromRolesAsync(AddUserToRolesRequest request, string username)
        {
            var response = new ResponseModel()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            try
            {
                if (!request.Roles.Any())
                    return response;

                var user = await signInManager.UserManager.FindByNameAsync(username).ConfigureAwait(false);

                if (user != null)
                {
                    var result = await signInManager.UserManager.RemoveFromRolesAsync(user, request.Roles).ConfigureAwait(false);

                    if (result.Succeeded)
                    {
                        response.Succeed = result.Succeeded;
                        response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = MessageTemplates.RemoveUserFromRolesSuccessfully;
                        return response;
                    }

                    throw new Exception(ExtractErrorMessage(result));
                }

                response.Message = MessageTemplates.IncorrectUserName;
                response.HttpStatusCode = System.Net.HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format(MessageTemplates.RaisedError, DateTime.Now, ex.Message, nameof(RemoveUserFromRolesAsync)));
                response.Message = ex.Message.ToString();
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
        public async Task<ResponseModel<Claim>> GetUserClaimsAsync(GetUserClaimsRequest request)
        {
            var response = new ResponseModel<Claim>()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            if (request == null)
                return response;

            var user = await signInManager.UserManager.FindByNameAsync(request.UserName).ConfigureAwait(false);
            if (user != null)
            {
                var claims = await signInManager.UserManager.GetClaimsAsync(user).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(request.ClaimType))
                {
                    claims = claims.Where(x => x.Type == request.ClaimType).ToList();
                }

                response.ResponseList = claims;
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }

            response.Message = MessageTemplates.IncorrectUserName;
            return response;
        }
        public async Task<ResponseModel<string>> GetUserRolesAsync(GetUserRolesRequest request)
        {
            var response = new ResponseModel<string>()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.BadRequest
            };

            if (request == null)
                return response;

            var user = await signInManager.UserManager.FindByNameAsync(request.UserName).ConfigureAwait(false);
            if (user != null)
            {
                var roles = await signInManager.UserManager.GetRolesAsync(user).ConfigureAwait(false);
                response.ResponseList = roles;
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }

            response.Message = MessageTemplates.IncorrectUserName;
            return response;
        }
        public async Task<ResponseModel<GetRoleUsersResponse>> GetRoleUsersAsync(GetRoleUsersRequest request)
        {
            var response = new ResponseModel<GetRoleUsersResponse>()
            {
                Succeed = false,
                HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
            };

            if (request == null)
                return response;

            var users = await signInManager.UserManager.GetUsersInRoleAsync(request.RoleName).ConfigureAwait(false);
            if (users != null)
            {
                response.ResponseList = users.Select(x =>
                {
                    return new GetRoleUsersResponse
                    {
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PhoneNumber = x.PhoneNumber,
                        DateOfBirth = x.DateOfBirth,
                        Email = x.Email,
                        ImageUrl = x.ImageUrl,
                        IsActive = x.IsActive
                    };
                });
                response.Succeed = true;
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }

            response.Message = MessageTemplates.InvalidRoleName;
            return response;
        }
        public async Task<ResponseModel<GetAllRolesResponse>> GetAllRolesAsync() => new ResponseModel<GetAllRolesResponse>
        {
            Succeed = true,
            HttpStatusCode = System.Net.HttpStatusCode.OK,
            ResponseList = await dbContext.Roles.
                                    Where(x => x.Name != AssessorsManager.Root &&
                                          x.Name != AssessorsManager.Administrator)
            .Select(x => new GetAllRolesResponse
            {
                Id = x.Id,
                RoleName = x.Name
            }).ToListAsync()
        };
        public async Task<ResponseModel<UserManagementReposne>> GetAllUsersAsync(string phrase) => new ResponseModel<UserManagementReposne>
        {
            Succeed = true,
            HttpStatusCode = System.Net.HttpStatusCode.OK,
            ResponseList = await (from u in dbContext.Users
                                  join ur in dbContext.UserRoles on u.Id equals ur.UserId
                                  join r in dbContext.Roles on ur.RoleId equals r.Id
                                  where r.Name != AssessorsManager.Root &&
                                        r.Name != AssessorsManager.Administrator &&
                                        (phrase == null || phrase == "null" || (
                                            u.FirstName.Contains(phrase) ||
                                            u.LastName.Contains(phrase) ||
                                            u.UserName.Contains(phrase) ||
                                            r.LocalName.Contains(phrase))
                                         )
                                  select new UserManagementReposne
                                  {
                                      Id = u.Id,
                                      RoleId = r.Id,
                                      UserName = u.UserName,
                                      FirstName = u.FirstName,
                                      LastName = u.LastName,
                                      BirthDate = u.DateOfBirth,
                                      LocalRoleName = r.LocalName,
                                      RoleName = r.Name
                                  }
                                  ).OrderBy(x => x.LocalRoleName).ToListAsync()
        };
        public async Task<ResponseModel> UpdateUserAsync(UserManagementReposne userManagement)
        {
            var response = new ResponseModel { Succeed = false };

            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userManagement.Id);
                if (user == null)
                {
                    response.Message = "کاربر مورد نظر یافت نشد";
                    return response;
                }

                user.FirstName = userManagement.FirstName;
                user.LastName = userManagement.LastName;
                user.UserName = userManagement.UserName;
                user.DateOfBirth = userManagement.BirthDate;

                var userRole = await dbContext.UserRoles.FirstOrDefaultAsync(x => x.UserId == userManagement.Id);
                var role = await dbContext.Roles.FindAsync(userManagement.RoleId);
                dbContext.UserRoles.Remove(userRole);
                await dbContext.UserRoles.AddAsync(new UserRole { RoleId = userManagement.RoleId, UserId = userManagement.Id });

                var userClaim = await dbContext.UserClaims.FirstOrDefaultAsync(x=> x.UserId==userManagement.Id && x.ClaimType== "RoleName");
                if(userClaim != null)
                    dbContext.UserClaims.Remove(userClaim);
                await dbContext.UserClaims.AddAsync(new UserClaim { UserId = userManagement.Id, ClaimType= "RoleName", ClaimValue = role.Name });

                await dbContext.SaveChangesAsync();
                response.Succeed = true;
                response.Message = "اطلاعات کاربر جاری با موفقیت ویرایش گردید";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ResponseModel<GetAllUsersResponse>> GetAllNewClientsAsync(bool confirmByAdmin = false)
        {
            var users = await (from u in dbContext.Users
                               join ur in dbContext.UserRoles on u.Id equals ur.UserId
                               join r in dbContext.Roles on ur.RoleId equals r.Id
                               where r.Name == AssessorsManager.Client &&
                                     u.ConfirmByAdmin == confirmByAdmin &&
                                     u.IsActive
                               select new GetAllUsersResponse
                               {
                                   Id = u.Id,
                                   UserName = u.UserName,
                                   FullName = (u.FirstName + " " + u.LastName)
                               }).ToListAsync();

            foreach (var user in users)
            {
                var claim = await dbContext.UserClaims.FirstOrDefaultAsync(x => x.UserId == user.Id && x.ClaimType == "InstallationCompanyId");
                if (claim != null)
                {
                    var installationComapnyId = int.Parse(claim.ClaimValue);
                    var installationComapnyName = dbContext.UserClaims.First(x => x.UserId == user.Id && x.ClaimType == "InstallationCompanyName").ClaimValue;
                    user.InstallationCompanyId = installationComapnyId;
                    user.InstallationCompanyName = installationComapnyName;
                }
            }

            return new ResponseModel<GetAllUsersResponse>
            {
                Succeed = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ResponseList = users
            };
        }
        public async Task<ResponseModel<GetAllRoleClaimsResponse>> GetAllRoleClaimsAsync()
        {
            var query = from rc in dbContext.RoleClaims
                        join r in dbContext.Roles on rc.RoleId equals r.Id
                        orderby r.Name
                        select new GetAllRoleClaimsResponse
                        {
                            Id = rc.Id,
                            RoleName = r.Name,
                            ClaimType = rc.ClaimType,
                            ClaimValue = rc.ClaimValue
                        };

            return new ResponseModel<GetAllRoleClaimsResponse>
            {
                Succeed = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ResponseList = await query.ToListAsync()
            };
        }
        public async Task<ResponseModel<GetAllUserClaimsResponse>> GetAllUserClaimsAsync()
        {
            var query = from uc in dbContext.UserClaims
                        join u in dbContext.Users on uc.UserId equals u.Id
                        orderby u.UserName
                        select new GetAllUserClaimsResponse
                        {
                            Id = uc.Id,
                            UserName = u.UserName,
                            ClaimType = uc.ClaimType,
                            ClaimValue = uc.ClaimValue
                        };

            return new ResponseModel<GetAllUserClaimsResponse>
            {
                Succeed = true,
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                ResponseList = await query.ToListAsync()
            };
        }

        #region Private methods

        private async Task<IEnumerable<Claim>> GetUserClaims(ApplicationUser user) => await signInManager.UserManager.GetClaimsAsync(user).ConfigureAwait(false);
        private async Task<ResponseModel> AddUserToRole(ApplicationUser user, string roleName)
        {
            var response = new ResponseModel
            {
                Succeed = true
            };

            var result = await signInManager.UserManager.AddToRoleAsync(user, roleName).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                response.Succeed = false;
                response.Message = ExtractErrorMessage(result);
            }

            return response;
        }
        private LoginResponse LoginValidation(LoginRequest request)
        {
            var response = new LoginResponse()
            {
                Message = string.Empty,
                Succeed = true
            };
            if (request == null ||
                request.Username == null ||
                request.Password == null)
            {
                response.Message = "نام کاربری اشتباه می باشد";
                response.Succeed = false;
            }

            return response;
        }

        private string ExtractErrorMessage(IdentityResult identityResult)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var error in identityResult.Errors)
            {
                switch (error.Code)
                {
                    case "PasswordRequiresLower":
                        error.Description = "کلمه عبور شما باید حداقل شامل یک حرف کوچک انگلیسی باشد";
                        break;
                    case "PasswordRequiresUpper":
                        error.Description = "کلمه عبور شما باید حداقل شامل یک حرف بزرگ انگلیسی باشد";
                        break;
                    case "DuplicateUserName":
                        error.Description = "این نام کاربری قبلا در سیستم ثبت نام کرده است";
                        break;
                }
                sb.Append($"{error.Code} --> {error.Description}");
            }
            return sb.ToString();
        }
        public async Task<IdentityModel.Client.TokenResponse> GetAccessToken(Domain.DTO.TokenRequest request, string baseUrl)
        {
            var handler = new HttpClientHandler() { UseDefaultCredentials = false };
            //handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            return await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = baseUrl,
                UserName = request.username,
                Password = request.password,
                ClientId = request.client_id,
                GrantType = GrantType.ResourceOwnerPassword
            }).ConfigureAwait(false);
        }

        #endregion
    }
}