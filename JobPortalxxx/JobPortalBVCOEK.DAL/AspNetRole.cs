namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetRole
    {
        public AspNetRole()
        {
            Groups = new HashSet<Group>();
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
