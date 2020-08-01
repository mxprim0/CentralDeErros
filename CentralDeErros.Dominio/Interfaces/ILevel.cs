using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Dominio.Interfaces

{
    public interface ILevel
    {
        Level RegisterOrUpdateLevel(Level level);
        Level ConsultLevelById(int id);
      
        List<Level> ConsultAllLevels();
        

    }
}