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
    public class UnidadeAdministrativaRepositorio : RepositorioNHibernate<UnidadeOrganizacional>, IUnidadeAdministrativaRepositorio
    {
		public UnidadeAdministrativaRepositorio(ISession session) : base(session) { }

		// Coloque aqui os métodos do serviço que se fizerem necessários. Os métodos comuns de CRUD já estão contemplados :)
	}
}