using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacoteRepository
    {
        List<Pacotes> Listar();

        Pacotes BuscarPorId(int id);

        void Cadastrar(Pacotes pacote);

        void Alterar(Pacotes pacote);
    }
}
