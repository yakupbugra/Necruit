using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Necurit.Application;
using Necurit.Application.Data.Request;
using Necurit.Application.Data.Service;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Necruit.Server.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ServiceResult<CreateJobResponse>> Post(CreateJobRequest request)
        {
            var result = jobService.CreateJob(request);

            if (result.Success)

                return Created("job", result);
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