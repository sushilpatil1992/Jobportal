using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGroupBasedPermissions.Models
{
    public class EmpProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required]

        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]

        [DisplayName("Last Name")]
        public string LName { get; set; }
       
        [DisplayName("Mobile Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper contact details.")]
        public string MobNo { get; set; }
        [DisplayName("Place")]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Company Name")]
        public string Company { get; set; }

        [DisplayName("Industry")]
        public string Industry { get; set; }
        [DisplayName("Company Profile")]
        public string company_profile { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ICollection<Jobpost> Jobposts { get; set; }
    }
}