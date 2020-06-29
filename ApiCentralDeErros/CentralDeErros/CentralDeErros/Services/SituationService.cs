using System.Collections.Generic;
using System.Linq;
using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Api.Services
{
    public class SituationService : ISituation
    {
        public ErrorDbContext _context;

        public SituationService(ErrorDbContext context)
        {
            _context = context;
        }

        public Situation RegisterOrUpdateSituation(Situation situation)
        {
            var state = situation.SituationId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(situation).State = state;
            _context.SaveChanges();
            return situation;
        }

        public Situation ConsultSituationById(int id)
        {
            return _context.Situations.Find(id);
        }

        public Situation ConsultSituationByName(string name)
        {
            return _context.Situations.FirstOrDefault(s => s.SituationName == name);
        }

        public List<Situation> ConsultAllSituations()
        {
            return _context.Situations.Select(s => s).ToList();
        }

        public bool SituationExists(int id)
        {
            return _context.Situations.Any(e => e.SituationId == id);
        }
    }
}
