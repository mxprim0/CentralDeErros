using CentralDeErros.Api.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ILevel
    {
        Level RegisterOrUpdateLevel(Level level);
        Level ConsultLevelById(int id);
        Level ConsultLevelByName(string name);
        List<Level> ConsultAllLevels();
        bool LevelExists(int id);
    }
}