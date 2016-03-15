namespace Service.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelComments
    {
        public Guid ID { get; set; }

        public string UserGrade { get; set; }

        public string UserID { get; set; }

        public string HotelGrade { get; set; }

        public string HouseType { get; set; }

        public string HouseTime { get; set; }

        public string CommentTime { get; set; }

        public string CommentContent { get; set; }

        public string Url { get; set; }

        public Guid HotelID { get; set; }

        public string Reply { get; set; }

        public string DataRateid { get; set; }

        public virtual HotelBase HotelBase { get; set; }
    }
}
