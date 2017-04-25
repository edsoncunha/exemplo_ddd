using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDExample.Nucleo.Dominio.Servicos
{
    public interface IServicoCRUD<TEntidade>
     where TEntidade : DDDExample.Nucleo.Dominio.Entidades.Entidade
    {
        void Excluir(int id);
        System.Collections.Generic.IEnumerable<TEntidade> Listar();
        System.Collections.Generic.IEnumerable<TEntidade> Listar(params System.Linq.Expressions.Expression<Func<TEntidade, object>>[] incluirPropriedades);
        TEntidade ObterPorId(int id);
        System.Collections.Generic.IEnumerable<TEntidade> Pesquisar(System.Linq.Expressions.Expression<Func<TEntidade, bool>> where, int limit);
        System.Collections.Generic.IEnumerable<TEntidade> Pesquisar(System.Linq.Expressions.Expression<Func<TEntidade, bool>> where, int limit, int offset);
        System.Collections.Generic.IEnumerable<TEntidade> Pesquisar(System.Linq.Expressions.Expression<Func<TEntidade, bool>> where);
        void Salvar(TEntidade entidade);
    }
}
