using Health.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Health.Web.Extensions.Models
{
    public class ClaimsUser : ClaimsPrincipal
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<long> PartnerIds { get; set; }
        public TimeSpan UtcOffset { get; set; }

        public string AuthenticationType => "bearer";
        public bool IsAuthenticated => true;
        public bool IsCustomer => Roles?.Any(r => r == Constants.Configuration.Identity.Roles.Customer) ?? false;
        public string Name => UserName;
    }
}
