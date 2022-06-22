using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Health.Core.Domain.Common;
using Health.Data.EntityTypeConfigurations.Common;

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
