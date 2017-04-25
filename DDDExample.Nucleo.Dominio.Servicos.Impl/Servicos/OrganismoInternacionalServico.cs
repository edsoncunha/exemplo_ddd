using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Repositorios;
using DDDExample.Nucleo.Infraestrutura.Excecoes;

namespace DDDExample.Nucleo.Dominio.Servicos.Impl
{ 
    public class OrganismoInternacionalServico : ServicoCRUD<Organismo>, IOrganismoInternacionalServico
    {
		public OrganismoInternacionalServico(IOrganismoInternacionalRepositorio repositorio) : base(repositorio) { }

        public override void Salvar(Organismo entidade)
        {
            ValidarCamposUnicos(entidade);            

            entidade.ValidarCamposObrigatorios();

            base.Salvar(entidade);
        }

        private void ValidarCamposUnicos(Organismo entidade)
        {
            ValidarNomePortugues(entidade);
            ValidarNomeOficial(entidade);                     
        }

        public IDictionary<string, List<Organismo>> ObterAncestralidade(int idOrganismoInternacional)
        {
            var resultado = new Dictionary<string, List<Organismo>>();
            var organismo = ObterPorId(idOrganismoInternacional);

            do
            {
                var prole = Pesquisar(x => x.Pai == organismo.Pai);
                resultado.Add(organismo.Id.ToString(), prole.ToList());
                organismo = organismo.Pai;
            } while (organismo != null);

            return resultado;
        }

        private void ValidarNomePortugues(Organismo entidade)
        {
            var result = this.Pesquisar(
                x => x.Nome == entidade.Nome);

            if (result.Count() != 0)
            {
                throw new ValidacaoException("Já existe registro com este Nome na base de dados");
            }
        }

        private void ValidarNomeOficial(Organismo entidade)
        {
            var result = this.Pesquisar(
                x => x.NomeOficial == entidade.NomeOficial);

            if (result.Count() != 0)
            {
                throw new ValidacaoException("Já existe registro com este Nome Oficial na base de dados");
            }
        }
	}
}