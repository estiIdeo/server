using Health.Core;
using Health.Core.Types.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Data.EntityTypeConfigurations.Identity
{
    public class RoleTypeConfigurations : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(new ApplicationRole
            {
                Id = 1,
                Name = Constants.Configuration.Identity.Roles.Admin,
                IsSystem = true,
                ParentRoleId = 0,
                NormalizedName = Constants.Configuration.Identity.Roles.Admin.ToUpper()
            }, new ApplicationRole
            {
                Id = 2,
                Name = Constants.Configuration.Identity.Roles.PartnerAdmin,
                IsSystem = true,
                ParentRoleId = 0,
                NormalizedName = Constants.Configuration.Identity.Roles.PartnerAdmin.ToUpper()
            }, new ApplicationRole
            {
                Id = 3,
                Name = Constants.Configuration.Identity.Roles.Customer,
                IsSystem = true,
                ParentRoleId = 0,
                NormalizedName = Constants.Configuration.Identity.Roles.Customer.ToUpper()
            });

            builder.HasOne(x => x.ParentRole)
                   .WithMany()
                   .HasForeignKey(x => x.ParentRoleId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
