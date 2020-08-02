using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentralDeErros.Infra.Entidades;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Infra.Data.Interfaces;
using CentralDeErros.Infra.Data.Repository;

namespace CentralDeErros.Dominio.Services
{
   public class LogsService:ILogsService
    {

        private readonly ILogsRepository _logs;

        public LogsService(ILogsRepository logs)
        {
            _logs = logs;
        }

        public Logs addLog(Logs log)
        {
            return _logs.Save(log);
        }
        public Logs DeleteLog(int logId)
        {
            return _logs.Delete(logId);
        }

        public LogsResponseDTO getById(int id) {

            return _logs.GetById(id);
        }

        public List<LogsResponseDTO> searchLogs(int type, int level, string title, string description )
        {
            if (type == null)
            {
                return null;
            }

            if (type==null && level == null && title == null && description == null)
            {
                return null;
            }

            switch (type)
            {
              case  1 : return getLogByLevel(level); break;
              case 2: return getLogByDescription(description); break;
              default: return getLogByTitle(title); break;
            }


        }
        public List<LogsResponseDTO> getLogByLevel(int level) {
            return _logs.GetByLevel(level);
        }

        public List<LogsResponseDTO> getLogByDescription(string description)
        {
            return _logs.GetByDescription(description);
        }

        public List<LogsResponseDTO> getLogByTitle(string title)
        {
            return _logs.GetByDescription(title);
        }

        public List<LogsResponseDTO> getLogsByEnvironment(int env)
        {
            return _logs.GetByEnvironment(env).ToList();
        }
        public Logs ArchiveLog(int logId)
        {
            return _logs.ArchiveLog(logId);
        }
        public Logs deleteLog(int logId)
        {
            return _logs.Delete(logId);
        }



        public List<LogsResponseDTO> AllLogs()
        {
            try
            {
                return _logs.Get().ToList();
            }
            catch
            {
                return new List<LogsResponseDTO>();
            }
        }
       
    }
}
