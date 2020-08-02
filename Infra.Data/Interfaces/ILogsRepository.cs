using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface ILogsRepository
    {
        IEnumerable<LogsResponseDTO> Get();
        LogsResponseDTO GetById(int Id);
        Logs Save(Logs item);
        Logs Update(Logs item);
        Logs Delete(int Id);
        public List<LogsResponseDTO> GetByLevel(int Level);
        public List<LogsResponseDTO> GetByDescription(string description);
        public List<LogsResponseDTO> GetByTitle(string title);
        public List<LogsResponseDTO> GetByEnvironment(int env);
        public Logs ArchiveLog(int logId);


    }
}
