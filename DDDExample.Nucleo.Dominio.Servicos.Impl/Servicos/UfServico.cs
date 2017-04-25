using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Repositorios;

namespace DDDExample.Nucleo.Dominio.Servicos.Impl
{ 
    public class UfServico : ServicoCRUD<Uf>, IUfServico
    {
		public UfServico(IUfRepositorio repositorio) : base(repositorio) { }
	}
}