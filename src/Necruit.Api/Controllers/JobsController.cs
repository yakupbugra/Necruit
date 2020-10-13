using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necruit.Application.Service.Jobs;
using Necruit.Application.Service.Jobs.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necruit.Server.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJobService jobService;

        public JobsController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobInfo>>> GetJobs()
        {
            return Ok(await jobService.ListJobs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobInfo>> GetJobDetail(int id)
        {
            var result = await jobService.GetJobDetail(id);

            if (result == null)
                return NotFound();
            else

                return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post(CreateJobRequest request)
        {
            var result = await jobService.CreateJob(request);

            return CreatedAtAction("Get", new { id = result });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, CreateJobRequest request)
        {
            var result = await jobService.UpdateJob(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}