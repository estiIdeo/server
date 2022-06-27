using Health.Core.Framework.Account.Security;
using Health.Core.Interfaces.Services.Security;
using Health.Web.Extensions.Common;
using Ideo.NetCore.Web.CRUD.Core.Attributes;
using Ideo.NetCore.Web.CRUD.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers.Security
{
    [Route("~/api/Security/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ACLController : HealthApiController
    {
        private readonly ILogger<ACLController> _logger;
        private readonly IAclService _aclService;

        public ACLController(ILogger<ACLController> logger, IAclService aclService)
        {
            this._logger = logger;
            this._aclService = aclService;
        }


        /// <summary>
        ///     Get access control list.
        /// </summary>
        /// <returns>Returns access control list</returns>
        /// <response code="201">Returned if user creation was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed (Invalid credentials)</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PermissionLogicModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Exportable]
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var acl = (await _aclService.Get())?.ToList();
            return Ok(new PagedResponse(acl));
        }

        /// <summary>
        ///     Get template.
        /// </summary>
        /// <response code="200">Returned if ACL template was found</response>
        /// <response code="404">Returned if ACL template wasn't found</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionLogicModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Exportable]
        [HttpGet("Template")]
        public IActionResult Template()
        {
            try
            {
                return Ok(new PagedResponse(new[] { new PermissionLogicModel
                    {
                        Id = null,
                        Category = "",
                        Name = "",
                        SystemName = "",
                        RoleIds = new long[] {},
                        //RoleIds = new long[] {1,2 },
                    } }));
            }
            catch (Exception)
            {

                return NotFound("Payment plan template not found");
            }
        }

        /// <summary>
        ///     Get access control list.
        /// </summary>
        /// <returns>Returns access control list</returns>
        /// <response code="201">Returned if user creation was successfull</response>
        /// <response code="400">Returned when model is not valid</response>
        /// <response code="404">Returned when Authentication failed (Invalid credentials)</response>
        /// <response code="500">Returned when server error occurred</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PermissionLogicModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{permissionId}/Role/{roleId}")]
        public async Task<IActionResult> SetRolePermission([FromRoute] long permissionId, [FromRoute] long roleId, [FromQuery] bool hasAccess)
        {
            if (await _aclService.Update(permissionId, roleId, hasAccess))
            {
                return Ok();
            }

            return Conflict();
        }
    }
}
