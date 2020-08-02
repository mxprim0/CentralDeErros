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
using AutoMapper;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService logs;
        private readonly IMapper _mapper;

        public LogsController(ILogsService logsService, IMapper mapper)
        {
            logs = logsService;
            _mapper = mapper;

        }
        // GET: api/ErrorOcurrence
        [HttpGet("Trazer todos os Logs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<LogsResponseDTO>> Get()
        {
            IList<LogsResponseDTO> Alllogs = logs.AllLogs();

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
        [HttpGet("Trazer todos os logs por EnvironmentID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<List<LogsResponseDTO>> Get(int env)
        {
            IList<LogsResponseDTO> Alllogs = logs.getLogsByEnvironment(env);

            if (Alllogs.Count() > 0)
            {
                return Ok(Alllogs);
            }
            else
            {
                return NoContent();
            }
        }



        [HttpPost("Buscar Logs por Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LogsResponseDTO> Post([FromBody] GetByIdDTO id)
        {
            LogsResponseDTO log = logs.getById(id.ID);

            if (log==null)
            {
                return NotFound("Log Não Encontrado");
            }
            else
            {
                return Ok(log);
            }
        }

        // POST: api/ErrorOcurrence
        [HttpPost("Procurar Logs: 1 por Level, 2 Descricao, 3 Titulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<LogsResponseDTO> Post([FromBody] SearchDTO searchDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (searchDTO.Type > 3||searchDTO.Type < 1)
            {
                return BadRequest("Tipo de busca deve ser: 1, 2 ou 3");
            }

            IList<LogsResponseDTO> Alllogs = logs.searchLogs(searchDTO.Type, searchDTO.Level, searchDTO.Title, searchDTO.Description);

            if (Alllogs.Count() > 0)
            {
                return Ok(Alllogs);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Adicionar novo Log")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Logs> Post([FromBody] LogsDTO log)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Logs DtoToLog = _mapper.Map<Logs>(log);

            var result = logs.addLog(DtoToLog);

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
        [HttpPut("Arquivar Logs")]
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
        [HttpDelete("Deletar Logs")]
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
