using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Necruit.Api.Common;
using Necruit.Application;
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
        private IMapper mapper;

        public JobsController(IJobService jobService, IMapper mapper)
        {
            this.jobService = jobService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobDetailDto>>> GetAll([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await jobService.GetActives(query);
            return Ok(result);
        }

        [HttpGet("passive")]
        public async Task<ActionResult<List<JobDetailDto>>> GetActices([FromQuery] PageQuery filter)
        {
            var query = new PageRequest(filter.PageNumber, filter.PageSize);
            var result = await jobService.GetPassives(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDetailDto>> GetJobDetail(int id)
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
        public async Task<ActionResult<int>> Pathc(int id, [FromBody] JsonPatchDocument<JobPatchDto> request)
        {
            JobDetailDto job = await jobService.GetDetail(id);
            if (job == null)
                return NotFound();

            var jobPatch = mapper.Map<JobPatchDto>(job);
            request.ApplyTo(jobPatch);

            await jobService.Patch(id, jobPatch);

            return NoContent();
        }
    }
}