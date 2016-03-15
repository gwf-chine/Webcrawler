using Antuo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Antuo.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ATHouseContext Get();
    }
}
