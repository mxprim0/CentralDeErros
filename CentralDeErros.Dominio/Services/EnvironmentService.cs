using CentralDeErros.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Dominio.Interfaces;


namespace CentralDeErros.Dominio.Services
{
    public class EnvironmentService : IEnvironment
    {
        public CentralContext _context;

        public EnvironmentService(CentralContext context)
        {
            this._context = context;
        }

        public List<Infra.Entidades.Environment> ConsultAllEnvironments()
        {
            return _context.Environments.Select(a => a).ToList();
        }

        public Infra.Entidades.Environment ConsultEnvironment(int id)
        {
            return _context.Environments.Find(id);
        }

        public bool EnvironmentExists(int id)
        {
            return _context.Environments.Any(e => e.EnvironmentId == id);
        }

        public Infra.Entidades.Environment RegisterOrUpdateEnvironment(Infra.Entidades.Environment environment)
        {
            var state = environment.EnvironmentId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(environment).State = state;
            _context.SaveChanges();

            return environment;
        }
    }
}
