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
using CentralDeErros.Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            IList<Infra.Entidades.Environment> environments = _service.ConsultAllEnvironments();
            if (environments.Count() < 0)
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

    }
}
