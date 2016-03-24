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
using Service.Core.Common;

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


     


            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<TravelBaseRepository>().As<ITravelBaseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TravelCommentRepository>().As<ITravelCommentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ATHouseContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.Register(c => new LogHelper()).InstancePerLifetimeScope();
            builder.RegisterFilterProvider();


            var dataController = Assembly.Load("AT.Controller");

            builder.RegisterAssemblyTypes(dataController)
                   .Where(t => t.Name.EndsWith("Controller"))
                   .AsSelf()
                   .InstancePerLifetimeScope();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            var log = container.Resolve<LogHelper>();
            log.SetConfig();
            //var xiecheng = container.Resolve<XieChengController>();

            //xiecheng.Run("三亚");

            //var qunar = container.Resolve<QunarController>();

            //qunar.RunAndStartCity("深圳","三亚");

            var tuniu = container.Resolve<TuniuController>();
            tuniu.Run("三亚");

        }
    }
}
