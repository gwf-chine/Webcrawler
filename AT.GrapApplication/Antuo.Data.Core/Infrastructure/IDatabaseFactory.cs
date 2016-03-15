using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ATHouseContext Get();
    }
}
