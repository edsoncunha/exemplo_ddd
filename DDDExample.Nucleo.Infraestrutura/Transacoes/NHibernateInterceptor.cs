using NHibernate;
using System.Collections;
using DDDExample.Nucleo.Dominio.Entidades;
using System.Collections.Generic;
using NHibernate.Type;
using DDDExample.Nucleo.Infraestrutura.Recursos;

namespace DDDExample.Nucleo.Infraestrutura.Transacoes
{
    public class NHibernateInterceptor :  EmptyInterceptor
    {
        public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            base.OnDelete(entity, id, state, propertyNames, types);
        }

        public override void PostFlush(ICollection entities)
        {
            base.PostFlush(entities);
        }
    }
}