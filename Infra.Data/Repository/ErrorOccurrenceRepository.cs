using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CentralDeErros.Api.Entidades;
using CentralDeErros.Infra.Data.Context;
using CentralDeErros.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CentralDeErros.Infra.Data.Repository
{
    public class ErrorOcurrencceRepository:IErrorOccurrenceRepository
    {
        private readonly CentralContext _context;
        public ErrorOcurrencceRepository(CentralContext context)
        {
            _context = context;
        }

        public IEnumerable<ErrorOccurrence> Get()
        {
            return _context.ErrorOccurrences;
        }

        public ErrorOccurrence GetById(int Id)
        {
            return _context.ErrorOccurrences.Where(x => x.ErrorOccurrenceId == Id).FirstOrDefault();
        }
        public ErrorOccurrence Save(ErrorOccurrence item)
        {
            var state = item.ErrorOccurrenceId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(item).State = state;
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public ErrorOccurrence Update(ErrorOccurrence item)
        {
            var _item = _context.ErrorOccurrences.Where(x => x.ErrorOccurrenceId == item.ErrorOccurrenceId).FirstOrDefault();

            if (_item != null)
            {
                _item = item;

                _context.Entry(_item).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return item;
        }
        public bool Delete(int Id)
        {
            var _erros = _context.ErrorOccurrences.Where(x => x.ErrorOccurrenceId == Id).FirstOrDefault();

            if (_erros != null)
            {
                _context.Entry(_erros).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
