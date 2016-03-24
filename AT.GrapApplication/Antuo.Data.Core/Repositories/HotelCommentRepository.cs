using Antuo.Data.Infrastructure;
using Antuo.Model.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antuo.Data.Core.Repositories
{
    public class HotelCommentRepository : RepositoryBase<HotelComments>, IHotelCommentRepository
    {
        public HotelCommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
      
    }
    public interface IHotelCommentRepository : IRepository<HotelComments>
    {
       
       
    }
}
