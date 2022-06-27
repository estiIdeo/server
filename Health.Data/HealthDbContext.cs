using Health.Core.Domain;
using Health.Core.Domain.Common;
using Health.Core.Domain.Identity;
using Health.Core.Interfaces.Providers;
using Health.Core.Types.Application;
using Health.Data.EntityTypeConfigurations.Common;
using Health.Data.EntityTypeConfigurations.Identity;
using Health.Data.EntityTypeConfigurations.Tag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Health.Data
{
    public class HealthDbContext : DbContext
    {
        private readonly IPermissionProvider _permissionProvider;
        public HealthDbContext(DbContextOptions<HealthDbContext> options, IPermissionProvider permissionProvider) : base(options)
        {
            this._permissionProvider = permissionProvider;
        }

        public DbSet<Employees> Employees{ get;set;}
        public DbSet<Tag> Tags{ get;set;}
        public DbSet<ObjectTag> ObjectTags{ get;set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationPermission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<ApplicationClaim> RoleDefaultClaimsValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entity.Name).HasKey(nameof(BaseEntity.Id));
                modelBuilder.Entity(entity.Name).Property(nameof(BaseEntity.UpdatedDate));
                modelBuilder.Entity(entity.Name).Property(nameof(BaseEntity.CreatedDate));
            }
            modelBuilder.ApplyConfiguration(new EmployeesEnityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new TagsTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ObjectTagsTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationUserTypeConfigurations());
            modelBuilder.ApplyConfiguration(new RoleTypeConfigurations());
            modelBuilder.ApplyConfiguration(new UserRoleTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationClaimTypeConfigurations());
            modelBuilder.ApplyConfiguration(new ApplicationPermissionsTypeConfigurations(_permissionProvider));
            modelBuilder.ApplyConfiguration(new ApplicationPermissionRolessTypeConfigurations(_permissionProvider));
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetValue<string>("DataSources:DB:connectionString");
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(1, 0, 0)));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}