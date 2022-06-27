using System.ComponentModel.DataAnnotations;

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
