using Microsoft.AspNetCore.Mvc;

namespace JobCandidates
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateController : ControllerBase
    {
        public JobCandidateController() { }

        // GET: JobCandidates/AddOrEdit/
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<int>))]
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
