using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Framework.Account.Users
{
    public class ChangePasswordLogicModel
    {
        public string BaseAddress { get; set; }
        public string EncryptedUserName { get; set; }
        public string ResetToken { get; set; }
    }
}
