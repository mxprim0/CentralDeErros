﻿using CentralDeErros.Infra.Entidades;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IError
    {
        interface IErrorOccurrenceService
        {
            // cadastra e retorna sucesso ou falha
            bool RegisterError(Error error, Users user, string origin, string details, DateTime dateTime, string userToken);

            // retorna a lista (detalhada) de todos os erros de um tipo de level individualmente
            List<Error> ListOccurencesByLevel(int level);

            // retorna 
            List<Error> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);

        }
    }
}