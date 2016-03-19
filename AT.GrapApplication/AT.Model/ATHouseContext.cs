namespace Antuo.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Travels;
    using System.Collections.Generic;

    public partial class ATHouseContext : DbContext
    {
        public ATHouseContext()
            : base("name=ATHouse")
        {
        }

    
        public virtual DbSet<HotelBase> HotelBase { get; set; }
        public virtual DbSet<HotelComments> HotelComments { get; set; }
        public virtual DbSet<HotelReserves> HotelReserves { get; set; }

       

        public virtual DbSet<HouseBase> HouseBase { get; set; }
        public virtual DbSet<HuaWei> HuaWei { get; set; }
        public virtual DbSet<NewHouses> NewHouses { get; set; }
        public virtual DbSet<TravelBases> TravelBases { get; set; }
        public virtual DbSet<TravelComments> TravelComments { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelBase>()
                .HasMany(e => e.HotelComments)
                .WithRequired(e => e.HotelBase)
                .HasForeignKey(e => e.HotelID);

            modelBuilder.Entity<HotelBase>()
                .HasMany(e => e.HotelReserves)
                .WithRequired(e => e.HotelBase)
                .HasForeignKey(e => e.HotelID);
        }
       
    }
}
