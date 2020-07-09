using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErros.Api.Services
{
    public class ErrorService : IError
    {
        private ErrorDbContext _context;
        private ILevel _levelService;

        public ErrorService(ErrorDbContext context, ILevel levelService)
        {
            _context = context;
            _levelService = levelService;
        }

        public Error RegisterOrUpdateError(Error error)
        {
            if (_context.Environments.Any(e => e.EnvironmentId == error.EnvironmentId) &&
                _context.Levels.Any(l => l.LevelId == error.LevelId))
            {
                var state = error.ErrorId == 0 ? EntityState.Added : EntityState.Modified;
                _context.Entry(error).State = state;
                _context.SaveChanges();
            }           
            return error;
        }

        public Error ConsultError(int id)
        {
            return _context.Errors.Find(id);
        }

        public List<Error> Consult(int ambiente, int campoOrdenacao, int campoBuscado, string textoBuscado)
        {
            List<Error> errorsSearchList = new List<Error>();
            List<Error> errorsList = new List<Error>();

            if (textoBuscado != "" && campoBuscado != 0)
            {
                if (campoBuscado == 1)
                    errorsSearchList = _context.Errors.Where(x => x.LevelId == _levelService.ConsultLevelByName(textoBuscado).LevelId).ToList();
                else if (campoBuscado == 2)
                    errorsSearchList = _context.Errors.Where(x => x.Description.Contains(textoBuscado)).ToList();
                else if (campoBuscado == 3)
                    errorsSearchList = _context.ErrorOccurrences.Where(x => x.Origin == textoBuscado).Select(x => x.Error).ToList();

                errorsSearchList = errorsSearchList.Where(x => x.EnvironmentId == ambiente || ambiente <= 0).ToList();
            }
            else
                errorsSearchList = _context.Errors.Where(x => x.EnvironmentId == ambiente || ambiente <= 0).ToList();

            if (campoOrdenacao == 1)
                errorsSearchList = errorsSearchList.OrderBy(x => x.LevelId).ToList();
            else if (campoOrdenacao == 2)
            {
                List<Occurrences> listOcc = new List<Occurrences>();

                foreach (var item in errorsSearchList)
                {
                    var occ = new Occurrences();

                    occ.ErrorId = item.ErrorId;
                    occ.Quantity = _context.ErrorOccurrences.Where(x => x.ErrorId == item.ErrorId).Count();
                    listOcc.Add(occ);
                }

                listOcc = listOcc.OrderByDescending(x => x.Quantity).ToList();

                foreach (var item in listOcc)
                {
                    errorsList.Add(_context.Errors.Where(x => x.ErrorId == item.ErrorId).FirstOrDefault());
                }

                errorsSearchList = errorsList;
            }

            return errorsSearchList;
        }

        public class Occurrences
        {
            public int ErrorId { get; set; }
            public int Quantity { get; set; }
        }

        public List<Error> ConsultAllErrors()
        {
            return _context.Errors.Select(e => e).ToList();
        }

        public bool ErrorExists(int id)
        {
            return _context.Errors.Any(e => e.ErrorId == id);
        }
    }
}
