using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGroupBasedPermissions.Models
{
    public class Profile
    {
        [Key]
        public int UserId{ get; set; }
        [Required]
        
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
       
        [DisplayName("Last Name")]
        public string LName { get; set; }
        [DisplayName("Mobile Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper contact details.")]
        public string MobNo { get; set; }
        [DisplayName("Basic Graduation")]
        public string Graduation { get; set; }
        [DisplayName("Passout Year")]
        public string PassYear { get; set; }
        [DisplayName("Percentage")]
        [Range(1,100,ErrorMessage="Please enter proper Percentage.")]
        public string Percantage { get; set; }
        [DisplayName("12th Percentage")]
        [Range(1, 100,ErrorMessage="Please enter proper Percentage.")]
        public string twelth_Perc { get; set; }
        [DisplayName("10th Percentage")]
        [Range(1, 100,ErrorMessage="Please enter proper Percentage.")]
        
        public string tenth_perc { get; set; }
        [DisplayName("Place")]
        public string Location { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ICollection<Jobpost> Jobposts { get; set; }
    }
}