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
    public class SituationsController : ControllerBase
    {
        private readonly ISituation _service;
        private readonly IMapper _mapper;

        public SituationsController(ISituation service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SituationDTO>> GetSituations()
        {
            var situations = _service.ConsultAllSituations();

            if (situations == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(situations.
                        Select(x => _mapper.Map<SituationDTO>(x)).
                        ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SituationDTO> GetSituation(int id)
        {
            var situation = _service.ConsultSituationById(id);

            if (situation == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SituationDTO>(situation));
        }

        [HttpPut("{id}")]
        public ActionResult<SituationDTO> PutSituation(int id, Situation situation)
        {
            if (id != situation.SituationId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<SituationDTO>(_service.RegisterOrUpdateSituation(situation)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.SituationExists(id))
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
        public ActionResult<SituationDTO> PostSituation([FromBody] SituationDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<SituationDTO>(_service.RegisterOrUpdateSituation(_mapper.Map<Situation>(value))));
        }
    }
}