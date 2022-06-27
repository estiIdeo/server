using Health.Core.Types.Application;

namespace Health.Core.Framework.Account.Security
{
    public class RoleApplicationPermissionLogicModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<ApplicationPermission> Permissions { get; set; }
    }
}
