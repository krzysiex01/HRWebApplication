using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class JobOfferViewModel
    {
        public int JobOffersCount { get; set; }
        public List<int> PendingOffers { get; set; }
    }
}
