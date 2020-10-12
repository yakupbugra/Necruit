using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necruit.Application.Service;
using Necruit.Application.Service.Jobs;
using Necruit.Application.Service.Jobs.Dto;
using System.Collections.Generic;

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
        public ServiceResult<List<JobInfo>> Get()
        {
            return jobService.ListJobs();
        }

        [HttpGet("{id}")]
        public ActionResult<ServiceResult> Get(int id)
        {
            var result = jobService.GetJobDetail(id);

            if (result.Data == null)
                return NotFound();
            else

                return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ServiceResult> Post(CreateJobRequest request)
        {
            var result = jobService.CreateJob(request);

            if (result.Success)
                return CreatedAtAction("Get", new { id = result.Data }, result);
            else

                return result;
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, CreateJobRequest request)
        {
            var result = jobService.UpdateJob(id, request);

            if (result.Success)
                return NoContent();
            else

                return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}