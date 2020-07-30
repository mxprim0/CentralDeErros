using CentralDeErros.Infra.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ILevel
    {
        Level RegisterOrUpdateLevel(Level level);
        Level ConsultLevelById(int id);
      
        List<Level> ConsultAllLevels();
       
    }
}