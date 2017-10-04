﻿using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Spike_TESTS
{
    public class IoCConfig
    {
        public static IContainer RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly)
                .Where(t => t.Name.EndsWith("Helper"))
                .AsImplementedInterfaces();

            IContainer container = builder.Build();

            return container;
        }
    }
}
