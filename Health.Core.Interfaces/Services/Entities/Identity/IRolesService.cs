using Health.Core.Framework.Account.Security;
using Health.Core.Types.Application;
using Ideo.NetCore.Web.CRUD.Core.Interfaces;
namespace Health.Core.Interfaces.Services.Entities.Identity
{
    public interface IRolesService : ICrudService<long, ApplicationRole, RoleLogicModel>
    {
    }
}
