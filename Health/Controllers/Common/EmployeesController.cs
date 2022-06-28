using Health.Core.Interfaces;
using Health.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [ApiController]
    [Route("~/api/[controller]")]

    public class EmployeesController : ControllerBase
    {
        private HealthDbContext _dbContext;
        private IEmployeesService _employeesService;
        private readonly IAuthorizationService _authorizationService;

        public EmployeesController(HealthDbContext dbContext, IEmployeesService employeesService, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _employeesService = employeesService;
            _authorizationService = authorizationService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Create(int id)
        {
            return Ok(await _employeesService.Create());
        }
    }
}
