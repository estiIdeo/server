using Health.Core.Framework.Account.Authentication;
using Health.Core.Framework.Account.Users;
using Ideo.NetCore.Web.Security.Authentication.RefreshToken.Framework;

namespace Health.Core.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponseLogicModel> Validate(AuthenticationRequestLogicModel request);
        Task<AuthenticationResponseLogicModel> Validate(AuthenticationRequestLogicModel request, string otpCode);

        //Task<UserLogicModel> RegisterUser(UserRegistrationLogicModel request);
        Task<AuthenticationResponseLogicModel> Refresh(RefreshTokenRequestLogicModel request);
        Task<AuthenticationResponseLogicModel> VerifyResetToken(ForgotPasswordLogicModel request, string otpCode = null);
        Task<bool> SendPasswordResetEmail(string email = null, string phone = null);
        string TranslateHashedUsername(string hash);
        //Task<PageResponse<ConstantValue>> GetRoles(bool isAdmin, int page = 0, int take = 10, Dictionary<string, int> sorts = null, Expression<Func<ApplicationRole, bool>> filter = null);
        Task<string> SendResetToken(ResendPasswordRequestLogicModel username, string otpCode);
        Task<bool> ResendOTPResendPassword(ResendPasswordRequestLogicModel request);
        Task<AuthenticationResponseLogicModel> VerifyResetTokenOnly(ForgotPasswordLogicModel request);

    }
}
