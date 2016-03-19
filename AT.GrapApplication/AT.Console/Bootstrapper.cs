using Antuo.Data.Core.Repositories;
using Antuo.Data.Infrastructure;
using Antuo.Model;
using AT.Controller;
using AT.Controller.Travel;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Http;
using Antuo.Data.Core.Infrastructure;

namespace AT.Main
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
           
        }
        private static void SetAutofacContainer()
        {
        
            var builder = new ContainerBuilder();


     


            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TravelBaseRepository>().As<ITravelBaseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TravelCommentRepository>().As<ITravelCommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ATHouseContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<XieChengController>().InstancePerLifetimeScope();
            builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var manager = container.Resolve<XieChengController>();
            manager.Run("三亚");

        }
    }
}
