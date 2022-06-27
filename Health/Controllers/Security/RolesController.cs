using Health.Core.Framework.Account.Security;
using Health.Core.Interfaces.Services.Entities.Identity;
using Health.Core.Types.Application;
using Health.Web.Extensions.Common;
using Ideo.NetCore.Web.CRUD.Core.Attributes;
using Ideo.NetCore.Web.CRUD.Core.Extentions;
using Ideo.NetCore.Web.CRUD.QueryBuilder.Core.Interfaces;
using Ideo.NetCore.Web.CRUD.QueryBuilder.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Health.Controllers.Security
{
    [Route("~/api/Security/[controller]")]
    public class RolesController : HealthApiController
    {
        #region Fields
        private readonly ILogger<RolesController> _logger;
        private readonly IRolesService _rolesService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IQueryBuilderService _queryBuilder;
        #endregion

        public RolesController(ILogger<RolesController> logger, IRolesService rolesService, IQueryBuilderService queryBuilder, IAuthorizationService authorizationService)
        {
            this._logger = logger;
            this._rolesService = rolesService;
            this._queryBuilder = queryBuilder;
            this._authorizationService = authorizationService;
        }

        /// <summary>
        ///     Get Role by id.
        /// </summary>
        /// <param name="id">the Role id to find.</param>
        /// <returns>Returns <see cref="RoleLogicModel"/></returns>
        /// <response code="200">Returned if Role found</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="403">Returned when current user has no permission to fetch Roles</response>
        /// <response code="404">Returned when Role not found</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RoleLogicModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            var allowed = await _authorizationService.AuthorizeAsync(User, Health.Core.Types.Application.DefaultPermissions.AccessRoles.SystemName);
            if (allowed.Succeeded)
            {
                var role = await _rolesService.Get(id);
                if (role != null)
                {
                    return Ok(role);
                }
                return NotFound();
            }

            return Forbid();
        }


        /// <summary>
        ///     Get roles.
        /// </summary>
        /// <param name="page">the page number.</param>
        /// <param name="take">the page size.</param>
        /// <param name="sort">sort (OrderBy).</param>
        /// <param name="filter">filter results.</param>
        /// <returns>Returns Roles <see cref="RoleLogicModel"/></returns>
        /// <response code="200">Returned when successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RoleLogicModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Exportable]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int page = 0,
                                             [FromQuery] int take = 10,
                                             [FromQuery] IEnumerable<KeyValuePair<string, int>> sort = null,
                                             [FromQuery] IEnumerable<CrudFilter> filter = null)
        {
            try
            {
                var query = _queryBuilder.Build<ApplicationRole>(filter);
                var response = await _rolesService.Get(page, take, query, sort?.ToDictionary(s => s.Key, s => s.Value));
                return Ok(response.ToPagedResponse());
            }
            catch (QueryBuildException ex)
            {
                return BadRequest(ex.Filters);
            }
        }


        /// <summary>
        ///     Update Role.
        /// </summary>
        /// <param name="id">the Role id to find.</param>
        /// <param name="model">the Role model <see cref="RoleLogicModel"/> to update.</param>
        /// <returns>Returns updated <see cref="RoleLogicModel"/></returns>
        /// <response code="202">Returned if Role was Updated</response>
        /// <response code="409">Returned when permission forbidden</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(RoleLogicModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] RoleLogicModel model)
        {
            var allowed = await _authorizationService.AuthorizeAsync(User, Health.Core.Types.Application.DefaultPermissions.EditRoles.SystemName);
            if (allowed.Succeeded)
            {
                var user = await _rolesService.Update(id, model);
                if (user != null)
                {
                    return Accepted(user);
                }
                return NotFound(new { Error = $"Role not found, {{ RoleId: {id} }}" });
            }
            return Forbid();
        }



        /// <summary>
        ///     Create Role.
        /// </summary>
        /// <response code="202">Returned if Role created</response>
        /// <response code="409">Returned when Role already exists</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(RoleLogicModel))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleLogicModel model)
        {
            var allowed = await _authorizationService.AuthorizeAsync(User, Health.Core.Types.Application.DefaultPermissions.CreateRoles.SystemName);
            if (allowed.Succeeded)
            {
                try
                {
                    return Accepted(await _rolesService.Create(model));
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "RolesController -> Create failed.");
                    return Conflict(new { Error = "Role already exists." });
                }
            }
            return Forbid();
        }

        /// <summary>
        ///     Delete Role.
        /// </summary>
        /// <response code="200">Returned if locale resource was removed successfully</response>
        /// <response code="404">Returned when Role not found or its a System Role</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var allowed = await _authorizationService.AuthorizeAsync(User, Health.Core.Types.Application.DefaultPermissions.DeleteRoles.SystemName);
            if (allowed.Succeeded)
            {
                return await _rolesService.Delete(id) ? Ok() : NotFound();
            }
            return Forbid();
        }
    }
}
