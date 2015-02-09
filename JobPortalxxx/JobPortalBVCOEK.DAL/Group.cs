namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        public Group()
        {
            AspNetRoles = new HashSet<AspNetRole>();
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
