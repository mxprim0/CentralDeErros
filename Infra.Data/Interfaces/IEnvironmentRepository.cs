using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface IEnvironmentRepository
    {
        IEnumerable<Infra.Entidades.Environment> Get();
        Infra.Entidades.Environment GetById(int Id);
        Infra.Entidades.Environment Save(Infra.Entidades.Environment item);
        Infra.Entidades.Environment Update(Infra.Entidades.Environment item);
        bool Delete(int Id);
    }
}
