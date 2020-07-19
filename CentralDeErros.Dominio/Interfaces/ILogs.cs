using CentralDeErros.Api.Entidades;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ILogs
    {
        Logs RegisterOrUpdateErrorOccurrence(Logs errorOccurrence);
        Logs ConsultErrorOccurrenceById(int errorOccurrenceId);
        List<Logs> ListOccurencesByLevel(int level);
        List<Logs> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado); 
        Logs FileErrorOccurrence(Logs errorOccurrence);
        Logs DeleteErrorOccurrence(Logs errorOccurrence);
        bool ErrorOccurrenceExists(int id);
    }
}