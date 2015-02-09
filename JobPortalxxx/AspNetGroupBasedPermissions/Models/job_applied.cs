using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetGroupBasedPermissions.Models
{
    public class job_applied
    {
        public int Id { get; set; }

        public int Seeker_Id { get; set; }

        public int Jobpost_id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Profile> ProfId{ get; set; }
        public virtual ICollection<Jobpost> Jobposts { get; set; }

    }
}