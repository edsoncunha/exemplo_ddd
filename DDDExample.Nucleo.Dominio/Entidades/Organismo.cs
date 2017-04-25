using System;
using System.Text;
using System.Collections.Generic;
using DDDExample.Nucleo.Infraestrutura.Excecoes;
using System.Web.Script.Serialization;


namespace DDDExample.Nucleo.Dominio.Entidades {

    public class Organismo : Entidade
    {
        public Organismo() {
            Agrupamento = new List<Agrupamento>();
            UnidadesAdministrativas = new List<UnidadeOrganizacional>();
        }
        
        public virtual Organismo Pai { get; set; }

        [ScriptIgnore]
        public virtual UnidadeOrganizacional UnidadeAdministrativa { get; set; }
        public virtual Pais Pais { get; set; }
        
        public virtual string Nome { get; set; }
        public virtual string Sigla { get; set; }
        public virtual string NomeOficial { get; set; }
        public virtual string SiglaOficial { get; set; }
        public virtual string NomeCidadeSede { get; set; }
        public virtual string AnoFundacao { get; set; }
        public virtual string AnoAfiliacao { get; set; }
        public virtual string LinguasOficiais { get; set; }
        public virtual string Site { get; set; }
        public virtual string NomeArquivoLogo { get; set; }
        public virtual byte[] ArquivoLogo { get; set; }
        public virtual string InformacoesGerais { get; set; }
        public virtual Nullable<bool> Ativo { get; set; }

        [ScriptIgnore]
        public virtual IList<Agrupamento> Agrupamento { get; set; }

        [ScriptIgnore]
        public virtual IList<UnidadeOrganizacional> UnidadesAdministrativas { get; set; }

        private void ValidarNomeOrganismo(Organismo entidade)
        {
            if (entidade.Nome == entidade.NomeOficial)
            {
                throw new Exception("Nome do Organismo em Português tem de ser diferente do Nome Oficial");
            }
        }

        //TODO: remover a validação manual e adaptar a validação por Data Attributes.
        public virtual void ValidarCamposObrigatorios()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ValidacaoException("O campo Nome do Organismo em Português é obrigatório");
            }

            if (string.IsNullOrEmpty(Sigla))
            {
                throw new ValidacaoException("O campo Sigla do Organismo em Português é obrigatório");
            }

            if (string.IsNullOrEmpty(NomeOficial))
            {
                throw new ValidacaoException("O campo Nome Oficial do Organismo é obrigatório");
            }

            if (string.IsNullOrEmpty(SiglaOficial))
            {
                throw new ValidacaoException("O campo Sigla Oficial Organismo é obrigatório");
            }

            if (Pais == null)
            {
                throw new ValidacaoException("O campo País é obrigatório");
            }

            if (string.IsNullOrEmpty(NomeCidadeSede))
            {
                throw new ValidacaoException("O campo Cidade é obrigatório");
            }

            if (UnidadeAdministrativa == null)
            {
                throw new ValidacaoException("O campo Unidade Responsável é obrigatório");
            }
        }

        
    }
}
