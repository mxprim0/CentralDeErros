using System;
using System.Linq;
using CentralDeErros.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CentralDeErros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ErrorDbContext _context;
        public TokenController(ErrorDbContext context)
        {
            _context = context;

        }

        [AllowAnonymous]
        
        [HttpPost]
        public IActionResult RequestToken([FromBody]Users requestUser)
        {
            
            if (requestUser.Email == requestUser.Email && requestUser.Password == requestUser.Password)
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.UniqueName, requestUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                };
                var Key = Encoding.ASCII.GetBytes("AppSettings.Secret");
                var credenciais = new SigningCredentials(new SymmetricSecurityKey(Key), 
                    SecurityAlgorithms.HmacSha256);
                var exp = DateTime.UtcNow.AddHours(2);
                var emissor = ("AppSettings.Emissor");
                var validoEm = ("AppSettings.ValidoEm");

                var token = new JwtSecurityToken(
                issuer: emissor,
                audience: validoEm,
                claims: claims,
                signingCredentials: credenciais);

                var Token = new JwtSecurityTokenHandler().WriteToken(token);
                
                RequestTokenSave(requestUser, Token, exp);

                return Ok(new
                {
                    TokenJWT = Token,
                    Expiration = exp
                });
            }
            return BadRequest("Credenciais Inválidas");
        }

        public Users RequestTokenSave(Users requestUser, string token, DateTime exp)
        {        
            var TokenSave = _context.Users.Where
                (x => x.Email == requestUser.Email && x.Password == requestUser.Password)
                .FirstOrDefault();

            
                if (TokenSave == null)
                {
                    requestUser.Token = token;
                    requestUser.Expiration = exp;

                    _context.Users.Add(requestUser);
                    _context.SaveChanges();
                }
                else
                {
                    TokenSave.Token = token;
                    TokenSave.Expiration = exp;

                    _context.SaveChanges();
                }
                return requestUser;       
        }
    }
}