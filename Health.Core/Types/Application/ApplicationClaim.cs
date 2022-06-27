using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Types.Application
{
    public class ApplicationClaim
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string ClaimType { get; set; }
        public string DefaultValue { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
