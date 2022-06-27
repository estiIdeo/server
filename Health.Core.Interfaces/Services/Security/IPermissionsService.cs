using Health.Core.Framework.Account.Security;
using Health.Core.Types.Application;
using Ideo.NetCore.Web.CRUD.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Interfaces.Services.Security
{
    public interface IPermissionsService : ICrudService<long, ApplicationPermission, PermissionLogicModel>
    {
        Task<Dictionary<string, IEnumerable<string>>> Get(params string[] roles);

    }
}
