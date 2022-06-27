using Health.Core.Types.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Framework.Account.Security
{
    public class RoleApplicationPermissionLogicModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<ApplicationPermission> Permissions { get; set; }
    }
}
