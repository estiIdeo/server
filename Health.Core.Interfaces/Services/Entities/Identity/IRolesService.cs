using Health.Core.Framework.Account.Security;
using Health.Core.Types.Application;
using Ideo.NetCore.Web.CRUD.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Health.Core.Interfaces.Services.Entities.Identity
{
    public interface IRolesService : ICrudService<long, ApplicationRole, RoleLogicModel>
    {
    }
}
