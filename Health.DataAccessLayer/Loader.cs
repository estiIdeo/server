using Health.Core.Domain.Identity;
using Health.Core.Interfaces.Providers;
using Health.Core.Types.Application;
using Health.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Health.DataAccessLayer
{
    public static class Loader
    {
        private static readonly IEnumerable<Type> entityTypeRepositories = new Type[] {
            typeof(ApplicationUser),
            typeof(ApplicationRole),
            typeof(IdentityRoleClaim<long>),
            typeof(IdentityRoleClaim<long>),
            typeof(UserRole),
            typeof(ApplicationPermission),
            typeof(PermissionRole),
        };
        public static IServiceCollection AddHealthDataAccessLayer(this IServiceCollection services, params Type[] additionalEntityTypeRepositories)
        {
            services.AddSingleton<IPermissionProvider, PermissionProvider>();
            services.AddIdeoUnitOfWork<HealthDbContext>(entityTypeRepositories?.ToArray()?.Concat(additionalEntityTypeRepositories)?.ToArray());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
