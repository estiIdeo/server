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
    public class EmployeesTypeConfigurations : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.EmployeeId);

            builder.Property(x => x.EmployeeFirstName).IsRequired(false).HasMaxLength(512);

            builder.Property(x => x.EmployeeLastName);
            builder.Property(x => x.Salary).HasColumnType("decimal");
            builder.Property(x => x.Address);


        }
    }
}
