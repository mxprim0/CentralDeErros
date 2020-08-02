using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Dominio.Interfaces;
using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Data.Interfaces;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Dominio.Services
{
    public class ErrorService : IError
    {
        public IErrorRepository _context;

        public ErrorService(IErrorRepository context)
        {
            this._context = context;
        }

        public Error RegisterOrUpdateLevel(Error error)
        {
            return _context.Save(error);
        }

        public List<Error> ConsultAllErrors()
        {
           
                return _context.Get().ToList();
            
        }

        public Error ConsultErrorById(int id)
        {
            return _context.GetById(id);
        }

        Error IError.RegisterOrUpdateError(Error error)
        {
            return _context.Save(error);
        }
    }
}