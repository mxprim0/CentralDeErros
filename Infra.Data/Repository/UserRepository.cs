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
    public class UserRepository:IUserRepository
    {
        private readonly CentralContext _context;
        public UserRepository(CentralContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> Get()
        {
            return _context.User;
        }

        public Users GetById(int Id)
        {
            return _context.User.Where(x => x.UserId == Id).FirstOrDefault();
        }
        public Users Save(Users user)
        {
            var state = user.UserId == 0 ? EntityState.Added : EntityState.Modified;
            _context.Entry(user).State = state;
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }
        public Users Update(Users user)
        {
            var _user = _context.User.Where(x => x.UserId == user.UserId).FirstOrDefault();

            if (_user != null)
            {
                _user = user;

                _context.Entry(_user).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return user;
        }
        public bool Delete(int Id)
        {
            var _user = _context.User.Where(x => x.UserId == Id).FirstOrDefault();

            if (_user != null)
            {
                _context.Entry(_user).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
