using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Framework.Account.Authentication
{
    public class AuthenticationRequestLogicModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


    }
    public class ResendPasswordRequestLogicModel
    {
        [Required]
        public string Username { get; set; }


    }
}
