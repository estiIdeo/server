using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health.Core.Domain.Identity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string Description { get; set; }
        //public string LicenceId { get; set; }
        //public string LicenceTypes { get; set; }
        //public DateTime? LicenceExpire { get; set; }
        //public string LicenceImgIds { get; set; }
        public string TeudatZehut { get; set; }
        //public virtual Member Member { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped] public string FullName => $"{FirstName} {LastName}";
        //public int? TypeId { get; set; }
        //public string Password { get; set; }
        //public string Token { get; set; }
        public string PushToken { get; set; }
        public string CreateUser { get; set; }
        public string UpdateUser { get; set; }
        public TimeSpan? UtcOffset { get; set; }

        //public virtual ICollection<CarOwner> CarOwners { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        //public bool? IsApproved { get; set; }
       
        public virtual ICollection<UserRole> Roles { get; set; }



    }
}
