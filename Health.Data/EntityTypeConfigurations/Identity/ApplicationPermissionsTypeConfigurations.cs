using Health.Core.Interfaces.Providers;
using Health.Core.Types.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Data.EntityTypeConfigurations.Identity
{
    public class ApplicationPermissionsTypeConfigurations : IEntityTypeConfiguration<ApplicationPermission>
    {
        private readonly IPermissionProvider _permissionProvider;

        public ApplicationPermissionsTypeConfigurations(IPermissionProvider permissionProvider)
        {
            this._permissionProvider = permissionProvider;
        }

        public void Configure(EntityTypeBuilder<ApplicationPermission> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SystemName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Category).HasMaxLength(255).IsRequired();

            foreach (var permission in _permissionProvider.GetPermissions())
            {
                builder.HasData(permission);
            }

            builder.HasMany(x => x.Roles)
                   .WithOne()
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
