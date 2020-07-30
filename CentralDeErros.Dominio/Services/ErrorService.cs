using CentralDeErros.Api.Interfaces;
using CentralDeErros.Infra.Data.Interfaces;
using CentralDeErros.Infra.Entidades;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeErros.Dominio.Services
{
    public class ErrorService: IError
    {


        public IErrorRepository _context;

        public ErrorService(IErrorRepository context)
        {
            this._context = context;
        }

        public List<Error> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            throw new NotImplementedException();
        }

        public List<Error> ConsultAllErrors()
        {
            throw new NotImplementedException();
        }

        public Error ConsultError(int id)
        {
            throw new NotImplementedException();
        }

        public bool ErrorExists(int id)
        {
            throw new NotImplementedException();
        }

        public Error RegisterOrUpdateError(Error error)
        {           
            return error;
        }
                
        
        public class Occurrences
        {
            public int ErrorId { get; set; }
            public int Quantity { get; set; }
        }

        


    }
}
