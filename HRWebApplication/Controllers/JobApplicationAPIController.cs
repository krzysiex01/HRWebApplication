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
    public class JobApplicationAPIController : ControllerBase
    {
        private readonly DataContext _context;
        public JobApplicationAPIController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets list of job applications.
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>List of applications for given offerId.</returns>
        [HttpGet("{offerId}")]
        public async Task<IEnumerable<JobApplication>> GetJobApplications(int offerId)
        {
            var offer = await _context.JobApplications.Where((jobApplication) => jobApplication.JobOfferId == offerId).ToListAsync();
            return offer;
        }

        /// <summary>
        /// Updates job application.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (application == null)
            {
                return NotFound();
            }

            application.FirstName = model.FirstName;
            application.LastName = model.LastName;
            application.PhoneNumber = model.PhoneNumber;
            application.EmailAddress = model.EmailAddress;
            application.CvUrl = model.CvUrl;
            application.ContactAgreement = model.ContactAgreement;
            _context.Update(application);
            await _context.SaveChangesAsync();
            return Accepted();
        }
    }
}