using CentralDeErros.Api.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface IEnvironment
    {
        EnvironmentLevel RegisterOrUpdateEnvironment (EnvironmentLevel environment);
        EnvironmentLevel ConsultEnvironment(int id);
        List<EnvironmentLevel> ConsultAllEnvironments();
        bool EnvironmentExists(int id);
    }
}