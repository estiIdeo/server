using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Framework.Account.Security
{
    public class PermissionLogicModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Category { get; set; }
        public IEnumerable<long> RoleIds { get; set; }
    }
}
