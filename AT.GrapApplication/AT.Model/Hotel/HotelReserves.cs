namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelReserves
    {
        public Guid ID { get; set; }

        public string ReserveType { get; set; }

        public string ReservePlatform { get; set; }

        public string BreakFast { get; set; }

        public string Wifi { get; set; }

        public string TotalSell { get; set; }

        public string BuyRules { get; set; }

        public string Price { get; set; }

        public Guid HotelID { get; set; }

        public virtual HotelBase HotelBase { get; set; }
    }
}
