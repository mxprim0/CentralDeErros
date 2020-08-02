using CentralDeErros.Infra.Entidades;
using System;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ILogsService
    {
        Logs addLog(Logs log);
        LogsResponseDTO getById(int id);
        List<LogsResponseDTO> getLogByLevel(int level);
        public List<LogsResponseDTO> searchLogs(int type, int level, string title, string description);
      
        public List<LogsResponseDTO> getLogsByEnvironment(int env);

        List<LogsResponseDTO> AllLogs();

        public Logs ArchiveLog(int logId);
        public Logs DeleteLog(int logId);


    }
}