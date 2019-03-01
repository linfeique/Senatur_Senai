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
    public class PacotesController : ControllerBase
    {
        private IPacoteRepository PacoteRepositorio { get; set;}

        public PacotesController()
        {
            PacoteRepositorio = new PacoteRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            { 
                return Ok(PacoteRepositorio.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("listarporid/{id}")]
        public IActionResult ListarPorId(int id)
        {
            try
            {
                return Ok(PacoteRepositorio.Listar().Where(x => x.PacoteId == id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Pacotes pacote)
        {
            try
            {
                PacoteRepositorio.Cadastrar(pacote);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Alterar(Pacotes pacote)
        {
            try
            {
                Pacotes pacoteProcurado = PacoteRepositorio.BuscarPorId(pacote.PacoteId);

                if (pacoteProcurado == null)
                {
                    return NotFound();
                }

                PacoteRepositorio.Alterar(pacote);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}