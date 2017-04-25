using System;
using System.Text;
using System.Collections.Generic;


namespace DDDExample.Nucleo.Dominio.Entidades {
    
    public class Agrupamento : Entidade {
        public Agrupamento() {

            Paises = new List<Pais>();
            listPaises = new List<string>();
            OrganismoInternacional = new List<Organismo>();
        }

        public virtual string Nome { get; set; }
        public virtual string Sigla { get; set; }
        public virtual string NomeOficial { get; set; }
        public virtual string SiglaOficial { get; set; }
        public virtual bool Ativo { get; set; }

        public virtual IList<Pais> Paises { get; set; }
        public virtual IList<string> listPaises { get; set; }
        public virtual IList<Organismo> OrganismoInternacional { get; set; }
    }
}
