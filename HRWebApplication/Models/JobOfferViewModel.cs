using System;
using System.Collections.Generic;
using System.Linq;
using HRWebApplication.Models;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class JobOfferViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Overview { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public Currency Currency { get; set; }
        public string Location { get; set; }
        public DateTime AddedOn { get; set; }
        public string Specialization { get; set; }
        public List<string> Requirements { get; set; }
    }
}
