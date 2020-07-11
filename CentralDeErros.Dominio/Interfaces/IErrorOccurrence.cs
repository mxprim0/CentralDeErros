using CentralDeErros.Api.Entidades;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IErrorOccurrence
    {
        ErrorOccurrence RegisterOrUpdateErrorOccurrence(ErrorOccurrence errorOccurrence);
        ErrorOccurrence ConsultErrorOccurrenceById(int errorOccurrenceId);
        List<ErrorOccurrence> ListOccurencesByLevel(int level);
        List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado); 
        ErrorOccurrence FileErrorOccurrence(ErrorOccurrence errorOccurrence);
        ErrorOccurrence DeleteErrorOccurrence(ErrorOccurrence errorOccurrence);
        bool ErrorOccurrenceExists(int id);
    }
}