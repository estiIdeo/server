using Health.Core.Domain.Common;
using Health.Core.Interfaces;
using Health.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private HealthDbContext _dbContext;
        private ITagsService _TagsService;
        private readonly IAuthorizationService _authorizationService;

        public TagsController(HealthDbContext dbContext, ITagsService TagsService, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _TagsService = TagsService;
            _authorizationService = authorizationService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tag model)
        {
            return Ok(await _TagsService.Create());
        }
    }
}
