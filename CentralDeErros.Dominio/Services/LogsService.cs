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

        public Logs getById(int id) {
            return _logs.GetById(id);
        }

        public List<Logs> searchLogs(int type, int level, string title, string description )
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
        public List<Logs> getLogByLevel(int level) {
            return _logs.GetByLevel(level);
        }

        public List<Logs> getLogByDescription(string description)
        {
            return _logs.GetByDescription(description);
        }

        public List<Logs> getLogByTitle(string title)
        {
            return _logs.GetByDescription(title);
        }

        public List<Logs> getLogsByEnvironment(int env)
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



        public List<Logs> AllLogs()
        {
            try
            {
                return _logs.Get().ToList();
            }
            catch
            {
                return new List<Logs>();
            }
        }
        //List<Logs> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado);
        // Logs getDetails(Logs errorOccurrence);
        //Logs deleteLog(Logs errorOccurrence);
    }
}
