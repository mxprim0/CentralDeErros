using CentralDeErros.Api.Interfaces;
using CentralDeErros.Infra.Entidades;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CentralDeErros.Dominio.Services
{
    class ErrorService: IError
    {
        private ErrorContext _context;
        private ILevel _levelService;
      

        public ErrorService(Error context, ILevel levelService)
        {
            
            _levelService = levelService;
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
