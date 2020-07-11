using CentralDeErros.Api.Entidades;

namespace CentralDeErros.Api.Interfaces
{
    public interface IUser
    {
        bool RegisterUser(string email, string password, string name);
        bool Login(string email, string password);
        bool UserExists(int id);
    }
}