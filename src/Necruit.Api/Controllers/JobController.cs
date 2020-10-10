using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necruit.Application.Request;
using Necruit.Application.Service;
using Necruit.Application.Service.Jobs;
using Serilog;
using System.Collections.Generic;


namespace Necruit.Server.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IJobService jobService;
        private IDiagnosticContext diagnosticContext;
        public JobController(IJobService jobService, IDiagnosticContext diagnosticContext)
        {
            this.jobService = jobService;
            this.diagnosticContext = diagnosticContext;
        }

        [HttpGet]
        public ServiceResult<List<JobInfo>> Get()
        {
            return jobService.ListJobs();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}