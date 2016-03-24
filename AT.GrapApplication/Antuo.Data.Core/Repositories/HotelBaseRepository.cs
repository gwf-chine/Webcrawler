using Antuo.Data.Infrastructure;
using Antuo.Model.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antuo.Data.Core.Repositories
{
    public class HotelBaseRepository : RepositoryBase<HotelBase>, IHotelBaseRepository
    {
        public HotelBaseRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
      
    }
    public interface IHotelBaseRepository : IRepository<HotelBase>
    {
       
       
    }
}
