using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antuo.Data.Infrastructure;
using Antuo.Model;

namespace Antuo.Data.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IExpenseRepository : IRepository<Expense>
    {
    }
}
