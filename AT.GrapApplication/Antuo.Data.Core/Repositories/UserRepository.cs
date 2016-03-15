using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antuo.Data.Infrastructure;
using Antuo.Model;

namespace Antuo.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
        {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IUserRepository : IRepository<User>
    {
    }    
}
