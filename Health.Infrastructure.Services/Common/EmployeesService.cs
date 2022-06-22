


using Health.Core.Interfaces;
using Health.Data;

namespace Health.Infrastructure.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly HealthDbContext _dbContext;
        public EmployeesService(HealthDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(){

           /* await _dbContext.Employees.AddAsync(new Employees()
            {
                EmployeeLastName = "Aviv2",
                EmployeeFirstName = "Avi2",
                Salary = 74000,
                Designation = "Development2",
                Address = "aaa 27"
            });*/

           // _dbContext.Employees.FirstOrDefault(e => e.Id == 1).Address = "ffffff";
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}