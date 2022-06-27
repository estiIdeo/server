using Health.Core.Framework.Account.Security;
using Health.Core.Types.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Interfaces.Providers
{
    public interface IPermissionProvider
    {
        /// <summary>
        /// Get permissions
        /// </summary>
        /// <returns>Permissions</returns>
        IEnumerable<ApplicationPermission> GetPermissions();

        /// <summary>
        /// Get default permissions
        /// </summary>
        /// <returns>Default permissions</returns>
        IEnumerable<RoleApplicationPermissionLogicModel> GetDefaultPermissions();
    }
}
