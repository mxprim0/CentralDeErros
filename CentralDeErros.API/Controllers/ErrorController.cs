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
using AutoMapper;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ErrorController : ControllerBase
    {
        public readonly Dominio.Interfaces.IError logs;
        private readonly IMapper _mapper;

        public ErrorController(IError logsService, IMapper mapper)
        {
            logs = logsService;
            _mapper = mapper;

        }
        // GET: api/ErrorOcurrence
        [HttpGet("AllError")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Error>> Get()
        {
          IList<Error> Alllogs = logs.ConsultAllErrors();

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
        public ActionResult<Error> Getbyid(int id)
        {
            var error = logs.ConsultErrorById(id);
            if (error!= null)
            {
                return Ok(error);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public ActionResult<Error> PostEnvironment([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Error valor = _mapper.Map<Error>(value);
            var level = logs.RegisterOrUpdateError(valor);

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
