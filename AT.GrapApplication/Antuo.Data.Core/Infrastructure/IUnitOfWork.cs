using Antuo.Data.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antuo.Data.Infrastructure
{
   
    public interface IUnitOfWork : IDisposable, IDependency
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
        void ExecuteProcedure(string procedureCommand, params object[] sqlParams);
        void Commit();
    }
}
