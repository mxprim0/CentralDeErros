using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Infra.Data.Interfaces
{
    public interface IUserRepository
    {

        IEnumerable<Users> Get();
        Users GetById(int Id);
        Users Save(Users item);
        Users Update(Users item);
        bool Delete(int Id);
        Users GetByEmailPassword(Users usuario);
        Users GetByEmail(string email);
    }
}
