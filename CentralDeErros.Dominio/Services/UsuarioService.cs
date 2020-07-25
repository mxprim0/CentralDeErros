using System;
using System.Collections.Generic;
using System.Text;
using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Data.Interfaces;
using CentralDeErros.Infra.Entidades;

namespace CentralDeErros.Dominio.Services
{
    public class UsuarioService
    {
        private readonly IUserRepository _usuarioRepository;

        public UsuarioService(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario GetByEmailPassword(Users usuario)
        {
            var result = _usuarioRepository.GetByEmailPassword(usuario);
            if (result != null)
            {
                Usuario user = new Usuario
                {
                    Email = result.Email,
                    Password = result.Password,
                    Role = result.Role
                };
                return user;
            }

            return new Usuario();
        }
    }
}
