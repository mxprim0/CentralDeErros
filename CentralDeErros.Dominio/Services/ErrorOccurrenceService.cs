using CentralDeErros.Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Providers.Entities;

namespace CentralDeErros.Dominio.Services
{
        interface IErrorOccurrenceService
        {
            // cadastra e retorna sucesso ou falha
            bool RegisterError(Error error, User user, string origin, string details, DateTime dateTime, string userToken);

            // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
            List<Error> ListOccurencesByLevel(int level);

            // retorna 
            List<Error> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

        }
    
}
