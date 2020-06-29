using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name of the comapny.")]
        [Display(Name = "Comapny name")]
        public string  Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
        public virtual List<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}