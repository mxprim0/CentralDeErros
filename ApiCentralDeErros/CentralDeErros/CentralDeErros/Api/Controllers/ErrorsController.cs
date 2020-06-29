using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using CentralDeErros.Api.Interfaces;
using AutoMapper;
using CentralDeErros.Api.DTOs;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly IError _service;
        private readonly IEnvironment _environmentService;
        private readonly ILevel _levelService;
        private readonly IMapper _mapper;

        public ErrorsController(IError service, IEnvironment environmentService, 
            ILevel levelService, IMapper mapper)
        {
            _service = service;
            _environmentService = environmentService;
            _levelService  = levelService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ErrorDTO>> GetErrors()
        {
            var errors = _service.ConsultAllErrors();

            if (errors == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errors.
                        Select(x => _mapper.Map<ErrorDTO>(x)).
                        ToList());
            }
        }

        [HttpGet("{ambiente}/{campoOrdenacao}/{campoBuscado}/{textoBuscado}")]
        public ActionResult<List<ErrorDTO>> GetErrorFilter(int ambiente, int campoOrdenacao, 
            int campoBuscado, string textoBuscado)
        {
            var errors = _service.Consult(ambiente, campoOrdenacao, campoBuscado, textoBuscado);

            if (errors == null)
            {
                return NotFound();
            }

            return Ok(errors.
                        Select(x => _mapper.Map<ErrorDTO>(x)).
                        ToList()); ;
        }

        [HttpGet("{id}")]
        public ActionResult<ErrorDTO> GetError(int id)
        {
            var error = _service.ConsultError(id);

            if (error == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ErrorDTO>(error));
        }

        [HttpPut("{id}")]
        public ActionResult<ErrorDTO> PutError(int id, Error error)
        {
            if (id != error.ErrorId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<ErrorDTO>(_service.RegisterOrUpdateError(error)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ErrorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public ActionResult<Error> PostError([FromBody] ErrorDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_environmentService.EnvironmentExists(value.EnvironmentId))
                return BadRequest("400 BadRequest: Environment does not exists.");

            if (!_levelService.LevelExists(value.LevelId))
                return BadRequest("400 BadRequest: Level does not exists.");

            return Ok(_mapper.Map<ErrorDTO>(_service.RegisterOrUpdateError(_mapper.Map<Error>(value))));
        }
    }
}