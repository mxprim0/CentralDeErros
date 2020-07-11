using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Api.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface ILevelRepository
    {
        IEnumerable<Level> Get();
        Level GetById(int Id);
        Level Save(Level item);
        Level Update(Level item);
        bool Delete(int Id);
    }
}
