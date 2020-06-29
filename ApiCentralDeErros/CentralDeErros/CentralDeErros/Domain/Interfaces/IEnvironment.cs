using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IEnvironment
    {
        Environment RegisterOrUpdateEnvironment (Environment environment);
        Environment ConsultEnvironment(int id);
        List<Environment> ConsultAllEnvironments();
        bool EnvironmentExists(int id);
    }
}