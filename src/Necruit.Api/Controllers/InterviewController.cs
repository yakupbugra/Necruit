using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Necruit.Api.Controllers
{
    [Route("api/interview")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        // GET: api/<InterviewController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InterviewController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InterviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InterviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
