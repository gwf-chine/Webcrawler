using Antuo.Data.Core.Infrastructure;
using Antuo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antuo.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable, IDependency
    {
        ATHouseContext Get();
    }
}
