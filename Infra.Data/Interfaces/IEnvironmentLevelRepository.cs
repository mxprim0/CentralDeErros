using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Api.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface IEnvironmentLevelRepository
    {
        IEnumerable<EnvironmentLevel> Get();
        EnvironmentLevel GetById(int Id);
        EnvironmentLevel Save(EnvironmentLevel item);
        EnvironmentLevel Update(EnvironmentLevel item);
        bool Delete(int Id);
    }
}
