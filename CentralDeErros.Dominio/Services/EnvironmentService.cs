using CentralDeErros.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Infra.Data.Interfaces;

namespace CentralDeErros.Dominio.Services
{
    public class EnvironmentService : IEnvironment
    {
        public IEnvironmentRepository _context;

        public EnvironmentService(IEnvironmentRepository context)
        {
            this._context = context;
        }

        public List<Infra.Entidades.Environment> ConsultAllEnvironments()
        {
            return _context.Get().ToList();
        }

        public Infra.Entidades.Environment ConsultEnvironment(int id)
        {
            return _context.GetById(id);
        }

        public Infra.Entidades.Environment RegisterOrUpdateEnvironment(Infra.Entidades.Environment environment)
        {
            return _context.Save(environment);
        }
    }
}
