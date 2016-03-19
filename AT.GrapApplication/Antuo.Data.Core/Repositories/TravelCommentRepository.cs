using Antuo.Data.Infrastructure;
using Antuo.Model.Travels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antuo.Data.Core.Repositories
{
    public class TravelCommentRepository : RepositoryBase<TravelComments>, ITravelCommentRepository
    {
        public TravelCommentRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

    }
    public interface ITravelCommentRepository : IRepository<TravelComments>
    {


    }
}
