using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        public void Alterar(Pacotes pacote)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                ctx.Pacotes.Update(pacote);
                ctx.SaveChanges();
            }
        }

        public Pacotes BuscarPorId(int id)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                Pacotes pacoteProcurado = ctx.Pacotes.Find(id);

                if (pacoteProcurado == null)
                {
                    return null;
                }

                return pacoteProcurado;
            }
        }

        public void Cadastrar(Pacotes pacote)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                ctx.Add(pacote);
                ctx.SaveChanges();
            }
        }

        public List<Pacotes> Listar()
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                return ctx.Pacotes.ToList();
            }
        }
    }
}
