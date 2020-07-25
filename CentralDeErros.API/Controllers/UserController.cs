using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using CentralDeErros.Dominio.Services;
using CentralDeErros.Infra.Data.Entidades;
using CentralDeErros.Infra.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CentralDeErros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        public object Post([FromBody] Usuario usuario,
                            [FromServices] UsuarioService usrService,
                            [FromServices] SigningConfigurations signingConfigurations)
        {
            bool credenciaisValidas = false;
            var usuarioBase = new Usuario();

            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Email))
            {
                Users user = new Users
                {
                    Email = usuario.Email,
                    Password = usuario.Password
                };

                usuarioBase = usrService.GetByEmailPassword(user);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.Email == usuarioBase.Email &&
                    usuario.Password == usuarioBase.Password);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email, usuario.Email),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email),
                        new Claim(ClaimTypes.Role, usuarioBase.Role),
                        new Claim(ClaimTypes.Email, usuario.Email)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(3600);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = "ExemploIssuer",
                    Audience = "ExemploAudience",
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
    }
