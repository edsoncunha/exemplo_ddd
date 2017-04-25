using System;
using System.Text;
using System.Collections.Generic;


namespace DDDExample.Nucleo.Dominio.Entidades {

    public class OrganismoInternacional : Entidade
    {
        public OrganismoInternacional() {
            AgrupamentoGeoPolitico = new List<AgrupamentoGeoPolitico>();
            UnidadesAdministrativas = new List<UnidadeAdministrativa>();
        }

        public virtual int Id { get; set; }
        public virtual OrganismoInternacional OrgInternacional { get; set; }
        public virtual UnidadeAdministrativa UnidadeAdministrativa { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual string NomePortugues { get; set; }
        public virtual string SiglaPortugues { get; set; }
        public virtual string NomeOficial { get; set; }
        public virtual string SiglaOficial { get; set; }
        public virtual string NomeCidadeSede { get; set; }

        public virtual IList<AgrupamentoGeoPolitico> AgrupamentoGeoPolitico { get; set; }
        public virtual IList<UnidadeAdministrativa> UnidadesAdministrativas { get; set; }
    }
}
