using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Api.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface IErrorRepository
    {
        IEnumerable<Error> Get();
        Error GetById(int Id);
        Error Save(Error item);
        Error Update(Error item);
        bool Delete(int Id);
    }
}
