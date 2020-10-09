using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Necruit.Api.Controllers
{
    [Route("api/recruitment")]
    [ApiController]
    public class RecruimentController : ControllerBase
    {
        // GET: api/<RecruimentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RecruimentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet("{id}/talents")]
        public string GetTalents(int id)
        {
            return "value";
        }


        // POST api/<RecruimentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecruimentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecruimentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
