using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetGroupBasedPermissions.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        [Required(ErrorMessage="Please enter the message")]
        public string Notificaion { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual EmpProfile EmpProfile { get; set; }
    }
}