using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositorio { get; set;}

        public UsuariosController()
        {
            UsuarioRepositorio = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(UsuarioRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepositorio.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}