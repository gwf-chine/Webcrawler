namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TravelComments
    {
        public Guid ID { get; set; }

        public string ProductTitle { get; set; }

        public string UserID { get; set; }

        public string UserGrade { get; set; }

        public string TravelType { get; set; }

        public string OverComment { get; set; }

        public string TourService { get; set; }

        public string Scheduling { get; set; }

        public string CaterHotel { get; set; }

        public string TravelTraficc { get; set; }

        public string Comment { get; set; }

        public string CommentTime { get; set; }

        public string UserClient { get; set; }

        public string Url { get; set; }

        public Guid TravelID { get; set; }

        public string ReplyContent { get; set; }

        public string ReplyTime { get; set; }

        public string CommentTitle { get; set; }

        public string RateId { get; set; }

        public string userName { get; set; }
    }
}
