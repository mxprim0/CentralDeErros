using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface ILogsRepository
    {
        IEnumerable<Logs> Get();
        Logs GetById(int Id);
        Logs Save(Logs item);
        Logs Update(Logs item);
        Logs Delete(int Id);
        public List<Logs> GetByLevel(int Level);
        public List<Logs> GetByDescription(string description);
        public List<Logs> GetByTitle(string title);
        public List<Logs> GetByEnvironment(int env);
        public Logs ArchiveLog(int logId);


    }
}
