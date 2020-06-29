using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.Api.DTOs;
using AutoMapper;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EnvironmentsController : ControllerBase
    {
        private readonly IEnvironment _service;
        private readonly IMapper _mapper;

        public EnvironmentsController(IEnvironment service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Environments
        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentDTO>> GetEnvironments()
        {
            var environments = _service.ConsultAllEnvironments();

            if (environments == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(environments.
                        Select(x => _mapper.Map<EnvironmentDTO>(x)).
                        ToList());
            }
        }

        // GET: api/Environments/5
        [HttpGet("{id}")]
        public ActionResult<EnvironmentDTO> GetEnvironment(int id)
        {
            var environment = _service.ConsultEnvironment(id);

            if (environment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EnvironmentDTO>(environment));
        }

        // PUT: api/Environments/5
        [HttpPut("{id}")]
        public ActionResult<EnvironmentDTO> PutEnvironment(int id, Environment environment)
        {
            if (id != environment.EnvironmentId)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<EnvironmentDTO>(_service.RegisterOrUpdateEnvironment(environment)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.EnvironmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Environments
        [HttpPost]
        public ActionResult<EnvironmentDTO> PostEnvironment([FromBody] EnvironmentDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<EnvironmentDTO>(_service.RegisterOrUpdateEnvironment(_mapper.Map<Environment>(value))));
        }
    }
}
