using Health.Core.Interfaces.Providers;
using Health.Core.Types.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Data.EntityTypeConfigurations.Identity
{
    public class ApplicationPermissionRolessTypeConfigurations : IEntityTypeConfiguration<PermissionRole>
    {
        private readonly IPermissionProvider _permissionProvider;

        public ApplicationPermissionRolessTypeConfigurations(IPermissionProvider permissionProvider)
        {
            this._permissionProvider = permissionProvider;
        }

        public void Configure(EntityTypeBuilder<PermissionRole> builder)
        {
            builder.ToTable("PermissionRoles");
            builder.HasKey(x => new { x.PermissionId, x.RoleId });

            builder.HasOne(x => x.Permission)
                   .WithMany(x => x.Roles)
                   .HasForeignKey(x => x.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);

            var data = new List<PermissionRole>();

            foreach (var defaultPermission in _permissionProvider.GetDefaultPermissions())
            {
                foreach (var permission in defaultPermission.Permissions)
                {
                    data.Add(new PermissionRole
                    {
                        RoleId = defaultPermission.RoleId,
                        PermissionId = permission.Id
                    });
                }
            }
            if (data?.Any() ?? false)
            {
                builder.HasData(data);
            }
        }
    }

}
