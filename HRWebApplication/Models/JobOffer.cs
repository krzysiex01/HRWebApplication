using System;
using System.Collections.Generic;
using System.Linq;
using HRWebApplication.Models;
using HRWebApplication.Models.Validation;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HRWebApplication.Models
{
    public class JobOffer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Your offer has no title!")]
        [DataType(DataType.Text)]
        [Display(Name = "Job title")]
        public string Title { get; set; }
        public virtual Company Company { get; set; }
        public virtual int CompanyId { get; set; }

        [Required(ErrorMessage = "Please enter description of your offer.")]
        [MinLength(10,ErrorMessage = "Your description is too short.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter overview of your offer.")]
        [MaxLength(100,ErrorMessage = "Your overview is too long.")]
        [Display(Name = "Overview")]
        public string Overview { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Salary has to be greater than 0.")]
        [Display(Name = "Salary from")]
        public int SalaryFrom { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Salary has to be greater than 0.")]
        [IsGreaterThan("SalaryFrom",true, ErrorMessage = "Incorrect value.")]
        [Display(Name = "Salary to")]
        public int SalaryTo { get; set; }
        [Display(Name = "Currency")]
        public Currency Currency { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        public DateTime AddedOn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [IsPastDate(true, ErrorMessage = "Selected date is invalid.")]
        [Display(Name = "Valid until")]
        public DateTime? ValidUntil { get; set; }

        [Required(ErrorMessage = "Please enter specialization.")]
        [Display(Name = "Specialization")]
        public string Specialization { get; set; }
        public virtual List<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    }
}
