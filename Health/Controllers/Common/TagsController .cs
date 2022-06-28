using Health.Core.Domain.Common;
using Health.Core.Interfaces;
using Health.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [ApiController]
    [Route("~/api/[controller]")]
    public class TagsController : ControllerBase
    {
        private ITagsService _TagsService;
        private readonly IAuthorizationService _authorizationService;

        public TagsController(ITagsService TagsService, IAuthorizationService authorizationService)
        {
            _TagsService = TagsService;
            _authorizationService = authorizationService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tag model)
        {
            return Ok(await _TagsService.Create(model));
        }
    }
}
