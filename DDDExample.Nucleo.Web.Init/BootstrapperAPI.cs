using Autofac;
using Autofac.Extras.DynamicProxy2;
using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Dominio.Servicos.Impl;
using DDDExample.Nucleo.Infraestrutura.Transacoes;
using DDDExample.Nucleo.Persistencia.NHibernate;
using NHibernate;
using Autofac.Integration.Mvc;
using System.Transactions;
using Autofac.Integration.WebApi;

namespace DDDExample.Nucleo.Web.Init
{
    public class ContainerAPIHelper
    {
        public static ISessionFactory SessionFactory { get; set; }

        public static ContainerBuilder ObterContainerBuilder()
        {
            //Inicializar o container
            var builder = new ContainerBuilder();

            builder.Register(x => FluentSessionFactoryFactory.GetSessionFactory("thread_static", "psConnection")).SingleInstance();

            builder.RegisterType<NHibernateInterceptor>().SingleInstance().AsSelf();

            builder.Register(x =>
            {
                var session = x.Resolve<ISessionFactory>().OpenSession(x.Resolve<NHibernateInterceptor>());
                session.FlushMode = FlushMode.Commit;
                return session;
            })
            .InstancePerApiRequest()
            .OnRelease(x =>
            {
                x.Dispose();
            });

            // Registrando no container os repositórios implementados com NHibernate
            var dataAccess = typeof(RepositorioNHibernate<>).Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Repositorio"))
                .AsImplementedInterfaces();


            // Registrando no container os Serviços e seus interceptadores
            var servicos = typeof(ServicoCRUD<>).Assembly;
            builder.RegisterAssemblyTypes(servicos)
                   .Where(t => t.Name.EndsWith("Servico"))
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(ServiceTransactionInterceptor));

            builder.RegisterType<ServiceTransactionInterceptor>()
                .InstancePerApiRequest()
                .AsSelf();

            //Registra as entidades no container pelo seu próprio tipo concreto
            //Registrando no container as entidades
            var entidades = typeof(Entidade).Assembly;
            builder.RegisterAssemblyTypes(entidades)
                .Where(t => t.BaseType == typeof(Entidade))
                .AsSelf();

            return builder;

        }
    }
}