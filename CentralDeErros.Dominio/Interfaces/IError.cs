using CentralDeErros.Api.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IError
    {
        Error RegisterOrUpdateError(Error error);
        Error ConsultError(int id);
        List<Error> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);
        List<Error> ConsultAllErrors();
        bool ErrorExists(int id);
    }
}