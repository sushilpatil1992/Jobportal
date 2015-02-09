namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profile
    {
        public Profile()
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

        public string Graduation { get; set; }

        public string PassYear { get; set; }

        public string Percantage { get; set; }

        public string twelth_Perc { get; set; }

        public string tenth_perc { get; set; }

        public string Location { get; set; }

        [Required]
        public string Email { get; set; }

        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public int? job_applied_Id { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual job_applied job_applied { get; set; }

        public virtual ICollection<Jobpost> Jobposts { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
