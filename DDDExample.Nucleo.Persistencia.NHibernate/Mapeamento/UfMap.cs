using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DDDExample.Nucleo.Dominio.Entidades;

namespace DDDExample.Nucleo.Persistencia.NHibernate.Mapeamento {
    
    public class UfMap : ClassMap<Uf> {
        
        public UfMap() {
            Schema("dbCorporativo.dbo");
			Table("tblUF");
			LazyLoad();
			Id(x => x.CodigoUf).GeneratedBy.Assigned().Column("cmpCoUf");
			References(x => x.Pais).Column("cmpCoPais");
			Map(x => x.DescricaoUf).Column("cmpDcUf").Not.Nullable();
        }
    }
}
