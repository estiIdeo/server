
using Health.Core.Framework.Account.Security;
using Health.Core.Interfaces.Services.Entities.Identity;
using Health.Core.Types.Application;
using Health.DataAccessLayer;
using Ideo.NetCore.Framework.Extentions.System;
using Ideo.NetCore.Web.CRUD.Core.Interfaces;
using Ideo.NetCore.Web.CRUD.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Health.Infrastructure.Services.Account
{
    internal class RolesService : IRolesService
    {
        #region Fields
        private readonly ILogger<RolesService> _logger;
        private readonly IUnitOfWork _uow;
        #endregion

        public RolesService(ILogger<RolesService> logger, IUnitOfWork uof)
        {
            this._logger = logger;
            this._uow = uof;
        }

        public Task<IEnumerable<RoleLogicModel>> Bulk(IEnumerable<RoleLogicModel> model, Expression<Func<ApplicationRole, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<RoleLogicModel> Create(RoleLogicModel model)
        {
            var rolesRepository = _uow.Repository<ApplicationRole>();
            var role = new ApplicationRole
            {
                Name = model.Name,
                NormalizedName = model.Name.ToUpper(),
                ParentRoleId = model.ParentRoleId,
                //IsSystem = false
            };
            rolesRepository.Add(role);
            await _uow.SaveAsync();
            model.Id = role.Id;
            return model;
        }

        public async Task<bool> Delete(long id, Expression<Func<ApplicationRole, bool>> filter = null)
        {
            var repository = _uow.Repository<ApplicationRole>();
            filter = filter.AndExpression(x => x.Id == id) ?? (x => x.Id == id);
            var role = await repository.FirstOrDefaultAsync(filter);
            if (role != null)
            {
                repository.Remove(role);
                await _uow.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<RoleLogicModel> Get(long id, Expression<Func<ApplicationRole, bool>> filter = null)
        {
            var repository = _uow.Repository<ApplicationRole>();
            filter = filter.AndExpression(x => x.Id == id) ?? (x => x.Id == id);
            var role = await repository.FirstOrDefaultAsync(filter);
            if (role != null)
            {
                return new RoleLogicModel
                {
                    Id = role.Id,
                    Name = role.Name,
                    SystemName = role.NormalizedName,
                    ParentRoleId = role.ParentRoleId,
                    IsSystem = role.IsSystem
                };
            }
            return null;
        }

        public async Task<IPagedList<RoleLogicModel>> Get(int page = 0, int take = 10, Expression<Func<ApplicationRole, bool>> filter = null, Dictionary<string, int> sorts = null)
        {
            var query = await _uow.Repository<ApplicationRole>()
                      .GetQueryAsync(filter, sorts, page, take);


            return new PagedList<RoleLogicModel>(await query.Query.Select(role => new RoleLogicModel
            {
                Id = role.Id,
                ParentRoleId = role.ParentRoleId,
                Name = role.Name,
                SystemName = role.NormalizedName,
                IsSystem = role.IsSystem
            }).ToListAsync(), query.Total);
        }

        public async Task<RoleLogicModel> Update(long id, RoleLogicModel model, Expression<Func<ApplicationRole, bool>> filter = null)
        {
            var rolesRepository = _uow.Repository<ApplicationRole>();
            filter = filter.AndExpression(x => x.Id == id) ?? (x => x.Id == id);
            var role = await rolesRepository.FirstOrDefaultAsync(filter);
            if (role != null)
            {
                role.Name = model.Name;
                role.NormalizedName = model.Name.ToUpper();
                role.ParentRoleId = model.ParentRoleId;
                await _uow.SaveAsync();
                return model;
            }
            rolesRepository.Add(role);
            await _uow.SaveAsync();
            model.Id = role.Id;
            return model;
        }
    }
}
