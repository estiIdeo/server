using System.ComponentModel.DataAnnotations;

namespace Health.Core.Framework.Account.Users
{
    public class UserRegistrationLogicModel
    {
        [Required]
        [MinLength(6)]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //[Required]
        [MinLength(6, ErrorMessage = "The password must be between 10 and 20 characters")]
        [MaxLength(20, ErrorMessage = "The password must be between 10 and 20 characters")]
        //[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Use a mix of letters, numbers & symbols")]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PushToken { get; set; }

        public string Role { get; set; }
        public DateTime? LockoutEnd { get; set; }

        public bool? TwoFactorEnabled { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool? IsApproved { get; set; }


    }
}
