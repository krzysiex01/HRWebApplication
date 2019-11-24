using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public virtual int JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Phone(ErrorMessage ="Please enter valid phone number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter valid email address.")]
        [Display(Name = "E-mail")]
        public string EmailAddress { get; set; }
        public bool ContactAgreement { get; set; }
        [DataType(DataType.Url)]
        public string CvUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}
