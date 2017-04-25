using DDDExample.Nucleo.Dominio.Entidades;
using DDDExample.Nucleo.Infraestrutura.Transacoes;
using API.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.WebApi;


using System.Web.Mvc;
using System.Diagnostics;
using System.Web.Http;


namespace API.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            RegisterContainer();
        }

        private static void RegisterContainer()
        {
            //Inicializar o container
            var builder = DDDExample.Nucleo.Web.Init.ContainerAPIHelper.ObterContainerBuilder();


            //Registra os controllers no container pelo seu próprio tipo concreto
            // Registrando no container os controllers
            var controllers = typeof(HomeController).Assembly;
            builder.RegisterAssemblyTypes(controllers)
                .Where(t => t.Namespace == "API.Controllers")
                .AsSelf();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            container.Resolve<ISessionFactory>();

        }
    }
}