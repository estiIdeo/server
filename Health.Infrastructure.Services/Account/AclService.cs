using Health.Core;
using Health.Core.Framework.Account.Security;
using Health.Core.Interfaces.Services.Security;
using Health.Core.Types.Application;
using Health.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Health.Infrastructure.Services.Account
{
    internal class AclService : IAclService
    {
        #region Fields
        private readonly ILogger<AclService> _logger;
        private readonly IUnitOfWork _uof;
        private readonly IMemoryCache _cache;
        #endregion

        public AclService(ILogger<AclService> logger, IUnitOfWork uof, IMemoryCache cache)
        {
            this._logger = logger;
            this._uof = uof;
            this._cache = cache;
        }
        public async Task<IEnumerable<PermissionLogicModel>> Get()
        {
            return await _uof.Repository<ApplicationPermission>()
                              .GetQuery(pageSize: int.MaxValue,
                                        sorts: new Dictionary<string, int> { { "Category", 1 }, { "SystemName", 1 } },
                                        includeProperties: "Roles")
                              .Select(x => new PermissionLogicModel
                              {
                                  Id = x.Id,
                                  Category = x.Category,
                                  Name = x.Name,
                                  SystemName = x.SystemName,
                                  RoleIds = x.Roles.Select(z => z.RoleId)
                              }).ToListAsync();
        }

        public async Task<IEnumerable<PermissionLogicModel>> Update(IEnumerable<PermissionLogicModel> model)
        {
            var permissionIds = model.Select(z => z.Id).Where(z => z.HasValue).ToList();
            var permissions = await _uof.Repository<ApplicationPermission>()
                                        .GetQuery(z => permissionIds.Contains(z.Id), pageSize: int.MaxValue, includeProperties: "Roles")
                                        .ToListAsync();

            if (permissions?.Any() ?? false)
            {
                var permissionRolesRepo = _uof.Repository<PermissionRole>();
                permissionRolesRepo.RemoveRange(permissions.SelectMany(z => z.Roles));

                foreach (var permission in permissions)
                {
                    var updatedPermission = model.FirstOrDefault(z => z.Id.HasValue && z.Id.Value == permission.Id);
                    if (updatedPermission != null)
                    {
                        permission.Name = updatedPermission.Name;
                        permission.Category = updatedPermission.Category;

                        if (updatedPermission.RoleIds?.Any() ?? false)
                        {
                            foreach (var roleId in updatedPermission.RoleIds)
                            {
                                permission.Roles.Add(new PermissionRole
                                {
                                    PermissionId = permission.Id,
                                    RoleId = roleId
                                });
                            }
                        }
                    }
                }

                await _uof.SaveAsync();
                return model;
            }

            return null;
        }

        public async Task<bool> Update(long permissionId, long roleId, bool hasAccess)
        {
            var repository = _uof.Repository<ApplicationPermission>();
            var rolesRepository = _uof.Repository<ApplicationRole>();
            var permissionRolesRepository = _uof.Repository<PermissionRole>();
            var permission = await repository.GetQuery(z => z.Id == permissionId, pageSize: 1, includeProperties: "Roles.Role").FirstOrDefaultAsync();
            if (hasAccess)
            {
                if (!permission.Roles.Any(r => r.RoleId == roleId))
                {
                    var role = await rolesRepository.FirstOrDefaultAsync(z => z.Id == roleId);
                    if (role != null)
                    {
                        permissionRolesRepository.Add(new PermissionRole
                        {
                            PermissionId = permission.Id,
                            RoleId = role.Id
                        });
                        await _uof.SaveAsync();
                        var key = string.Format(Constants.Cache.Permissions.PermissionsAllowedCacheKey, role.Name, permission.SystemName);
                        _cache.Set<bool>(key, hasAccess, TimeSpan.FromDays(7));
                        return true;
                    }
                }
            }
            else if (permission.Roles.Any(r => r.RoleId == roleId))
            {
                var roleName = permission.Roles.FirstOrDefault(z => z.RoleId == roleId)?.Role?.Name;
                if (!string.IsNullOrEmpty(roleName))
                {
                    var key = string.Format(Constants.Cache.Permissions.PermissionsAllowedCacheKey, roleName, permission.SystemName);
                    permissionRolesRepository.Remove(permission.Roles.First(r => r.RoleId == roleId));
                    await _uof.SaveAsync();
                    _cache.Remove(key);
                    return true;
                }
            }

            return false;
        }
        public async Task<PermissionLogicModel> Update(PermissionLogicModel model)
        {
            var permission = await _uof.Repository<ApplicationPermission>()
                                       .GetQuery(z => z.Id == model.Id, pageSize: 1, includeProperties: "Roles")
                                       .FirstOrDefaultAsync();

            if (permission != null)
            {
                var permissionRolesRepo = _uof.Repository<PermissionRole>();
                if (permission.Roles?.Any() ?? false)
                {
                    permissionRolesRepo.RemoveRange(permission.Roles);
                }
                permission.Name = model.Name;
                permission.Category = model.Category;

                if (model.RoleIds?.Any() ?? false)
                {
                    foreach (var roleId in model.RoleIds)
                    {
                        permission.Roles.Add(new PermissionRole
                        {
                            PermissionId = permission.Id,
                            RoleId = roleId
                        });
                    }
                }
                await _uof.SaveAsync();
                return model;
            }

            return null;
        }
    }
}
