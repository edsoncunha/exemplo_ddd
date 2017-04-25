using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDExample.Nucleo.Dominio.Entidades; 
using DDDExample.Nucleo.Dominio.Repositorios;
using NHibernate;
using NHibernate.Linq;

namespace DDDExample.Nucleo.Persistencia.NHibernate.Repositorios
{ 
    public class AgrupamentoGeoPoliticoRepositorio : RepositorioNHibernate<Agrupamento>, IAgrupamentoGeoPoliticoRepositorio
    {
		public AgrupamentoGeoPoliticoRepositorio(ISession session) : base(session) { }

		// Coloque aqui os métodos do serviço que se fizerem necessários. Os métodos comuns de CRUD já estão contemplados :)
	}
}