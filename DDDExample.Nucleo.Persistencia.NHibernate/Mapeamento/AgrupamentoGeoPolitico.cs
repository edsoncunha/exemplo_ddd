using System;
using System.Text;
using System.Collections.Generic;


namespace DDDExample.Nucleo.Dominio.Entidades {
    
    public class AgrupamentoGeoPolitico : Entidade {
        public AgrupamentoGeoPolitico() {
            Paises = new List<Pais>();
            listPaises = new List<string>();
            OrganismoInternacional = new List<OrganismoInternacional>();
        }

        public virtual int Id { get; set; }
        public virtual string NomePortugues { get; set; }
        public virtual string SiglaPortugues { get; set; }
        public virtual string NomeOficial { get; set; }
        public virtual string SiglaOficial { get; set; }

        public virtual IList<Pais> Paises { get; set; }
        public virtual IList<string> listPaises { get; set; }
        public virtual IList<OrganismoInternacional> OrganismoInternacional { get; set; }
    }
}
