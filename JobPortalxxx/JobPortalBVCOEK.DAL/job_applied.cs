namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class job_applied
    {
        public job_applied()
        {
            Jobposts = new HashSet<Jobpost>();
            Profiles = new HashSet<Profile>();
        }

        public int Id { get; set; }

        public int Seeker_Id { get; set; }

        public int Jobpost_id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Jobpost> Jobposts { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
