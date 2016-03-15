using Antuo.Data.Infrastructure;
using Antuo.Model.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antuo.Data.Core.Repositories
{
    public class TravelBaseRepository : RepositoryBase<HotelBase>, ITravelBaseRepository
    {
        public TravelBaseRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
      
    }
    public interface ITravelBaseRepository: IRepository<HotelBase>
    {
       
       
    }
}
