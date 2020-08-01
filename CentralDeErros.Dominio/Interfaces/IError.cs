using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Dominio.Interfaces

{
    public interface IError
    {
        Error RegisterOrUpdateError(Error error);
        Error ConsultErrorById(int id);

        List<Error> ConsultAllErrors();

    }
}