using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DDDExample.Nucleo.Dominio.Entidades;

namespace DDDExample.Nucleo.Persistencia.NHibernate.Mapeamento
{
    public class UnidadeAdministrativaMap : ClassMap<UnidadeOrganizacional>
    {
        public UnidadeAdministrativaMap()
        {
            Schema("dbCorporativo.dbo");
            Table("tblUnidadeAdministrativa");

            Id(x => x.Id, "cmpIdUnidadeAdministrativa");

            Map(x => x.IdEndereco, "cmpIdEndereco");
            Map(x => x.Codigo, "cmpCoUnidadeAdministrativa");
            Map(x => x.IdTipo, "cmpIdTipoUnidadeAdministrativa");
            Map(x => x.IdUnidadeSuperior, "cmpIdUnidAdmSuperior");
            Map(x => x.Nome, "cmpNoUnidadeAdministrativa");
            Map(x => x.Ativo, "cmpInAtivo");
            Map(x => x.CodigoUnidadeSuperior, "cmpCoUnidAdmSuperior");
            Map(x => x.Nup, "cmpCoNup");

            HasManyToMany<Organismo>(x => x.Organismos)
                .Schema("dbCorporativo.dbo")
                 .Table("tblCoResponsavelOrganismoInternacional")
                 .ParentKeyColumn("cmpIdUnidadeAdministrativa")
                 .ChildKeyColumn("cmpIdOrganismoInternacional")
                 .Generic()
                 .LazyLoad()
                 .Cascade
                 .AllDeleteOrphan();
        }
    }
}
