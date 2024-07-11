using Microsoft.AspNetCore.Mvc;

namespace JobCandidates
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateController : Controller
    {
        private readonly IJobCandidateRepository _jobCandidateRepository;

        public JobCandidateController(IJobCandidateRepository jobCandidateRepository)
        {
            _jobCandidateRepository = jobCandidateRepository;
        }

        // GET: JobCandidates/AddOrEdit/
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(JobCandidate))]
        public IActionResult AddOrEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return Ok(id);
        }

        // POST: JobCandidates/AddOrEdit/
        [HttpPost]
        public IActionResult AddOrEdit([FromBody] string value)
        {
            return Ok();
        }
    }
}
