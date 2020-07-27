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

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService logs;

        public LogsController(ILogsService logsService)
        {
            logs = logsService;
        }
        // GET: api/ErrorOcurrence
        [HttpGet("AllLogs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Logs>> Get()
        {
            IList<Logs> Alllogs = logs.AllLogs();

            if (Alllogs.Count()>0)
            {
                return Ok(Alllogs);
            }
            else
            {
                return NoContent();
            }

        }

        // GET: api/ErrorOcurrence
        [HttpGet("GetByEnvironment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<List<Logs>> Get(int env)
        {
            IList<Logs> Alllogs = logs.getLogsByEnvironment(env);

            if (Alllogs.Count() > 0)
            {
                return Ok(Alllogs);
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/ErrorOcurrence
        [HttpPost("Search Logs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Logs> Post([FromBody] SearchDTO searchDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (searchDTO.Type > 3)
            {
                return BadRequest("Tipo de busca deve ser: 1, 2 ou 3");
            }

            IList<Logs> Alllogs = logs.searchLogs(searchDTO.Type, searchDTO.Level, searchDTO.Title, searchDTO.Description);

            if (Alllogs.Count() > 0)
            {
                return Ok(Alllogs);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Add Logs2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Logs> Post([FromBody] Logs log)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = logs.addLog(log);


            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        // PUT: api/ErrorOcurrence/5
        [HttpPut("Archive Logs2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<Logs> Put(int id)
        {
     
            if (id == null)
            {
                return NoContent();
            }

            var result= logs.ArchiveLog(id);

            if (result == null)
            {
                return NoContent();
            }

            return Ok("Log Arquivado");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("Delete Log")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<Logs> Delete(int id)
        {
            var result = logs.DeleteLog(id);
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
