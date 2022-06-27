using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Data.EntityTypeConfigurations.Tag
{
    public class TagsTypeConfigurations : IEntityTypeConfiguration<Core.Domain.Common.Tag>
    {
        public void Configure(EntityTypeBuilder<Core.Domain.Common.Tag> builder)
        {
            builder.ToTable("Tags");

            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Color);

        }
    }
}
