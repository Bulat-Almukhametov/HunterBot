using Autofac;
using Autofac.Integration.Mvc;
using BotHunter.Models;
using BotHunter.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotHunter.App_Start
{
    public class IocConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterType(typeof(DataRepository));
            builder.RegisterType(typeof(FormsAuthorization)).As<IAuthorization>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}