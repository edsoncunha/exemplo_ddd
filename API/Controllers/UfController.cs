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
    public class UfController : ApiController
    {
        private IUfServico _service;

        public UfController(IUfServico service)
        {
            this._service = service;
        }

       [HttpGet, HttpPost]
        public Array Get()
        {
            var lista = this._service.Listar()
            .Select(x => new {
                CodigoUf = x.CodigoUf,
                Pais = x.Pais.Nome,
                Descricao = x.DescricaoUf
            }).ToArray();

           return lista;
        }

        [HttpGet, HttpPost]
       public Array Get(string id)
        {
            var lista = this._service.Pesquisar(x => x.CodigoUf == id)
            .Select(x => new
            {
                CodigoUf = x.CodigoUf,
                Pais = x.Pais.Nome,
                Descricao = x.DescricaoUf
            }).ToArray();

            return lista;
        }
    }
}