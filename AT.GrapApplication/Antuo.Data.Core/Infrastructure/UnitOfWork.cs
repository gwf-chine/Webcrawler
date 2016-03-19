using Antuo.Model;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antuo.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IComponentContext _componentContext;
        private readonly IDatabaseFactory databaseFactory;
        private ATHouseContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory, IComponentContext componentContext)
        {
            this.databaseFactory = databaseFactory;
            _componentContext = componentContext;
        }

        protected ATHouseContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
           
            DataContext.Commit();
          
        }

        public void Dispose()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }

        public void ExecuteProcedure(string procedureCommand, params object[] sqlParams)
        {
            DataContext.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return _componentContext.Resolve<TRepository>();
        }
    }
}
