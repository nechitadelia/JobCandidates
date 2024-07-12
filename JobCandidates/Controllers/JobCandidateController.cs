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

        // GET: /AddOrEdit/{email?}
        [HttpGet("AddOrEdit/")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddOrEdit([FromQuery] string? email = null)
        {
            JobCandidate candidate = new JobCandidate();

            if (!string.IsNullOrEmpty(email))
            {
                if (!(await _jobCandidateRepository.CheckIfCandidateExists(email)))
                    return NotFound();

                candidate = await _jobCandidateRepository.GetCandidate(email);

                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            return Ok(candidate);
        }

        // POST: /AddOrEdit/{email?}
        [HttpPost("AddOrEdit/")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddOrEdit([FromBody] JobCandidateDto candidateDto, [FromQuery] string? email = null)
        {
            if (candidateDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //case 1: add a new candidate
            bool candidateExists = await _jobCandidateRepository.CheckIfCandidateExists(candidateDto.Email);

            if (!candidateExists)
            {
                bool resultAdd = _jobCandidateRepository.AddCandidate(candidateDto);
                if (resultAdd)
                {
                    return Ok("New candidate added!");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while adding a new candidate");
                    return StatusCode(500, ModelState);
                }
            }

            //case 2: edit an existing candidate
            bool resultEdit = await _jobCandidateRepository.EditCandidate(candidateDto);

            if (resultEdit)
            {
                return Ok("Existing candidate updated!");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while updating an existing candidate");
                return StatusCode(500, ModelState);
            }
        }
    }
}
