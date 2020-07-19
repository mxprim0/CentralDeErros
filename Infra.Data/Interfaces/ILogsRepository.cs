using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Api.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface ILogsRepository
    {
        IEnumerable<Logs> Get();
        Logs GetById(int Id);
        Logs Save(Logs item);
        Logs Update(Logs item);
        bool Delete(int Id);
    }
}
