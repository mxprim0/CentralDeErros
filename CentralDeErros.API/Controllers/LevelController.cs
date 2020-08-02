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
using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.API.Dto;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly Dominio.Interfaces.ILevel logs;

        public LevelController(ILevel logsService)
        {
            logs = logsService;
        }
        // GET: api/ErrorOcurrence
        [HttpGet("AllLevel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Level>> Get()
        {
            IList<Level> Alllogs = logs.ConsultAllLevels();

            if (Alllogs.Count() > 0)
            {
                return Ok(Alllogs);
            }
            else
            {
                return NoContent();
            }

        }
                
        // GET: api/Level/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
          //  return "value";
        //}
        // GET api//5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Level> Getbyid(int id)
        {
            var level = logs.ConsultLevelById(id);
            if (level != null)
            {
                return Ok(level);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
