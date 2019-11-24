using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public virtual int? CompanyId { get; set; }
        public virtual Company Company { get;set; }
        public string ProviderName { get; set; }
        public string ProviderUserId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        [Display(Name = "E-mail")]
        public string EmailAddress { get; set; }
    }
}
