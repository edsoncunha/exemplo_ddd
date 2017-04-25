using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Repositorios;

namespace DDDExample.Nucleo.Dominio.Servicos.Impl
{ 
    public class PaisServico : ServicoCRUD<Pais>, IPaisServico
    {
		public PaisServico(IPaisRepositorio repositorio) : base(repositorio) { }
	}
}