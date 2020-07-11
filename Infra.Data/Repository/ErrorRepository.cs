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
    public class ErrorRepository:IErrorRepository
    {
        private readonly CentralContext _context;
        public ErrorRepository(CentralContext context)
        {
            _context = context;
        }

        public IEnumerable<Error> Get()
        {
            return _context.Errors;
        }

        public Error GetById(int Id)
        {
            return _context.Errors.Where(x => x.ErrorId == Id).FirstOrDefault();
        }
        public Error Save(Error item)
        {
            var state = item.ErrorId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(item).State = state;
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public Error Update(Error item)
        {
            var _item = _context.Errors.Where(x => x.ErrorId == item.ErrorId).FirstOrDefault();

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
            var _erros = _context.Errors.Where(x => x.ErrorId == Id).FirstOrDefault();

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
