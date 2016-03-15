using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.Data.Infrastructure;
using Service.Model;

namespace Service.Data.Repositories
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
