using System.ComponentModel.DataAnnotations;

namespace Health.Core.Framework.Account.Users
{
    public class ForgotPasswordLogicModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ResetToken { get; set; }

    }
}
