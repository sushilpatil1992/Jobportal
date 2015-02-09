namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmpProfile
    {
        public EmpProfile()
        {
            Jobposts = new HashSet<Jobpost>();
            Notifications = new HashSet<Notification>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LName { get; set; }

        public string MobNo { get; set; }

        public string Location { get; set; }

        [Required]
        public string Email { get; set; }

        public string Company { get; set; }

        public string Industry { get; set; }

        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public string company_profile { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual ICollection<Jobpost> Jobposts { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
