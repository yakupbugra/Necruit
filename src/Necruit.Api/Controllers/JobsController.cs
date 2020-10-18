using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Necruit.Api.Common;
using Necruit.Api.Filters;
using Necruit.Application.Service.Jobs;
using Necruit.Application.Service.Jobs.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Necruit.Server.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private IJobService jobService;

        public JobsController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobDto>>> GetJobs([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await jobService.GetActives(query);
            return Ok(result);
        }

        [HttpGet("passive")]
        public async Task<ActionResult<List<JobDto>>> GetAllJobs([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await jobService.GetPassives(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJobDetail(int id)
        {
            var result = await jobService.GetDetail(id);

            if (result == null)
                return NotFound();
            else

                return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Post(CreateUpdateJobDto request)
        {
            var result = await jobService.Create(request);

            return CreatedAtAction("Get", new { id = result });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, CreateUpdateJobDto request)
        {
            var result = await jobService.Update(id, request);
            if (result == 0)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await jobService.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<int>> Pathc(int id, JsonPatchDocument<JobDto> request)
        {
            JobDto job = await jobService.GetDetail(id);
            if (job == null)
                return NotFound();
            request.ApplyTo(job);

            await jobService.Patch(id, job);

            return NoContent();
        }
    }
}