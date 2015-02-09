namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            EmpProfiles = new HashSet<EmpProfile>();
            Notifications = new HashSet<Notification>();
            Profiles = new HashSet<Profile>();
            Groups = new HashSet<Group>();
            AspNetRoles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        public virtual ICollection<EmpProfile> EmpProfiles { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
