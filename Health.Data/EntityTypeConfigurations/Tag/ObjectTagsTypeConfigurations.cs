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
    public class ObjectTagsTypeConfigurations : IEntityTypeConfiguration<ObjectTag>
    {
        public void Configure(EntityTypeBuilder<ObjectTag> builder)
        {
            builder.ToTable("ObjectTags");

            builder.HasOne(o => o.Tag)
                 .WithMany()
                 .HasForeignKey(z => z.TagId)
                 .OnDelete(DeleteBehavior.Cascade);

          /*  builder.HasOne(o => o.Object)
              .WithMany()
              .HasForeignKey(z => z.ObjectId)
              .OnDelete(DeleteBehavior.SetNull);*/

            builder.Property(x => x.TagType);

        }
    }
}
