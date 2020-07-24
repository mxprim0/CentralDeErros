using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Infra.Data.Interfaces;
using CentralDeErros.Infra.Entidades;

using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Infra.Data.Repository
{
    public class LogsRepository:ILogsRepository
    {
        private readonly CentralContext _context;
        public LogsRepository(CentralContext context)
        {
            _context = context;
        }

        public IEnumerable<Logs> Get()
        {
            return _context.Logs.Where(a=>!a.Archived);
        }

        public List<Logs> GetByLevel(int Level)
        {
            return _context.Logs.Where(a => !a.Archived).Where(x => x.LevelId == Level).ToList();
        }

        public List<Logs> GetByDescription(string description)
        {
            return _context.Logs.Where(a => !a.Archived).Where(a => a.Description.Contains(description)).ToList();
        }

        public List<Logs> GetByTitle(string title)
        {
            return _context.Logs.Where(a => !a.Archived).Where(a => a.Title.Contains(title)).ToList();
        }

        public Logs ArchiveLog(int logId)
        {
            var logToArchive = _context.Logs.Find(logId);
            if (logToArchive == null)
            {
                return null;
            }

            logToArchive.Archived = true;

            _context.Entry(logToArchive).State = EntityState.Modified;
            _context.SaveChanges();

            return logToArchive;
        }


        public List<Logs> GetByEnvironment(int env)
        {
            return _context.Logs.Where(x => x.Error.EnvironmentId == env).ToList();
        }

        public Logs GetById(int Id)
        {
            return _context.Logs.Where(x => x.ErrorOccurrenceId == Id).FirstOrDefault();
        }
        public Logs Save(Logs item)
        {
            var state = item.ErrorOccurrenceId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(item).State = state;
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public Logs Update(Logs item)
        {
            var _item = _context.Logs.Where(x => x.ErrorOccurrenceId == item.ErrorOccurrenceId).FirstOrDefault();

            if (_item != null)
            {
                _item = item;

                _context.Entry(_item).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return item;
        }
        public Logs Delete(int Id)
        {
            var _erros = _context.Logs.Where(x => x.ErrorOccurrenceId == Id).FirstOrDefault();

            if (_erros != null)
            {
                _context.Entry(_erros).State = EntityState.Deleted;
                _context.SaveChanges();
                return _erros;
            }
            return _erros;
        }

    }
}
