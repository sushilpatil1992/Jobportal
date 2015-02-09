namespace JobPortalBVCOEK.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jobpost
    {
        public int Id { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string JobDiscription { get; set; }

        [Required]
        public string MinExperince { get; set; }

        [Required]
        public string MaxExperince { get; set; }

        [Required]
        public string MinSal { get; set; }

        [Required]
        public string MaxSal { get; set; }

        [Required]
        public string Vacancy { get; set; }

        [Required]
        public string JobLocation { get; set; }

        [Required]
        public string Industry { get; set; }

        [Required]
        public string Company_Name { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string Mobile { get; set; }

        public DateTime JobPostDate { get; set; }

        public DateTime JobPostExpDate { get; set; }

        public int ProfileId { get; set; }

        public int? EmpProfile_UserId { get; set; }

        public int? Job_Applied_Id { get; set; }

        public int? Profile_UserId { get; set; }

        [Required]
        public string company_profile { get; set; }

        public virtual EmpProfile EmpProfile { get; set; }

        public virtual job_applied job_applied { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
