using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface ISituationRepository
    {
        IEnumerable<Situation> Get();
        Situation GetById(int Id);
        Situation Save(Situation item);
        Situation Update(Situation item);
        bool Delete(int Id);
    }
}
