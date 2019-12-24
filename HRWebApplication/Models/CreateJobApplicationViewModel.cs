using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace HRWebApplication.Models
{
    public class CreateJobApplicationViewModel : JobApplication
    {
        public string JobTitle { get; set; }

        public IFormFile UploadedCVFile { get; set; }
    }
}
