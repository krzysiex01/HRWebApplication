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
    }
}
