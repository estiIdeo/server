using Health.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Data.EntityTypeConfigurations.Common
{

    public class BaseEnityTypeConfigurations<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

            foreach (var entity in builder.GetType()
            .Where(e => typeof(IEntity).IsAssignableFrom(e.ClrType)))
            {
                builder.Entity(entity.Name).Property(nameof(IEntity.Id))
                    .IsRequired().HasDefaultValueSql("NEWID()");
            }

            builder.Type<TEntity>().HasKey(c => c.Id);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
