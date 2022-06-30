using Health.Core.Interfaces;
using Health.Core.Interfaces.Providers;
using Health.Core.Interfaces.Services;
using Health.Core.Interfaces.Services.Security;
using Health.Data;
using Health.DataAccessLayer;
using Health.Infrastructure.Services;
using Health.Infrastructure.Services.Account;
using Ideo.NetCore.Data.Encryption.AES.Configuration;
using Ideo.NetCore.Data.Encryption.Core.Interfaces;
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
            services.AddScoped<ITagsService, TagsService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPermissionsService, PermissionsService>();
            services.AddSingleton<IPermissionProvider, PermissionProvider>();
            if (!services.Any(x => x.ServiceType == typeof(IEncryptionService<AES>)))
            {
                services.AddIdeoAESEncryption<AES>(new AES()
                {
                    SaltKey = "S@LT&KEY",
                    VIKey = "@1B2c3D4e5F6g7H8",
                    Password = "ShufErs@l"
                });
            }
            return services;
        }
    }
}
