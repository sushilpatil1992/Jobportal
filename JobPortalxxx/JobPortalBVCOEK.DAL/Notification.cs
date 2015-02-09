namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int Id { get; set; }

        public int from { get; set; }

        public int to { get; set; }

        [Required]
        public string Notificaion { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int? EmpProfile_UserId { get; set; }

        public int? Profile_UserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
