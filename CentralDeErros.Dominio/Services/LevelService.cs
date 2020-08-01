using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Dominio.Interfaces;
using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Data.Interfaces;
using CentralDeErros.Infra.Entidades;




namespace CentralDeErros.Dominio.Services
{
    public class LevelService : ILevel
    {
        public ILevelRepository _context;

        public LevelService(ILevelRepository context)
        {
            this._context = context;
        }

        public Level RegisterOrUpdateLevel(Level level)
        {
            return _context.Save(level);
        }

        public List<Level> ConsultAllLevels()
        {
            try
            {
                return _context.Get().ToList();
            }
            catch
            {
                return new List<Level>();
            }
        }

        public Level ConsultLevelById(int id)
        {
            return _context.GetById(id);
        }
                   
       
        
    }
}

