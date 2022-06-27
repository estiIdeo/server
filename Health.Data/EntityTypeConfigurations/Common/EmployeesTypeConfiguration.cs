using Health.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Data.EntityTypeConfigurations.Common
{
    public class EmployeesEnityTypeConfigurations : IEntityTypeConfiguration<Employees>
    {

        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("Employees");

            builder.Property(x => x.EmployeeFirstName).IsRequired(false).HasMaxLength(512);

            builder.Property(x => x.EmployeeLastName);
            builder.Property(x => x.Salary).HasColumnType("decimal");
            builder.Property(x => x.Address);


        }
    }
}
