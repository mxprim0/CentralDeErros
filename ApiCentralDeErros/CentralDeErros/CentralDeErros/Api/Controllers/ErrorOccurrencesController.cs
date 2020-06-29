using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.Models;
using CentralDeErros.Api.Interfaces;
using AutoMapper;
using CentralDeErros.Api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class ErrorOccurrencesController : ControllerBase
    {
        private readonly IErrorOccurrence _service;
        private readonly IUser _userService;
        private readonly IError _errorService;
        private readonly ISituation _situationService;
        private readonly IMapper _mapper;

        public ErrorOccurrencesController(IErrorOccurrence service, IUser userService, 
            IError errorService, ISituation situationService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _errorService = errorService;
            _situationService = situationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ErrorOccurrenceDTO>> GetErrorOccurrences()
        {
            var errorOccurrences = _service.ListOccurencesByLevel(1);

            if (errorOccurrences == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errorOccurrences.
                        Select(x => _mapper.Map<ErrorOccurrenceDTO>(x)).
                        ToList());
            }
        }

        [HttpGet("Level={levelId}")]
        public ActionResult<IEnumerable<ErrorOccurrenceDTO>> GetErrorOccurrencesByLevel(int levelId)
        {
            var errorOccurrences = _service.ListOccurencesByLevel(levelId);

            if (errorOccurrences == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errorOccurrences.
                        Select(x => _mapper.Map<ErrorOccurrenceDTO>(x)).
                        ToList());
            }
        }

        [HttpPost("Delete/{value}")]
        public ActionResult<ErrorOccurrence> DeleteErrorOccurrence([FromBody] ErrorOccurrenceDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.ConsultErrorOccurrenceById(value.ErrorOccurrenceId) == null)
                return BadRequest("400 BadRequest: ErrorOccurence does not exists.");

            return Ok(_mapper.Map<ErrorOccurrenceDTO>(_service.DeleteErrorOccurrence
                (_mapper.Map<ErrorOccurrence>(value))));
        }

        [HttpPost("File/{value}")]
        public ActionResult<ErrorOccurrence> FileErrorOccurrence([FromBody] ErrorOccurrenceDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_service.ConsultErrorOccurrenceById(value.ErrorOccurrenceId) == null)
                return BadRequest("400 BadRequest: ErrorOccurence does not exists.");

            return Ok(_mapper.Map<ErrorOccurrenceDTO>(_service.FileErrorOccurrence
                (_mapper.Map<ErrorOccurrence>(value))));
        }

        [HttpGet("{ambiente}/{campoOrdenacao}/{campoBuscado}/{textoBuscado}")]
        public ActionResult<List<ErrorOccurrenceDTO>> GetErrorFilter(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            var errorOccurrences = _service.Consult(ambiente, campoOrdenacao, campoBuscado, textoBuscado);

            if (errorOccurrences == null)
            {
                return NotFound();
            } 
            else
            {
                return Ok(errorOccurrences.
                        Select(x => _mapper.Map<ErrorOccurrenceDTO>(x)).
                        ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ErrorOccurrenceDTO> GetErrorOccurrence(int id)
        {
            var errorOccurrence = _service.ConsultErrorOccurrenceById(id);

            if (errorOccurrence == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ErrorOccurrenceDTO>(errorOccurrence));
        }

        [HttpPut("{id}")]
        public ActionResult<ErrorOccurrenceDTO> PutErrorOccurrence(int id, ErrorOccurrence errorOccurrence)
        {
            if (id != errorOccurrence.ErrorOccurrenceId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<ErrorOccurrenceDTO>
                    (_service.RegisterOrUpdateErrorOccurrence(errorOccurrence)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ErrorOccurrenceExists(id))
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
        public ActionResult<ErrorOccurrence> PostErrorOccurrence([FromBody] ErrorOccurrenceDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userService.UserExists(value.UserId))
                return BadRequest("400 BadRequest: User does not exists.");

            if (!_errorService.ErrorExists(value.ErrorId))
                return BadRequest("400 BadRequest: Error does not exists.");

            if (!_situationService.SituationExists(value.SituationId))
                return BadRequest("400 BadRequest: Situation does not exists.");

            return Ok(_mapper.Map<ErrorOccurrenceDTO>
                (_service.RegisterOrUpdateErrorOccurrence(_mapper.Map<ErrorOccurrence>(value))));
        }
    }
}