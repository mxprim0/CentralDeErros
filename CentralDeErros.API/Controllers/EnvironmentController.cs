using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.API.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironment _service;
        private readonly IMapper _mapper;

        public EnvironmentController(IEnvironment service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Environment
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
                return Ok(environments.Select(x => _mapper.Map<EnvironmentDTO>(x)).ToList());
            }
        }

        // GET: api/Environment/5
        [HttpGet("{id}")]
        public ActionResult<EnvironmentDTO> GetEnvironment(int id)
        //public string Get(int id)
        {
            var environment = _service.ConsultEnvironment(id);

            if (environment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EnvironmentDTO>(environment));
        }

        // POST: api/Environment
        [HttpPost]
        public ActionResult<EnvironmentDTO> PostEnvironment([FromBody] EnvironmentDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<EnvironmentDTO>(_service.RegisterOrUpdateEnvironment(_mapper.Map<Infra.Entidades.Environment>(value))));
        }

        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public ActionResult<EnvironmentDTO> PutEnvironment(int id, Infra.Entidades.Environment environment)
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var envFind = _service.FindById(id);

            if (envFind is null)
                return NoContent;

            _service.Remove(id);

            return Ok()
        }
    }
}
