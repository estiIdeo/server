using Health.Web.Extensions.Models;
using Ideo.NetCore.Web.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Health.Core.Constants.Configuration.Identity;

namespace Health.Web.Extensions.Common
{
    [ApiController]
    [Produces("application/json")]
    public class HealthApiController : ControllerBase
    {
        private ClaimsUser _user;
        protected new ClaimsUser User
        {
            get
            {
                if (_user != null)
                {
                    return _user;
                }
                this._user = new ClaimsUser();
                if (long.TryParse(base.User.FindFirstValue(IdeoClaims.UserId), out long userId) && userId != default(long))
                {
                    if (long.TryParse(base.User.FindFirstValue("UtcOffset"), out long unixOffset))
                    {
                        this._user.UtcOffset = TimeSpan.FromSeconds(unixOffset);
                    }
                    else
                    {
                        this._user.UtcOffset = TimeSpan.FromHours(3);
                    }
                    this._user.UserId = userId;
                    this._user.UserName = base.User.Identity.Name;
                    this._user.Roles = base.User.FindAll(ClaimTypes.Role)?.Select(x => x.Value);
                    this._user.PartnerIds = base.User
                                                .FindAll(Claims.PartnerId)?
                                                .Select(x => !string.IsNullOrEmpty(x?.Value) && long.TryParse(x.Value, out long v) && v != default(long) ? (long?)v : null)?
                                                .Where(x => x.HasValue)?
                                                .Select(z => z.Value);
                }

                return _user;
            }
        }

        protected readonly string[] AdminRoles = new[]
        {
            Roles.Admin,
            Roles.PartnerAdmin
        };

        protected bool IsPartnerAdmin => User.Roles.Any(r => AdminRoles.Contains(r));
    }
}
