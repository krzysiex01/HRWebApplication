using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class JobOfferListViewModel
    {
        public List<JobOffer> JobOffers { get; set; }
        public List<int> PendingOffers { get; set; }

    }
}
