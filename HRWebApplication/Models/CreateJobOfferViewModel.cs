﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApplication.Models
{
    public class CreateJobOfferViewModel: JobOffer
    {
		public IEnumerable<Company> Companies { get; set; }
    }
}
