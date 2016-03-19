using Antuo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antuo.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ATHouseContext dataContext;
        public ATHouseContext Get()
        {
            return dataContext ?? (dataContext = new ATHouseContext());
        }


        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }


    }
}
