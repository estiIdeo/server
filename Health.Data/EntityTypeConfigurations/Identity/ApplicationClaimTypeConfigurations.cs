using Health.Core.Types.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Data.EntityTypeConfigurations.Identity
{
    public class ApplicationClaimTypeConfigurations : IEntityTypeConfiguration<ApplicationClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationClaim> builder)
        {
            builder.ToTable("RoleDefaultClaimsValues");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClaimType).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DefaultValue).IsRequired(false).HasMaxLength(1500);

            builder.HasOne(z => z.Role)
                   .WithMany(z => z.DefaultClaimsValues)
                   .HasForeignKey(z => z.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
