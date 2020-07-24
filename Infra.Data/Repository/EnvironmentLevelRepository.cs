using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentralDeErros.Infra.Entidades;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Infra.Data.Repository
{
    public class EnvironmentLevelRepository:IEnvironmentLevelRepository
    {
        private readonly CentralContext _context;
        public EnvironmentLevelRepository(CentralContext context)
        {
            _context = context;
        }

        public IEnumerable<EnvironmentLevel> Get()
        {
            return _context.EnvironmentLevels;
        }

        public EnvironmentLevel GetById(int Id)
        {
            return _context.EnvironmentLevels.Where(x => x.EnvironmentId == Id).FirstOrDefault();
        }
        public EnvironmentLevel Save(EnvironmentLevel item)
        {
            var state = item.EnvironmentId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(item).State = state;
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public EnvironmentLevel Update(EnvironmentLevel item)
        {
            var _item = _context.EnvironmentLevels.Where(x => x.EnvironmentId == item.EnvironmentId).FirstOrDefault();

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
            var _environment = _context.EnvironmentLevels.Where(x => x.EnvironmentId == Id).FirstOrDefault();

            if (_environment != null)
            {
                _context.Entry(_environment).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
