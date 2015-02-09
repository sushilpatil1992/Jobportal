using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace AspNetGroupBasedPermissions.Models
{
    public class Jobpost
    {
        private DateTime _Date = DateTime.Now;
        public int Id { get; set; }
        [DisplayName("Job Title")]
        [Required(ErrorMessage = " ")]
        public string JobTitle { get; set; }
        [DisplayName("Job Discription")]
        [Required(ErrorMessage = " Please add Job Discription")]
        public string JobDiscription { get; set; }
        [DisplayName("Minimum Experince")]
        [RegularExpression(@"^(\d+)?$", ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "Minimum Experince is required")]
        [Range(0, 100, ErrorMessage = "Value must between 0 to 100")]
        public string MinExperince { get; set; }

        [Range(0,100,ErrorMessage="Value must between 0 to 100")]
        [RegularExpression(@"^(\d+)?$",ErrorMessage="Enter Numbers Only" )]
        [DisplayName("Maximum Experince")]
        [Required(ErrorMessage = "Maximum Experince is required")]
        public string MaxExperince { get; set; }

        [RegularExpression(@"^(\d+)?$", ErrorMessage = "Enter Numbers Only")]
        [DisplayName("Minimum Salary")]
        [Required(ErrorMessage = "Minimum Salary is required")]
        public string MinSal { get; set; }

        [RegularExpression(@"^(\d+)?$", ErrorMessage = "Enter Numbers Only")]
        [DisplayName("Maximum Salary")]
        [Required(ErrorMessage = "Maximum Salary is required")]
        public string MaxSal { get; set; }
        [DisplayName(" VaCancies")]
        [RegularExpression(@"^(\d+)?$", ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = "VaCancies is required")]
        public string Vacancy { get; set; }
        [DisplayName("Job Location")]
        [Required(ErrorMessage = "Job Location is required")]
        public string JobLocation { get; set; }
        [DisplayName("Industry")]
        [Required(ErrorMessage = "Industry is required")]
        public string Industry { get; set; }
        [DisplayName("Company Name")]
        [Required(ErrorMessage = "Company Name is required")]
        public string Company_Name { get; set; }
        [DisplayName("Contact Person")]
        [Required(ErrorMessage = "Employee Name is required")]      
        public string ContactPerson { get; set; }
        [DisplayName("Company Profile")]
        [Required(ErrorMessage = "Please add Company profile ")] 
        public string company_profile { get; set; }
        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper contact details.")]
        public string Mobile { get; set; }

        [DataType(DataType.Date)]
        
        [Display(Name = "Post Date")]
        [Required(ErrorMessage = "Post date is required")]
        public DateTime JobPostDate
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Date To apply")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime JobPostExpDate { get; set; }
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }


        public virtual EmpProfile EmpProfile { get; set; }
        public virtual job_applied Job_Applied { get; set; }
     
    }

    public enum Location
    {
        
        Pune,
        Mumbai,
        Kolhapur,
    }

    
}