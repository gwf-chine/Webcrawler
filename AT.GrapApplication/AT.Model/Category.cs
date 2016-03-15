using System.Collections.Generic;

namespace Antuo.Model
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}