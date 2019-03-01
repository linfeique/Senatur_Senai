using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                Usuarios usuarioProcurado = ctx.Usuarios.Find(email, senha);

                if (usuarioProcurado == null)
                {
                    return null;
                }

                return usuarioProcurado;
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
