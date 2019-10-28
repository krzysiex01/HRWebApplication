using System;
using System.Collections.Generic;
using System.Linq;
using HRWebApplication.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRWebApplication.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        [Display(Name = "Job title")]
        [Required]
        public string Title { get; set; }
        public virtual Company Company { get; set; }
        public virtual int CompanyId { get; set; }
        [Required]
        [MinLength(5)]
        public string Description { get; set; }
        [Display(Name = "Overview")]
        public string Overview { get; set; }
        [Display(Name = "Salary from")]
        public int SalaryFrom { get; set; }
        [Display(Name = "Salary to")]
        public int SalaryTo { get; set; }
        [Display(Name = "Currency")]
        public Currency Currency { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        public DateTime AddedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [Display(Name = "Valid until")]
        public DateTime? ValidUntil { get; set; }
        [Display(Name = "Specialization")]
        public string Specialization { get; set; }

        public List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
