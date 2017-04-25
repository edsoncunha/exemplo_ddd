using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Repositorios;
using DDDExample.Nucleo.Infraestrutura.Excecoes;

namespace DDDExample.Nucleo.Dominio.Servicos.Impl
{
    public class AgrupamentoGeoPoliticoServico : ServicoCRUD<Agrupamento>, IAgrupamentoGeoPoliticoServico
    {
        private IPaisServico _servicoPais;

        public AgrupamentoGeoPoliticoServico(IAgrupamentoGeoPoliticoRepositorio repositorio, IPaisServico servicoPais)
            : base(repositorio)
        {
            this._servicoPais = servicoPais;
        }

        public void salvarAgrupamentoGeoPolitico(Agrupamento entidade)
        {
            if (entidade.Paises != null)
            {
                entidade.Paises.Clear();

                foreach (string item in entidade.listPaises)
                {
                    var result = this._servicoPais.Pesquisar(x => x.CodigoPais == item).Single<Pais>();

                    entidade.Paises.Add(result);
                }
            }

            if (entidade.Id == 0)
                this._validarAgrupamentoGeoPolitico(entidade);

           base.Salvar(entidade);
        }

        private void _validarNomePortugues(Agrupamento entidade)
        {
            var result = this.Pesquisar(
                x => x.Nome == entidade.Nome);

            if (result.Count() != 0)
            {
                throw new ValidacaoException("Já existe registro com este Nome na base de dados");
            }
        }

        private void _validarNomeOficial(Agrupamento entidade)
        {
            var result = this.Pesquisar(
                x => x.NomeOficial == entidade.NomeOficial);

            if (result.Count() != 0)
            {
                throw new ValidacaoException("Já existe registro com este Nome Oficial na base de dados");
            }
        }

        private void _validarSiglaPortugues(Agrupamento entidade)
        {
            var result = this.Pesquisar(
                x => x.Sigla == entidade.Sigla);

            if (result.Count() != 0)
            {
                throw new ValidacaoException("Já existe registro com esta Sigla na base de dados");
            }
        }

        private void _validarSiglaOficial(Agrupamento entidade)
        {
            var result = this.Pesquisar(
                x => x.SiglaOficial == entidade.SiglaOficial);

            if (result.Count() != 0)
            {
                throw new ValidacaoException("Já existe registro com esta Sigla Oficial na base de dados");
            }
        }

        private void _validarNomeOrganismo(Agrupamento entidade)
        {
            if (entidade.Nome == entidade.NomeOficial)
            {
                throw new ValidacaoException("Nome do Organismo em Português tem de ser diferente do Nome Oficial");
            }
        }

        private void _validarAgrupamentoGeoPolitico(Agrupamento entidade)
        {
            this._validarNomePortugues(entidade);
            this._validarSiglaPortugues(entidade);
            this._validarNomeOficial(entidade);
            this._validarSiglaOficial(entidade);

            if (string.IsNullOrEmpty(entidade.Nome))
            {
                throw new ValidacaoException("O campo Nome do Organismo em Português é obrigatório");
            }

            if (string.IsNullOrEmpty(entidade.Sigla))
            {
                throw new ValidacaoException("O campo Sigla do Organismo em Português é obrigatório");
            }

            if (string.IsNullOrEmpty(entidade.NomeOficial))
            {
                throw new ValidacaoException("O campo Nome Oficial do Organismo é obrigatório");
            }

            if (string.IsNullOrEmpty(entidade.SiglaOficial))
            {
                throw new ValidacaoException("O campo Sigla Oficial Organismo é obrigatório");
            }

            //this._validarNomeOrganismo(entidade);

            if (entidade.Paises.Count() == 0)
            {
                throw new ValidacaoException("Selecione pelo menos um País");
            }
        }
    }
}