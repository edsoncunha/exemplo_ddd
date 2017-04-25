using System;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Linq;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Repositorios;
using System.Linq;
using System.Linq.Expressions;


namespace DDDExample.Nucleo.Persistencia.NHibernate
{    
    public abstract class RepositorioNHibernate<T> : IRepositorio<T> 
        where T : Entidade
    {
        protected ISession Session { get; set; }
        
        //A ISession é injetada pelo container no momento em que ele cria o objeto. Em caso de dúvidas, consulte o bootstrapper da aplicação.
        public RepositorioNHibernate(ISession session)
        {
            this.Session = session;
        }

        public virtual T ObterPorId(int id)
        {
            var entidade = Session.Get<T>(id);
            //Session.Evict(entidade);
            return entidade;
        }

        public virtual IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Session.Query<T>().Where(predicate);
        }

        public virtual IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] incluirPropriedades)
        {
            var query = Session.Query<T>().Where(predicate);

            FetchProperties(incluirPropriedades, query);

            return query;
        }

        public virtual IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int limit = 10, params Expression<Func<T, object>>[] incluirPropriedades)
        {
            var query = Session.Query<T>().Where(predicate);

            FetchProperties(incluirPropriedades, query);

            return query.Take(limit);
        }

        public virtual IQueryable<T> Procurar(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int limit = 10,int offset = 0, params Expression<Func<T, object>>[] incluirPropriedades)
        {
            var query = Session.Query<T>().Where(predicate);

            FetchProperties(incluirPropriedades, query);

            return query.Skip(offset).Take(limit);
        }


        public virtual IQueryable<T> Listar()
        {
            return Session.Query<T>();                
        }

        public virtual void Salvar(T entidade)
        {
            entidade.ValidarSalvar();

            var entidadeASalvar = entidade;

            if (EstaAtualizando(entidade))
            {
                entidadeASalvar = Session.Merge<T>(entidade);
            }

            Session.SaveOrUpdate(entidadeASalvar);             
        }

        private static bool EstaAtualizando(T entidade)
        {
            return entidade.Id > 0;
        }

        public virtual void Apagar(int id)
        {
            var entidade = ObterPorId(id);
            entidade.ValidarExclusao();
            Session.Delete(entidade);
        }

        public virtual void Apagar(T entidade)
        {
            entidade.ValidarExclusao();
            Session.Delete(entidade);
        }

        public virtual T Criar()
        {
            return Activator.CreateInstance<T>();
        }

        public IQueryable<T> Listar(params Expression<Func<T, object>>[] incluirPropriedades)
        {
            var query = Session.Query<T>();

            FetchProperties(incluirPropriedades, query);

            return query;
        }

        private IQueryable<T> FetchProperties(Expression<Func<T, object>>[] incluirPropriedades, IQueryable<T> query)
        {
            if (incluirPropriedades != null)
            {
                foreach (var lambdaPropriedade in incluirPropriedades)
                {
                    query = query.Fetch(lambdaPropriedade);
                }
            }

            return query;
        }

    }
}
