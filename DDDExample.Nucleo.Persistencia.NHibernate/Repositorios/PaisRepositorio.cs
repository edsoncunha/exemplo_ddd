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
    public class PaisRepositorio : RepositorioNHibernate<Pais>, IPaisRepositorio
    {
		public PaisRepositorio(ISession session) : base(session) { }

		
	}
}