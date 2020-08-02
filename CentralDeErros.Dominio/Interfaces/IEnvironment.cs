using CentralDeErros.Infra.Entidades;
using System.Collections.Generic;

namespace CentralDeErros.Dominio.Interfaces
{
    public interface IEnvironment
    {
        Environment RegisterOrUpdateEnvironment (Environment environment);
        Environment ConsultEnvironment(int id);
        List<Environment> ConsultAllEnvironments();
    }
}