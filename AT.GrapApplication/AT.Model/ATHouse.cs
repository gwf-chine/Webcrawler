namespace AT.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ATHouse : DbContext
    {
        public ATHouse()
            : base("name=ATHouse")
        {
          
        }

        public virtual DbSet<HouseBase> HouseBase { get; set; }
        public virtual DbSet<NewHouse> NewHouse { get; set; }
        public virtual DbSet<HuaWei> HuaWei { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
