using System;
using System.Transactions;
using Castle.DynamicProxy;
using DDDExample.Nucleo.Infraestrutura.Excecoes;
using System.Collections;
using NHibernate;

namespace DDDExample.Nucleo.Infraestrutura.Transacoes
{
    public class ServiceTransactionInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISession db;
        private ITransaction transaction = null;

        public ServiceTransactionInterceptor(ISession db)
        {
            this.db = db;
        }

        public void Intercept(IInvocation invocation)
        {
            bool iAmTheFirst = false;

            if (transaction == null)
            {
                transaction = db.BeginTransaction();
                iAmTheFirst = true;
            }

            try
            {
                invocation.Proceed();

                if (iAmTheFirst)
                {
                    iAmTheFirst = false;

                    transaction.Commit();
                    transaction = null;
                }
            }
            catch (Exception ex)
            {
                if (iAmTheFirst)
                {
                    iAmTheFirst = false;

                    transaction.Rollback();
                    db.Clear();
                    transaction = null;
                }

                throw new ServicoException(ex);
            }
        }
        
    }
}
