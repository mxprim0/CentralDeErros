using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErros.Infra.Entidades;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Dominio.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CentralDeErros.API.Dto;
using Microsoft.AspNetCore.Authorization;
using CentralDeErros.Dominio.Interfaces;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IError logs;

        public ErrorController(IError logsService)
        {
            logs = logsService;
        }
       /* // GET: api/ErrorOcurrence
        [HttpGet("AllError")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        // public ActionResult<List<Error>> Get()
        //{
        /*IError<Error> Alllogs = logs.ConsultAllErrors();

        if (Alllogs.Count() > 0)
        {
            return Ok(Alllogs);
        }
        else
        {
            return NoContent();
        }


    // GET: api/Error/5
    /*[HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST: api/Error
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT: api/Error/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}*/

    }
}

