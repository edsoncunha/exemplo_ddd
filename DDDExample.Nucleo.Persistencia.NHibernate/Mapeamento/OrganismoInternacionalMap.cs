using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using DDDExample.Nucleo.Dominio.Entidades;

namespace DDDExample.Nucleo.Persistencia.NHibernate.Mapeamento {
    
    
    public class OrganismoInternacionalMap : ClassMap<Organismo> {
        
        public OrganismoInternacionalMap() {
            Schema("dbCorporativo.dbo");
			Table("tblOrganismoInternacional");
			LazyLoad();
	
            Id(x => x.Id).GeneratedBy.Identity().Column("cmpIdOrganismoInternacional");
            
            References(x => x.Pai).Column("cmpIdOrganismoInternacionalSuperior");
			References(x => x.UnidadeAdministrativa).Column("cmpIdUnidadeAdministrativaResponsavel");
			References(x => x.Pais).Column("cmpCoPais");
			
            Map(x => x.Nome).Column("cmpNoPortugues").Not.Nullable();
			Map(x => x.Sigla).Column("cmpSgPortugues").Not.Nullable();
			Map(x => x.NomeOficial).Column("cmpNoOficial").Not.Nullable();
			Map(x => x.SiglaOficial).Column("cmpSgOficial").Not.Nullable();
			Map(x => x.NomeCidadeSede).Column("cmpNoCidadeSede").Not.Nullable();
            Map(x => x.AnoFundacao).Column("cmpNuAnoFundacao");
            Map(x => x.AnoAfiliacao).Column("cmpNuAnoFiliacaoBrasil");
            Map(x => x.LinguasOficiais).Column("cmpDcLinguasOficiais");
            Map(x => x.Site).Column("cmpLkSite");
            Map(x => x.NomeArquivoLogo).Column("cmpNoArquivoLogotipo");
            Map(x => x.ArquivoLogo).Column("cmpImArquivoLogotipo");
            Map(x => x.InformacoesGerais).Column("cmpDcInformacoesGerais");
            Map(x => x.Ativo).Column("cmpInAtivo");
            
            HasManyToMany<Agrupamento>(x => x.Agrupamento)
                .Schema("dbCorporativo.dbo")
                .Table("tblOrganismoInternacionalAgrupamento")
                .ParentKeyColumn("cmpIdOrganismoInternacional")
                .ChildKeyColumn("cmpIdAgrupamentoGeoPolitico")
                .Generic()
                .LazyLoad()
                .Cascade
                .AllDeleteOrphan();

            HasManyToMany<UnidadeOrganizacional>(x => x.UnidadesAdministrativas)
                .Schema("dbCorporativo.dbo")
                .Table("tblCoResponsavelOrganismoInternacional")
                .ParentKeyColumn("cmpIdOrganismoInternacional")
                .ChildKeyColumn("cmpIdUnidadeAdministrativa")
                .Generic()
                .LazyLoad()
                .Cascade
                .AllDeleteOrphan();
        }
    }
}
