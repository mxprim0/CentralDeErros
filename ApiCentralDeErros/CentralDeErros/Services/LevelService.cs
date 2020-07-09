using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Api.Services
{
    public class LevelService : ILevel
    {
        public ErrorDbContext _context;

        public LevelService(ErrorDbContext context)
        {
            this._context = context;
        }

        public Level RegisterOrUpdateLevel(Level level)
        {
            var state = level.LevelId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(level).State = state;
            _context.SaveChanges();
            return level;
        }

        public Level ConsultLevelById(int id)
        {
            return _context.Levels.Find(id);
        }

        public Level ConsultLevelByName(string name)
        {
            return _context.Levels.FirstOrDefault(l => l.LevelName == name);
        }

        public List<Level> ConsultAllLevels()
        {
            return _context.Levels.Select(l => l).ToList();
        }

        public bool LevelExists(int id)
        {
            return _context.Levels.Any(e => e.LevelId == id);
        }
    }
}
