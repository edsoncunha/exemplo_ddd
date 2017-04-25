using System;
using System.Transactions;
using Castle.DynamicProxy;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Servicos;
using DDDExample.Nucleo.Infraestrutura.Excecoes;
using DDDExample.Nucleo.Infraestrutura.Recursos;
using System.Collections;
using System.Web;
using System.Linq;
using NHibernate;
using DDDExample.Nucleo.Infraestrutura.Log;
using DDDExample.Nucleo.Dominio.Repositorios;

namespace DDDExample.Nucleo.Infraestrutura.Transacoes 
{
    public class ServiceLoggerInterceptor : Castle.DynamicProxy.IInterceptor
    {
        private readonly ISession db;
        private ITransaction transaction = null;

        public ServiceLoggerInterceptor(ISession db)
        {
            this.db = db;
        }

        public void Intercept(IInvocation invocation)
        {
            /*string message = "";

            var propriedade = invocation.TargetType.GetMethod(invocation.Method.Name).GetCustomAttributes(true).FirstOrDefault() as ExceptionLogAttribute;

            if (propriedade != null)
            {
                message = propriedade.Message;
            }*/
            
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
                System.Diagnostics.Debug.WriteLine(ex.ToString());
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
