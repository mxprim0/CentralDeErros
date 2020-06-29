using CentralDeErros.Api.Interfaces;
using CentralDeErros.Api.Models;
using System.Linq;

namespace CentralDeErros.Api.Services
{
    public class UserService : IUser
    {
        private ErrorDbContext _context;

        public UserService(ErrorDbContext context)
        {
            this._context = context;
        }

        public bool RegisterUser(string email, string password, string name)
        {
            _context.Users.Add(new Users { Email = email, Password = password, Name = name });

            if (_context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Name == name) != null)
            {
                return true;
            }
            return false;
        }

        public bool Login(string email, string password)
        {            
             _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            if (_context.Users.FirstOrDefault(x => x.Email == email && x.Password == password)!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UserExists(int id)
        {
            return _context.Users.Any(u => u.UserId == id);
        }
    }
}