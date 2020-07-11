using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentralDeErros.Api.Entidades;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Infra.Data.Repository
{
     public class LevelRepository:ILevelRepository
    {
        private readonly CentralContext _context;
        public LevelRepository(CentralContext context)
        {
            _context = context;
        }

        public IEnumerable<Level> Get()
        {
            return _context.Levels;
        }

        public Level GetById(int Id)
        {
            return _context.Levels.Where(x => x.LevelId == Id).FirstOrDefault();
        }
        public Level Save(Level item)
        {
            var state = item.LevelId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(item).State = state;
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public Level Update(Level item)
        {
            var _item = _context.Levels.Where(x => x.LevelId == item.LevelId).FirstOrDefault();

            if (_item != null)
            {
                _item = item;

                _context.Entry(_item).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return item;
        }
        public bool Delete(int Id)
        {
            var _erros = _context.Levels.Where(x => x.LevelId == Id).FirstOrDefault();

            if (_erros != null)
            {
                _context.Entry(_erros).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
