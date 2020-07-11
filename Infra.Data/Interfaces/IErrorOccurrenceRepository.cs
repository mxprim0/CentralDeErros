using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Api.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface IErrorOccurrenceRepository
    {
        IEnumerable<ErrorOccurrence> Get();
        ErrorOccurrence GetById(int Id);
        ErrorOccurrence Save(ErrorOccurrence item);
        ErrorOccurrence Update(ErrorOccurrence item);
        bool Delete(int Id);
    }
}
