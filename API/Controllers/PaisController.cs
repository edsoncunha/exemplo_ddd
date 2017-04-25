using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Servicos;
using DDDExample.Nucleo.Infraestrutura.Excecoes;

namespace API.Controllers
{
    public class PaisController : ApiController
    {
        private IPaisServico _service;

        public PaisController(IPaisServico service)
        {
            this._service = service;
        }

       [HttpGet, HttpPost]
        public Array Get()
        {
            var lista = this._service.Listar().Select(x => new {
                CodigoPais = x.CodigoPais,
                Nome = x.Nome, 
                NomeOficial = x.NomeOficial,
                NomePreposicao = x.NomePreposicao,
                CodigoArea = x.CodigoArea
            }).ToArray();

            return lista;
        }

        [HttpGet, HttpPost]
       public Array Get(string id)
        {
            var lista = this._service.Pesquisar(x => x.CodigoPais == id)
           .Select(x => new
           {
               CodigoPais = x.CodigoPais,
               Nome = x.Nome,
               NomeOficial = x.NomeOficial,
               NomePreposicao = x.NomePreposicao,
               CodigoArea = x.CodigoArea
           }).ToArray();

            return lista;
        }
    }
}