using Health.Core.Framework.Account.Security;
using Health.Core.Interfaces.Services.Security;
using Health.Core.Types.Application;
using Health.DataAccessLayer;
using Ideo.NetCore.Framework.Extentions.System;
using Ideo.NetCore.Web.CRUD.Core.Interfaces;
using Ideo.NetCore.Web.CRUD.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Health.Infrastructure.Services.Account
{
    internal class PermissionsService : IPermissionsService
    {
        #region Fields
        private readonly ILogger<PermissionsService> _logger;
        private readonly IUnitOfWork _uow;
        #endregion

        public PermissionsService(ILogger<PermissionsService> logger, IUnitOfWork uow)
        {
            this._logger = logger;
            this._uow = uow;
        }
        public async Task<PermissionLogicModel> Create(PermissionLogicModel model)
        {
            var repository = _uow.Repository<ApplicationPermission>();
            List<PermissionRole> roles = null;
            if (model?.RoleIds?.Any() ?? false)
            {
                var roleIds = model.RoleIds.ToList();
                roles = await _uow.Repository<PermissionRole>()
                                  .GetQuery(z => roleIds.Contains(z.RoleId))
                                  .ToListAsync();
            }
            repository.Add(new ApplicationPermission
            {
                Category = model.Category,
                Name = model.Name,
                SystemName = model.SystemName,
                Roles = roles
            });

            await _uow.SaveAsync();

            return model;

        }

        public async Task<bool> Delete(long id, Expression<Func<ApplicationPermission, bool>> filter = null)
        {
            var repository = _uow.Repository<ApplicationPermission>();
            filter = filter.AndExpression(x => x.Id == id) ?? (x => x.Id == id);
            var permission = await repository.FirstOrDefaultAsync(filter);
            if (permission != null)
            {
                _uow.Repository<PermissionRole>().RemoveRange(permission.Roles);
                repository.Remove(permission);
            }
            await _uow.SaveAsync();
            return true;
        }

        public async Task<PermissionLogicModel> Get(long id, Expression<Func<ApplicationPermission, bool>> filter = null)
        {
            var repository = _uow.Repository<ApplicationPermission>();
            filter = filter.AndExpression(x => x.Id == id) ?? (x => x.Id == id);
            var permission = await repository.GetQuery(filter, null, 0, 1, false, "Roles").FirstOrDefaultAsync();
            if (permission != null)
            {
                return new PermissionLogicModel
                {
                    Id = permission.Id,
                    Category = permission.Category,
                    Name = permission.Name,
                    SystemName = permission.SystemName,
                    RoleIds = permission.Roles.Select(z => z.RoleId)
                };
            }

            return null;
        }

        public async Task<IPagedList<PermissionLogicModel>> Get(int page = 0, int take = 10, Expression<Func<ApplicationPermission, bool>> filter = null, Dictionary<string, int> sorts = null)
        {
            if (sorts == null)
            {
                sorts = new Dictionary<string, int> { { "Id", 1 } };
            }
            var repository = _uow.Repository<ApplicationPermission>();
            var query = await repository.GetQueryAsync(filter, sorts, page, take, false, "Roles");
            var result = new PagedList<PermissionLogicModel>(await query.Query.Select(permission => new PermissionLogicModel
            {
                Id = permission.Id,
                Category = permission.Category,
                Name = permission.Name,
                SystemName = permission.SystemName,
                RoleIds = permission.Roles.Select(z => z.RoleId)
            }).ToListAsync(), query.Total);

            return result;
        }

        public async Task<PermissionLogicModel> Update(long id, PermissionLogicModel model, Expression<Func<ApplicationPermission, bool>> filter = null)
        {
            var repository = _uow.Repository<ApplicationPermission>();
            filter = filter.AndExpression(x => x.Id == id) ?? (x => x.Id == id);
            var permission = await repository.GetQuery(filter, null, 0, 1, false, "Roles").FirstOrDefaultAsync();

            if (permission != null)
            {
                permission.Category = model.Category;
                permission.Name = model.Name;
                permission.SystemName = model.SystemName;

                if (!permission.Roles.Select(z => z.RoleId).All(z => model.RoleIds.Contains(z)))
                {
                    var permissionRolesRepo = _uow.Repository<PermissionRole>();
                    permissionRolesRepo.RemoveRange(permission.Roles);
                    var roles = await permissionRolesRepo.GetQuery(z => model.RoleIds.Contains(z.RoleId)).ToListAsync();
                    permission.Roles = roles;
                }

                await _uow.SaveAsync();
                return model;
            }

            return null;
        }

        public async Task<Dictionary<string, IEnumerable<string>>> Get(params string[] roles)
        {
            var permissionsRepository = _uow.Repository<ApplicationPermission>();
            var sortBy = new Dictionary<string, int> { { "SystemName", 1 } };
            var hasRoles = roles?.Any() ?? false;
            var query = permissionsRepository.GetQuery(z => !hasRoles || z.Roles.Any(r => roles.Contains(r.Role.Name)), sortBy, 0, int.MaxValue, true, "Roles.Role");
            var result = await query.ToDictionaryAsync(z => z.SystemName, z => z.Roles.Select(r => r.Role.Name));
            return result;
        }

        public Task<IEnumerable<PermissionLogicModel>> Bulk(IEnumerable<PermissionLogicModel> model, Expression<Func<ApplicationPermission, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
