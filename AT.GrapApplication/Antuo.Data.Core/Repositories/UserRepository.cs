using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Data.Infrastructure;
using Service.Model;

namespace Service.Data.Repositories
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
