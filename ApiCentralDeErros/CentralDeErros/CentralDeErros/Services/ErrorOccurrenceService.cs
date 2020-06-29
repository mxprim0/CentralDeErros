using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.Services
{
    public class ErrorOccurrenceService : IErrorOccurrence
    {

        private readonly ErrorDbContext _context;
        private readonly ISituation _situationService;
        private readonly ILevel _levelService;
        private readonly IError _errorService;

        public ErrorOccurrenceService (ErrorDbContext context, ISituation situationService, ILevel levelService, IError errorService)
        {
            _context = context;
            _situationService = situationService;
            _levelService = levelService;
            _errorService = errorService;
        }

        public ErrorOccurrence RegisterOrUpdateErrorOccurrence(ErrorOccurrence errorOccurrence)
        {
            if (_context.Users.Any(u => u.UserId == errorOccurrence.UserId) &&
                 _context.Errors.Any(e => e.ErrorId == errorOccurrence.ErrorId) &&
                 _context.Situations.Any(s => s.SituationId == errorOccurrence.SituationId))
            {
                var state = errorOccurrence.ErrorOccurrenceId == 0 ? EntityState.Added : EntityState.Modified;
                _context.ErrorOccurrences.Add(errorOccurrence);
                _context.SaveChanges();
            }

            return errorOccurrence;
        }

        public List<ErrorOccurrence> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            List<ErrorOccurrence> errorOccurrenceList = new List<ErrorOccurrence>();
            List<Error> errorList = new List<Error>();
            errorList = _errorService.Consult(ambiente, campoOrdenacao, campoBuscado, textoBuscado);

            foreach (var item in errorList)
            {
                var occList = _context.ErrorOccurrences.Where(x => x.ErrorId == item.ErrorId).ToList();

                foreach (var itemOcc in occList)
                {
                    errorOccurrenceList.Add(itemOcc);
                }
            }
            return errorOccurrenceList;
        }

        public class Occurrences
        {
            public int ErrorId { get; set; }
            public int Quantity { get; set; }
        }

        public List<ErrorOccurrence> ListOccurencesByLevel(int level)
        {
            return _context.ErrorOccurrences.Where(o => o.Error.LevelId == level).ToList();
        }

        public bool ErrorOccurrenceExists(int id)
        {
            return _context.ErrorOccurrences.Any(e => e.ErrorOccurrenceId == id);
        }

        public ErrorOccurrence FileErrorOccurrence(ErrorOccurrence errorOccurrence)
        {
            if (_context.Users.Any(u => u.UserId == errorOccurrence.UserId) &&
                 _context.Errors.Any(e => e.ErrorId == errorOccurrence.ErrorId) &&
                 _context.Situations.Any(s => s.SituationId == errorOccurrence.SituationId))
            {
                var state = errorOccurrence.ErrorOccurrenceId == 0 ? EntityState.Added : EntityState.Modified;
                var FileErrorOccurrence = errorOccurrence.Situation;
                
                if (_situationService.ConsultSituationByName("Arquivado") == null)
                    return null;

                errorOccurrence.Situation = _situationService.ConsultSituationByName("Arquivado");
                errorOccurrence.SituationId = _situationService.ConsultSituationByName("Arquivado").SituationId;

                _context.Entry(errorOccurrence).State = state;
                _context.SaveChanges();
            }

            return errorOccurrence;
        }

        public ErrorOccurrence DeleteErrorOccurrence(ErrorOccurrence errorOccurrence)
        {
            if (_context.Users.Any(u => u.UserId == errorOccurrence.UserId) &&
                  _context.Errors.Any(e => e.ErrorId == errorOccurrence.ErrorId) &&
                  _context.Situations.Any(s => s.SituationId == errorOccurrence.SituationId))
            {
                var state = errorOccurrence.ErrorOccurrenceId == 0 ? EntityState.Added : EntityState.Modified;
                var FileErrorOccurrence = errorOccurrence.Situation;

                if (_situationService.ConsultSituationByName("Arquivado") == null)
                    return null;

                errorOccurrence.Situation = _situationService.ConsultSituationByName("Apagado (Inativo)");
                errorOccurrence.SituationId = _situationService.ConsultSituationByName("Apagado (Inativo)").SituationId;

                _context.Entry(errorOccurrence).State = state;
                _context.SaveChanges();
            }

            return errorOccurrence;
        }

        public ErrorOccurrence ConsultErrorOccurrenceById(int errorOccurrenceId)
        {
            return _context.ErrorOccurrences.Find(errorOccurrenceId);
        }
    }
}
