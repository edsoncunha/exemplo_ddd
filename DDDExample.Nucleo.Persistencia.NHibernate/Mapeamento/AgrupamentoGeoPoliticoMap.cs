using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DDDExample.Nucleo.Dominio.Entidades;

namespace DDDExample.Nucleo.Persistencia.NHibernate.Mapeamento {
    
    
    public class AgrupamentoGeoPoliticoMap : ClassMap<Agrupamento> {
        
        public AgrupamentoGeoPoliticoMap() {
            Schema("dbCorporativo.dbo");
			Table("tblAgrupamentoGeoPolitico");
			LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("cmpIdAgrupamentoGeoPolitico");
			Map(x => x.Nome).Column("cmpNoPortugues").Not.Nullable();
			Map(x => x.Sigla).Column("cmpSgPortugues").Not.Nullable();
			Map(x => x.NomeOficial).Column("cmpNoOficial").Not.Nullable();
			Map(x => x.SiglaOficial).Column("cmpSgOficial").Not.Nullable();
            Map(x => x.Ativo).Column("cmpInAtivo").Not.Nullable();

            HasManyToMany<Pais>(x => x.Paises)
                .Schema("dbCorporativo.dbo")
                 .Table("tblAgrupamentoGeoPoliticoPais")
                 .ParentKeyColumn("cmpIdAgrupamentoGeoPolitico")
                 .ChildKeyColumn("cmpCoPais")
                 .Generic()
                 .LazyLoad()
                 .Cascade
                 .SaveUpdate();

            HasManyToMany<Organismo>(x => x.OrganismoInternacional)
                .Schema("dbCorporativo.dbo")
                 .Table("tblOrganismoInternacionalAgrupamento")
                 .ParentKeyColumn("cmpIdAgrupamentoGeoPolitico")
                 .ChildKeyColumn("cmpIdOrganismoInternacional")
                 .Generic()
                 .LazyLoad()
                 .Cascade
                 .SaveUpdate();
        }
    }
}
