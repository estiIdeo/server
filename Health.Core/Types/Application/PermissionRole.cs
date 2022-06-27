using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Types.Application
{
    public class PermissionRole
    {
        public long PermissionId { get; set; }
        public long RoleId { get; set; }
        public virtual ApplicationPermission Permission { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
