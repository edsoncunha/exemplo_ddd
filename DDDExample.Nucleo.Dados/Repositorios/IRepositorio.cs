using System;
using System.Collections.Generic;
using System.Linq;
using DDDExample.Nucleo.Dominio.Entidades;
using System.Linq.Expressions;

namespace DDDExample.Nucleo.Dominio.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {        
        IQueryable<T> Listar();

        IQueryable<T> Listar(params Expression<Func<T, object>>[] incluirPropriedades);

        T ObterPorId(int id);

        //[C]RUD
        T Criar();

        //C[R]UD
        IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int limit, int offset, params Expression<Func<T, object>>[] incluirPropriedades);

        //C[R]UD
        IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int limit, params Expression<Func<T, object>>[] incluirPropriedades);

        //C[R]UD
        IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] incluirPropriedades);
        
        //C[R]UD
        IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        //CR[U]D
        void Salvar(T entidade);

        //CRU[D]
        void Apagar(T entidade);
    }
}
