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

        public IEnumerable<LogsResponseDTO> Get()
        {
            var log = (from l in _context.Logs
                       join e in _context.Errors
                       on l.ErrorId equals e.ErrorId
                       join f in _context.Levels
                       on e.LevelId equals f.LevelId
                       where l.Archived == false
                       select new LogsResponseDTO
                       {
                           Archived = l.Archived,
                           Description = l.Description,
                           Events = l.Events,
                           LevelName = f.LevelName,
                           CreatedAt = l.CreatedAt,
                           Title = e.Title,
                           UserName = l.UserName
                       }).ToList();

            return log;
        }

        public List<LogsResponseDTO> GetByLevel(int Level)
        {
            var log = (       from l in _context.Logs
                              join e in _context.Errors
                              on l.ErrorId equals e.ErrorId
                              join f in _context.Levels
                              on e.LevelId equals f.LevelId
                              where e.LevelId == Level
                              select new LogsResponseDTO
                              {
                                  Archived = l.Archived,
                                  Description = l.Description,
                                  Events = l.Events,
                                  LevelName = f.LevelName,
                                  CreatedAt = l.CreatedAt,
                                  Title = e.Title,
                                  UserName = l.UserName
                              }).ToList();

            return log;
        }

        public List<LogsResponseDTO> GetByDescription(string description)
        {
            var log = (
                           from l in _context.Logs
                           join e in _context.Errors
                           on l.ErrorId equals e.ErrorId
                           join f in _context.Levels
                           on e.LevelId equals f.LevelId
                           where l.Description.Contains(description)
                           select new LogsResponseDTO
                           {
                               Archived = l.Archived,
                               Description = l.Description,
                               Events = l.Events,
                               LevelName = f.LevelName,
                               CreatedAt = l.CreatedAt,
                               Title = e.Title,
                               UserName = l.UserName
                           }).ToList();

            return log;
        }

        public List<LogsResponseDTO> GetByTitle(string title)
        {
              var log = (
                        from l in _context.Logs
                        join e in _context.Errors
                        on l.ErrorId equals e.ErrorId
                        join f in _context.Levels
                        on e.LevelId equals f.LevelId
                        where l.Title.Contains(title)
                        select new LogsResponseDTO
                        {
                            Archived = l.Archived,
                            Description = l.Description,
                            Events = l.Events,
                            LevelName = f.LevelName,
                            CreatedAt = l.CreatedAt,
                            Title = e.Title,
                            UserName = l.UserName
                        }).ToList();

            return log;
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


        public List<LogsResponseDTO> GetByEnvironment(int env)
        {
         
            var log = (
                        from l in _context.Logs
                        join e in _context.Errors
                        on l.ErrorId equals e.ErrorId
                        join f in _context.Levels
                        on e.LevelId equals f.LevelId
                        where e.EnvironmentId == env
                        select new LogsResponseDTO
                        {
                            Archived = l.Archived,
                            Description = l.Description,
                            Events = l.Events,
                            LevelName = f.LevelName,
                            CreatedAt = l.CreatedAt,
                            Title = e.Title,
                            UserName = l.UserName
                        }).ToList();

            return log;
        }

        public LogsResponseDTO GetById(int Id)
        {
            Logs response= _context.Logs.Where(x => x.ErrorOccurrenceId == Id).FirstOrDefault();

            if (response == null)
            {
                return null;
            }

            var log = (
                        from l in _context.Logs
                        join e in _context.Errors
                        on l.ErrorId equals e.ErrorId
                        join f in _context.Levels
                        on e.LevelId equals f.LevelId
                        where l.ErrorOccurrenceId==Id
                        select new LogsResponseDTO
                        {
                            Archived = l.Archived,
                            Description=l.Description,
                            Events=l.Events,
                            LevelName=f.LevelName,
                            CreatedAt=l.CreatedAt,
                            Title=e.Title, 
                            UserName=l.UserName
                        }).FirstOrDefault();

            return log;

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
