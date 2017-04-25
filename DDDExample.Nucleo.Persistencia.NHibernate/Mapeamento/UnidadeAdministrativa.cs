using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.Nucleo.Dominio.Entidades
{
    public class UnidadeAdministrativa : Entidade
    {
        public UnidadeAdministrativa()
        {
            OrganismosInternacionais = new List<OrganismoInternacional>();
        }

        public virtual int IdEndereco { get; set; }

        public virtual string Codigo { get; set; }

        public virtual int IdTipo { get; set; }

        public virtual int IdUnidadeSuperior { get; set; }

        public virtual string Nome { get; set; }

        public virtual bool Ativo { get; set; }

        public virtual string CodigoUnidadeSuperior { get; set; }

        public virtual string Nup { get; set; }

        public virtual IList<OrganismoInternacional> OrganismosInternacionais { get; set; }
    }
}
