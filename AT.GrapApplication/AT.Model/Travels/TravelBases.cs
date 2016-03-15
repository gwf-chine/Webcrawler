namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TravelBases
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string TravelType { get; set; }

        public string StartCity { get; set; }

        public string ProductCode { get; set; }

        public string WebPrice { get; set; }

        public string FavMessage { get; set; }

        public string Satisfaction { get; set; }

        public string SalesCount { get; set; }

        public string CommentCount { get; set; }

        public string FeedBackRate { get; set; }

        public string MassTime { get; set; }

        public string TraficcInfo { get; set; }

        public string HotRoad { get; set; }

        public string Mobile { get; set; }

        public string Recommend { get; set; }

        public string ProductSpecia { get; set; }

        public string Scheduling { get; set; }

        public string Notice { get; set; }

        public string Tips { get; set; }

        public string ComPoint { get; set; }

        public string TravelExperience { get; set; }

        public string DedicatedService { get; set; }

        public string Url { get; set; }

        public DateTime CreateTime { get; set; }

        public string Web { get; set; }

        public string TravelID { get; set; }
    }
}
