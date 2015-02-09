using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AspNetGroupBasedPermissions.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
            : base()
        {
            this.Groups = new HashSet<ApplicationUserGroup>();
        }

        [Required(ErrorMessage = "Please Enter First Name")]
        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage="Enter valid Email Adress")]
        [Required]
        public string Email { get; set; }

        public string RoleName { get; set; }
        public virtual ICollection<ApplicationUserGroup> Groups { get; set; }

    }
}