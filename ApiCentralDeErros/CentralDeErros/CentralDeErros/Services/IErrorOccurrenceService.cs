using CentralDeErros.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    interface IErrorOccurrenceService
    {
        bool RegisterError(Error error, Users user, string origin, string details, DateTime dateTime, string userToken);

        List<ErrorOccurrence> ListOccurencesByLevel(int level);

        List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

    }
}
