using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRWebApplication.Models;
using HRWebApplication.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace HRWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationAPIController : ControllerBase
    {
        private readonly DataContext _context;
        public JobApplicationAPIController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{offerId}")]
        public async Task<IEnumerable<JobApplication>> GetJobApplications(int offerId)
        {
            var offer = await _context.JobApplications.Where((jobApplication) => jobApplication.OfferId == offerId).ToListAsync();
            return offer;
        }
    }
}