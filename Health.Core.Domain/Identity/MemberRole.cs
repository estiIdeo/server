using Health.Core.Types.Application;
using Microsoft.AspNetCore.Identity;

namespace Health.Core.Domain.Identity
{
    public class UserRole : IdentityUserRole<long>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }

    }
}
