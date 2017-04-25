using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDDExample.SVA.Dominio.Entidades;

namespace DDDExample.SVA.Dominio.Repositorios
{
    public interface IAutorizacaoRepositorio : IRepositorio<Autorizacao>
    {
        IEnumerable<Autorizacao> ListarAutorizacoesDespesa();
    }
}
