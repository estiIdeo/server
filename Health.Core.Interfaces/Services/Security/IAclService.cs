using Health.Core.Framework.Account.Security;

namespace Health.Core.Interfaces.Services.Security
{
    public interface IAclService
    {
        public Task<IEnumerable<PermissionLogicModel>> Update(IEnumerable<PermissionLogicModel> model);
        public Task<PermissionLogicModel> Update(PermissionLogicModel model);
        public Task<bool> Update(long permissionId, long roleId, bool hasAccess);
        public Task<IEnumerable<PermissionLogicModel>> Get();

    }
}
