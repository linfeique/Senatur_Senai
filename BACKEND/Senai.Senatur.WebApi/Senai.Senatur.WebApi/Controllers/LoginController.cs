using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using Senai.Senatur.WebApi.ViewModels;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository UsuarioRepositorio { get; set; }

        public LoginController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = UsuarioRepositorio.BuscarPorEmailSenha(login.Email, login.Senha);

                if (usuario == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Usuário não encontrado"
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario),
                    // Isso é show de pica
                    // Aqui vc pode determinar qualquer coisa
                    // new Claim("teste", "lasanha")
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("svigufo-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Svigufo.WebApi",
                    audience: "Svigufo.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch
            {
                return BadRequest(new
                {
                    mensagem = "Deu erro!!!"
                });
            }
        }
    }
}