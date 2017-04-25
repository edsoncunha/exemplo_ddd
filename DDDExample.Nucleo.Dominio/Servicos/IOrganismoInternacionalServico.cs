using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDExample.Nucleo.Dominio.Entidades;
using System.Linq.Expressions;

namespace DDDExample.Nucleo.Dominio.Servicos
{ 
    public interface IOrganismoInternacionalServico : IServicoCRUD<Organismo>
    {
        IDictionary<string, List<Organismo>> ObterAncestralidade(int idOrganismoInternacional);
	}
}