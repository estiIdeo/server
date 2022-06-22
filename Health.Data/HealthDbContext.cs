using Health.Core.Domain;
using Health.Core.Domain.Common;
using Health.Data.EntityTypeConfigurations.Common;
using Health.Data.EntityTypeConfigurations.Tag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace Health.Data
{
    public class HealthDbContext : DbContext
    {
        public HealthDbContext(DbContextOptions<HealthDbContext> options) : base(options)
        {

        }

        public DbSet<Employees> Employees{ get;set;}
        public DbSet<Tag> Tags{ get;set;}
        public DbSet<ObjectTag> ObjectTags{ get;set; }

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