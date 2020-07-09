using CentralDeErros.Api.Models;
using System.Collections.Generic;

namespace CentralDeErros.Api.Interfaces
{
    public interface ISituation
    {
        Situation RegisterOrUpdateSituation(Situation situation);
        Situation ConsultSituationById(int id);
        Situation ConsultSituationByName(string name);
        List<Situation> ConsultAllSituations();
        bool SituationExists(int id);
    }
}