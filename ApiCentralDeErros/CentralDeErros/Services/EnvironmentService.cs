using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.Api.Services
{
    public class EnvironmentService : IEnvironment
    {
        public ErrorDbContext _context;

        public EnvironmentService(ErrorDbContext context)
        {
            this._context = context;
        }

        public Environment RegisterOrUpdateEnvironment(Environment environment)
        {
            var state = environment.EnvironmentId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(environment).State = state;
            _context.SaveChanges();
            return environment;
        }

        public Environment ConsultEnvironment(int id)
        {
            return _context.Environments.Find(id);
        }

        public List<Environment> ConsultAllEnvironments()
        {
            return _context.Environments.Select(a => a).ToList();
        }

        public bool EnvironmentExists(int id)
        {
            return _context.Environments.Any(e => e.EnvironmentId == id);
        }
    }
}
