using CentralDeErros.Infra.Entidades;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ILogsService
    {
        Logs addLog(Logs log);
        Logs getById(int id);
        List<Logs> getLogByLevel(int level);
        public List<Logs> searchLogs(int type, int level, string title, string description);
      
        public List<Logs> getLogsByEnvironment(int env);

        List<Logs> AllLogs();

        public Logs ArchiveLog(int logId);
        public Logs DeleteLog(int logId);


    }
}