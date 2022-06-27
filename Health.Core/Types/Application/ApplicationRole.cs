using Microsoft.AspNetCore.Identity;

namespace Health.Core.Types.Application
{
    public class ApplicationRole : IdentityRole<long>
    {
        public bool IsSystem { get; set; } = false;
        public long? ParentRoleId { get; set; }
        public virtual ICollection<ApplicationClaim> DefaultClaimsValues { get; set; }
        public virtual ICollection<PermissionRole> Permissions { get; set; }
        public virtual ApplicationRole ParentRole { get; set; }

    }
}
