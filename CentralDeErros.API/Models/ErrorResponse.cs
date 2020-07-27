using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.API.Models
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string[] Detalhes { get; set; }
        public ErrorResponse InnerException { get; set; }

        public static ErrorResponse From(Exception e)
        {
            if (e == null)
            {
                return null;
            }
            return new ErrorResponse
            {
                Codigo = e.HResult,
                Mensagem = e.Message,
                InnerException = ErrorResponse.From(e.InnerException)
            };
        }

        public static ErrorResponse FromIdentity(List<IdentityError> identityError)
        {
            return new ErrorResponse
            {
                Codigo = 400,
                Mensagem = "Houve erro(s) no envio da requisição",
                Detalhes = identityError.Select(e => e.Description).ToArray()
            };
        }
    }
}
