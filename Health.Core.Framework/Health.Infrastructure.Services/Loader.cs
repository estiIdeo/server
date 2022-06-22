using Health.Core.Interfaces;
using Health.Data;
using Health.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Health
{
    public static class Loader
    {
        public static IServiceCollection AddHealthDb(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<HealthDbContext>(x => x.UseMySql(connectionString, new MySqlServerVersion(new Version(1, 0, 0))));
        }
        public static IServiceCollection AddHealthServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeesService>();
            return services;
        }
    }
}
