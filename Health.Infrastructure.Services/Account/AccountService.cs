using Health.Core.Domain.Identity;
using Health.Core.Framework.Account.Authentication;
using Health.Core.Framework.Account.Users;
using Health.Core.Interfaces.Services;
using Health.Core.Interfaces.Services.Entities.Identity;
using Health.Core.Types.Enums;
using Health.Core.Types.Exceptions;
using Health.DataAccessLayer;
using Ideo.NetCore.Data.Encryption.AES.Configuration;
using Ideo.NetCore.Data.Encryption.Core.Interfaces;
using Ideo.NetCore.Framework.Generators.TemplateGenerator.Core.Interfaces;
using Ideo.NetCore.Framework.Mail.Smtp.Core.Interfaces;
using Ideo.NetCore.Framework.Sms.Core.Interfaces;
using Ideo.NetCore.Web.Security.Authentication;
using Ideo.NetCore.Web.Security.Authentication.Core.Models;
using Ideo.NetCore.Web.Security.Authentication.RefreshToken.Core.Domain;
using Ideo.NetCore.Web.Security.Authentication.RefreshToken.Core.Interfaces;
using Ideo.NetCore.Web.Security.Authentication.RefreshToken.Framework;
using Ideo.NetCore.Web.Security.TwoFA.OTP.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Health.Infrastructure.Services.Account
{
    internal class AccountService : IAccountService
    {
        #region Fields
        private readonly ILogger<AccountService> _logger;
        private readonly IUnitOfWork _uow;
        private readonly IUsersService _usersService;
        private readonly IOtpService _otpService;
        private readonly IHttpContextAccessor _actionContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly ITemplatesService _templatesService;
        private readonly IEnumerable<ITemplateGenerator> _templateGenerators;
        private readonly IRefreshTokensService<long> _refreshTokensService;
        private readonly IOptions<JwtConfig> _jwtConfig;
        //private readonly ILocaleResourcesService _localeResourcesService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IIdeoSmtpService _smtpService;
        private readonly ISmsService<ISmsProviderConfiguration> _smsService;
        private readonly IEncryptionService<AES> _encryptionService;
        private readonly string _baseAppUrl;
        #endregion

        public AccountService(ILogger<AccountService> logger,
            IUnitOfWork uow,
            IConfiguration configuration,
            IUsersService usersService,
            IOtpService otpService,
            IHttpContextAccessor actionContextAccessor,
            UserManager<ApplicationUser> userManager,
            //ITemplatesService templatesService,
            IEnumerable<ITemplateGenerator> templateGenerators,
            IRefreshTokensService<long> refreshTokensService,
            IOptions<JwtConfig> jwtConfig,
            //ILocaleResourcesService localeResourcesService,
            IHttpContextAccessor contextAccessor,
            IIdeoSmtpService smtpService,
            ISmsService<ISmsProviderConfiguration> smsService,
            IEncryptionService<AES> encryptionService)
        {
            this._logger = logger;
            this._uow = uow;
            this._usersService = usersService;
            this._otpService = otpService;
            this._actionContextAccessor = actionContextAccessor;
            this._userManager = userManager;
            //this._templatesService = templatesService;
            this._templateGenerators = templateGenerators;
            this._refreshTokensService = refreshTokensService;
            this._jwtConfig = jwtConfig;
            //this._localeResourcesService = localeResourcesService;
            this._contextAccessor = contextAccessor;
            this._smtpService = smtpService;
            this._smsService = smsService;
            this._encryptionService = encryptionService;
            this._baseAppUrl = configuration.GetSection("PortalBaseUrl")?.Value;
        }

        public async Task<AuthenticationResponseLogicModel> Refresh(RefreshTokenRequestLogicModel request)
        {
            var refreshToken = await _refreshTokensService.Refresh(request);
            if (refreshToken != null && refreshToken.UserId != default)
            {
                var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.Id == refreshToken.UserId, includeProperties: new[] { "Roles.Role" });
                if (user != null)
                {
                    return await GenerateToken(user, refreshToken, refreshToken.Jti);
                }
            }
            return null;
        }

        //public async Task<UserLogicModel> RegisterUser(UserRegistrationLogicModel request)
        //{
        //    var user = await _usersService.Create(request);
        //    var subject = (await _localeResourcesService.Get(0, 1, x => x.Name == "EmailTemplates.Customers.Welcome.Title")).FirstOrDefault();
        //    var template = await _templatesService.Get("WSI.Infrastructure.TemplateGenerators.Email.Customers.WelcomeTemplateGenerator", TemplateType.Email);
        //    var generator = _templateGenerators.FirstOrDefault(z => z.Type == template.Type && z.TemplateType == template.TemplateType);
        //    var generatorResponse = await generator.Generate(1, template.LastValue.Value, user);
        //    var message = new EmailMessageModel
        //    {
        //        To = new KeyValuePair<string, string>(user.Email, $"{user?.FirstName} {user?.LastName}"),
        //        Body = generatorResponse,
        //        Subject = subject.Value
        //    };
        //    try
        //    {
        //        _smtpService.Send(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("send mail failed", ex);
        //    }
        //    return user;
        //}

        public async Task<AuthenticationResponseLogicModel> Validate(AuthenticationRequestLogicModel request)
        {
            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role" });
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                if ((!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now) && user.AccessFailedCount < 5)
                {
                    if (user.PhoneNumberConfirmed && user.TwoFactorEnabled)
                    {
                        user.AccessFailedCount = 0;
                        await _uow.SaveAsync();
                        //return await GenerateToken(user);

                        //var template = await _templatesService.Get("WSI.Infrastructure.TemplateGenerators.Sms.Security.OtpCodeTemplateGenerator", TemplateType.Sms);
                        //var generator = _templateGenerators.FirstOrDefault(z => z.Type == template.Type && z.TemplateType == template.TemplateType);

                        //Func<string, string> templateGeneratorActivator = null;
                        //if (generator != null)
                        //{
                        //    templateGeneratorActivator = (x) => generator.Generate(1, template.LastValue.Value, new OtpCodeEntity { OtpCode = x }).Result;
                        //}

                        //var sent = await this._otpService.SendOtp(null, user.PhoneNumber, templateGeneratorActivator);
                        //if (sent)
                        //{
                        //    return new AuthenticationResponseLogicModel
                        //    {
                        //        Type = "2FA"
                        //    };
                        //}
                    }
                    else
                    {
                        return await GenerateToken(user);
                    }
                }
                throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
            }

            return null;
        }

        public async Task<AuthenticationResponseLogicModel> Validate(AuthenticationRequestLogicModel request, string otpCode)
        {
            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role" });
            var unlockuserIfOtpSucceded = false;
            if (user != null && user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.Now)
            {
                if (user.LockoutEnd > DateTime.MaxValue.AddDays(-1) && !user.PhoneNumberConfirmed && !user.TwoFactorEnabled)
                {
                    unlockuserIfOtpSucceded = true;
                }
                else
                {
                    throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
                }
            }

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                if ((!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now) && user.AccessFailedCount < 5)
                {
                    if (user.PhoneNumberConfirmed && user.TwoFactorEnabled)
                    {
                        var valid = await this._otpService.ValidateOtpResponse(null, user.PhoneNumber, otpCode);
                        if (valid)
                        {
                            return await GenerateToken(user);
                        }
                        else
                        {
                            user.AccessFailedCount++;
                            if (user.AccessFailedCount >= 5)
                            {
                                user.LockoutEnd = DateTime.Now.AddMinutes(30);
                                _logger.LogWarning($"User '{request.Username}' locked out due to unusual behavior.");
                            }

                            await _uow.SaveAsync();
                        }

                        throw new InvalidOperationException("SMS provider error.");
                    }
                    else
                    {
                        return await GenerateToken(user);
                    }
                }
                else if (unlockuserIfOtpSucceded)
                {
                    var valid = await this._otpService.ValidateOtpResponse(null, user.PhoneNumber, otpCode);
                    if (valid)
                    {
                        user.PhoneNumberConfirmed = true;
                        user.TwoFactorEnabled = true;
                        user.LockoutEnd = null;
                        return await GenerateToken(user);
                    }
                    else
                    {
                        user.AccessFailedCount++;
                        await _uow.SaveAsync();
                    }
                }
                throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
            }
            if (user != null)
            {
                user.AccessFailedCount++;
                if (user.AccessFailedCount >= 5)
                {
                    _logger.LogWarning($"User '{request.Username}' locked out due to unusual behavior.");
                    user.LockoutEnd = DateTime.Now.AddMinutes(30);
                }
                await _uow.SaveAsync();
            }

            throw new CustomerApiException(MessageTypeEnum.NoSuchUser, "User not found.");

        }

        public async Task<AuthenticationResponseLogicModel> ResendOTP(AuthenticationRequestLogicModel request)
        {
            //ToDo: Finish it.
            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role", "PartnerFleets" });
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                //var existingOtp = await _otpService.
                if ((!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now) && user.AccessFailedCount < 5)
                {
                    if (user.PhoneNumberConfirmed && user.TwoFactorEnabled)
                    {
                        user.AccessFailedCount = 0;
                        await _uow.SaveAsync();
                        //return await GenerateToken(user);

                        //var template = await _templatesService.Get("WSI.Infrastructure.TemplateGenerators.Sms.Security.OtpCodeTemplateGenerator", TemplateType.Sms);
                        //var generator = _templateGenerators.FirstOrDefault(z => z.Type == template.Type && z.TemplateType == template.TemplateType);

                        //Func<string, string> templateGeneratorActivator = null;
                        //if (generator != null)
                        //{
                        //    templateGeneratorActivator = (x) => generator.Generate(1, template.LastValue.Value, new OtpCodeEntity { OtpCode = x }).Result;
                        //}

                        //var sent = await this._otpService.SendOtp(null, user.PhoneNumber, templateGeneratorActivator);
                        //if (sent)
                        //{
                        //    return new AuthenticationResponseLogicModel
                        //    {
                        //        Type = "2FA"
                        //    };
                        //}
                    }
                    else
                    {
                        return await GenerateToken(user);
                    }
                }
                throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
            }

            return null;
        }

        public async Task<bool> ResendOTPResendPassword(ResendPasswordRequestLogicModel request)
        {
            //dania

            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role", "PartnerFleets" });
            if (user != null)
            {
                //var existingOtp = await _otpService.
                if ((!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now) && user.AccessFailedCount < 5)
                {
                    if (user.PhoneNumberConfirmed)
                    {
                        //return await GenerateToken(user);

                        //var template = await _templatesService.Get("WSI.Infrastructure.TemplateGenerators.Sms.Security.OtpCodeTemplateGenerator", TemplateType.Sms);
                        //var generator = _templateGenerators.FirstOrDefault(z => z.Type == template.Type && z.TemplateType == template.TemplateType);

                        //Func<string, string> templateGeneratorActivator = null;
                        //if (generator != null)
                        //{
                        //    templateGeneratorActivator = (x) => generator.Generate(1, template.LastValue.Value, new OtpCodeEntity { OtpCode = x }).Result;
                        //}

                        //var sent = await this._otpService.SendOtp(null, user.PhoneNumber, templateGeneratorActivator);
                        //user.AccessFailedCount++;
                        //await _uow.SaveAsync();

                        //return sent;


                    }

                }
                throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
            }

            return false;
        }

        public async Task<bool> SendPasswordResetEmail(string email = null, string phone = null)
        {
            ApplicationUser user = null;
            user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => (!string.IsNullOrEmpty(email) && x.UserName == email) || (!string.IsNullOrEmpty(phone) && x.PhoneNumber.Contains(phone)));
            if (user != null && user.PhoneNumberConfirmed && user.AccessFailedCount < 5 && (!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now))
            {
                var encryptedUserName = _encryptionService.Encrypt(user.UserName);
                var resetToken = _encryptionService.Encrypt(await _userManager.GeneratePasswordResetTokenAsync(user));


                if (!string.IsNullOrEmpty(email))
                {
                    //var baseAppUrl = _baseAppUrl;
                    //var template = await _templatesService.Get("WSI.Infrastructure.TemplateGenerators.Email.Customers.ChangePasswordTemplateGenerator", TemplateType.Email);
                    //var generator = _templateGenerators.FirstOrDefault(z => z.Type == template.Type && z.TemplateType == template.TemplateType);
                    //var generatorResponse = await generator.Generate(1, template.LastValue.Value, new ChangePasswordLogicModel
                    //{
                    //    BaseAddress = string.IsNullOrEmpty(baseAppUrl) ?
                    //                  _actionContextAccessor.HttpContext
                    //                                        .Request
                    //                                        .BaseUrl()
                    //                                        .Replace("http:", "https:") :
                    //                  baseAppUrl,
                    //    EncryptedUserName = encryptedUserName,
                    //    ResetToken = resetToken
                    //});
                    //var message = new EmailMessageModel
                    //{
                    //    To = new KeyValuePair<string, string>(user.Email, user.FullName),
                    //    Body = generatorResponse,
                    //    Subject = "WeShareIt change password"
                    //};
                    //_smtpService.Send(message);
                    return true;
                }
                else if (!string.IsNullOrEmpty(phone))
                {
                    //var baseUrl = $@"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/auth/reset-password?u={encryptedUserName}&amp;t={resetToken}"; ;
                    //var message = $"לפי העדכונים שלנו, לפני מספר דקות ביקשת להחליף סיסמה. לביצוע - {baseUrl}";
                    //_smsService.SendMessage(user.PhoneNumber, message);
                    return true;
                }

            }
            else if (user == null)
            {
                throw new CustomerApiException(MessageTypeEnum.EmailNotExsist, "email does not exsist");
            }
            return false;
        }

        public async Task<string> SendResetToken(ResendPasswordRequestLogicModel request, string otpCode)
        {

            //dania
            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role", "PartnerFleets" });
            if (user != null)
            {
                if (user.PhoneNumberConfirmed)
                {
                    if (!(!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now))
                    {
                        throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");

                    }
                    if (user.AccessFailedCount > 5)
                    {
                        throw new SecurityTokenException("User locked out due to unusual behavior");
                    }

                    var valid = await this._otpService.ValidateOtpResponse(null, user.PhoneNumber, otpCode);
                    if (valid)
                    {
                        user.PhoneNumberConfirmed = true;
                        user.TwoFactorEnabled = true;
                        user.LockoutEnd = null;
                        return _encryptionService.Encrypt(await _userManager.GeneratePasswordResetTokenAsync(user));
                    }
                    else
                    {
                        user.AccessFailedCount++;
                        await _uow.SaveAsync();
                        throw new SecurityTokenException("Otp not matched to the user's details.");

                    }

                }

            }
            throw new CustomerApiException(MessageTypeEnum.NoSuchUser, "User not found.");
        }

        public string TranslateHashedUsername(string hash)
        {
            var decryptedName = _encryptionService.Decrypt(hash.Replace(" ", "+"));
            return decryptedName;
        }
        public async Task<AuthenticationResponseLogicModel> VerifyResetToken(ForgotPasswordLogicModel request, string otpCode = null)
        {

            var decryptedName = _encryptionService.Decrypt(request.Username.Replace(" ", "+"));

            request.Username = decryptedName;

            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role", "PartnerFleets" });
            if (user != null && user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.Now)
            {
                throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
            }

            if (user != null && user.PhoneNumberConfirmed && (!user.LockoutEnd.HasValue || user.LockoutEnd < DateTime.Now))
            {

                if (string.IsNullOrEmpty(otpCode))
                {
                    user.AccessFailedCount = 0;
                    var sent = await this._otpService.SendOtp(null, user.PhoneNumber);
                    if (sent)
                    {
                        return new AuthenticationResponseLogicModel
                        {
                            Type = "2FA",
                            Token = request.ResetToken
                        };
                    }


                    throw new Exception("SMS provider error.");
                }
                else
                {

                    user.AccessFailedCount++;
                    if (user.AccessFailedCount >= 5)
                    {
                        user.LockoutEnd = DateTime.Now.AddMinutes(30);
                        _logger.LogWarning($"User '{request.Username}' locked out due to unusual behavior.");
                    }

                    var valid = await this._otpService.ValidateOtpResponse(null, user.PhoneNumber, otpCode);
                    if (valid)
                    {
                        request.ResetToken = _encryptionService.Decrypt(request.ResetToken.Replace(" ", "+"));
                        _logger.LogInformation($"Password Reset Token: \n\r{request.ResetToken}");
                        var tokenIsValid = await _userManager.ResetPasswordAsync(user, request.ResetToken, request.Password);
                        if (tokenIsValid.Succeeded)
                        {
                            return await GenerateToken(user);
                        }
                        else
                        {
                            throw new Exception("Invalid reset password token provided.");
                        }
                    }
                    else
                    {
                        user.AccessFailedCount++;
                        await _uow.SaveAsync();
                        throw new Exception("SMS provider error.");
                    }

                }

            }

            throw new ArgumentException("User Not found");
        }

        public async Task<AuthenticationResponseLogicModel> VerifyResetTokenOnly(ForgotPasswordLogicModel request)
        {

            var user = await _uow.Repository<ApplicationUser>().FirstOrDefaultAsync(x => x.UserName == request.Username, includeProperties: new[] { "Roles.Role", "PartnerFleets" });
            if (user != null && user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.Now)
            {
                throw new SecurityTokenException("User locked out due to unusual behavior, you can try again after we'll exam your behavior (30 min ~).");
            }

            if (user != null)
            {
                if (!user.PhoneNumberConfirmed)
                {
                    throw new CustomerApiException(MessageTypeEnum.UserNotApprove, "User Phone Number Not Confirmed");

                }

                user.AccessFailedCount++;
                if (user.AccessFailedCount >= 5)
                {
                    user.LockoutEnd = DateTime.Now.AddMinutes(30);
                    _logger.LogWarning($"User '{request.Username}' locked out due to unusual behavior.");
                }
                _logger.LogInformation($"Password Reset Token before: \n\r{request.ResetToken}");

                request.ResetToken = _encryptionService.Decrypt(request.ResetToken.Replace(" ", "+"));
                _logger.LogInformation($"Password Reset Token: \n\r{request.ResetToken}");
                var tokenIsValid = await _userManager.ResetPasswordAsync(user, request.ResetToken, request.Password);
                if (tokenIsValid.Succeeded)
                {
                    user.AccessFailedCount = 0;
                    user.LockoutEnd = null;
                    return await GenerateToken(user);
                }
                else
                {
                    throw new CustomerApiException(MessageTypeEnum.NoSuchUser, "Invalid reset password token provided.");
                }
            }

            throw new CustomerApiException(MessageTypeEnum.NoSuchUser, "User Not found");
        }
        private async Task<AuthenticationResponseLogicModel> GenerateToken(ApplicationUser user, RefreshToken<long> refreshToken = null, Guid? jti = null)
        {
            var clientIp = _actionContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            jti ??= Guid.NewGuid();
            refreshToken = refreshToken ?? await _refreshTokensService.Generate(user.Id, _actionContextAccessor.HttpContext.Connection, jti.Value, false);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);


            var requiredClaims = new List<Claim> {
                new Claim(IdeoClaims.UserId, $"{user.Id}"),
                new Claim(JwtRegisteredClaimNames.Jti, jti?.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("UtcOffset", $"{user.UtcOffset?.TotalSeconds ?? TimeSpan.FromHours(3).TotalSeconds}")
            };

            if (user.Roles?.Any() ?? false)
            {
                foreach (var role in user.Roles)
                {
                    requiredClaims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
                }
            }

            //if (user.PartnerFleets?.Any() ?? false)
            //{
            //    foreach (var partnerFleet in user.PartnerFleets.OrderBy(z => z.PartnerId).ThenBy(z => z.FleetId))
            //    {
            //        if (!requiredClaims.Any(z => z.Type == Claims.PartnerId && z.Value == $"{partnerFleet.PartnerId}"))
            //        {
            //            requiredClaims.Add(new Claim(Claims.PartnerId, $"{partnerFleet.PartnerId}"));
            //        }

            //        if (partnerFleet.FleetId.HasValue && !requiredClaims.Any(z => z.Type == Claims.FleetId && z.Value == $"{partnerFleet.FleetId.Value}"))
            //        {
            //            requiredClaims.Add(new Claim(Claims.FleetId, $"{partnerFleet.FleetId.Value}"));
            //        }
            //    }
            //}


            var claims = new List<Claim>(requiredClaims);

            //user.LastLoginIp = clientIp;

            await _uow.SaveAsync();

            var host = _actionContextAccessor.HttpContext.Request.Host.Value;

            var expiry = DateTime.UtcNow + TimeSpan.FromMinutes(_jwtConfig.Value.ExpireyInMinutes);
            var token = new JwtSecurityToken(host,
                    host,
                    requiredClaims,
                    expires: expiry,
                    signingCredentials: credentials);

            //var partnerFleets = user.PartnerFleets?
            //                          .Where(z => z.FleetId.HasValue)?
            //                          .GroupBy(z => z.PartnerId)?
            //                          .ToDictionary(x => x.Key, x => x.Where(z => z.FleetId.HasValue).Distinct().Select(z => z.FleetId.Value));

            //if (user.Roles.Any(r => r.Role.Name == Roles.Admin))
            //{
            //    partnerFleets = (await _uow.Repository<PartnerFleetUser>().GetQuery(null, null, 0, int.MaxValue)
            //                               .Select(z => new { z.PartnerId, z.FleetId })
            //                               .Distinct()
            //                              .ToListAsync())
            //                              .GroupBy(z => z.PartnerId)
            //                              .ToDictionary(z => z.Key, z => z.Where(z => z.FleetId.HasValue).Distinct().Select(z => z.FleetId.Value));
            //}

            return new AuthenticationResponseLogicModel
            {
                UserId = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken.Token,
                ValidFrom = DateTime.UtcNow,
                ValidTo = expiry,
                Roles = user.Roles?.Select(r => r.Role.Name),
                //PartnerId = user.PartnerFleets?.GroupBy(z => z.PartnerId)?.FirstOrDefault()?.Key,
                //PartnerFleetIds = partnerFleets
            };
        }
    }
}
