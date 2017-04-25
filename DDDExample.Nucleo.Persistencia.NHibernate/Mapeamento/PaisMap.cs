using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DDDExample.Nucleo.Dominio.Entidades;

namespace DDDExample.Nucleo.Persistencia.NHibernate.Mapeamento {
    
    
    public class PaisMap : ClassMap<Pais> {
        
        public PaisMap() {
            Schema("dbCorporativo.dbo");
			Table("tblPais");
			LazyLoad();
			Id(x => x.CodigoPais).GeneratedBy.Assigned().Column("cmpCoPais");
			Map(x => x.CodigoArea).Column("cmpCoArea");
			Map(x => x.Nome).Column("cmpNoPais").Not.Nullable();
			Map(x => x.NomePreposicao).Column("cmpNoPreposicaoPais");
			Map(x => x.NomeOficial).Column("cmpNoOficialPais");

            HasManyToMany<Agrupamento>(x => x.Agrupamento)
                .Schema("dbCorporativo.dbo")
                .Table("tblAgrupamentoGeoPoliticoPais")
                .ParentKeyColumn("cmpCoPais")
                .ChildKeyColumn("cmpIdAgrupamentoGeoPolitico")
                .Generic()
                .LazyLoad();
        }
    }
}
