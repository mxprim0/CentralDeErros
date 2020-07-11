using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorOcurrenceController : ControllerBase
    {
        // GET: api/ErrorOcurrence
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ErrorOcurrence/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ErrorOcurrence
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ErrorOcurrence/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
