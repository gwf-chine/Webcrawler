namespace Service.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelBase")]
    public partial class HotelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelBase()
        {
            HotelComments = new HashSet<HotelComments>();
            HotelReserves = new HashSet<HotelReserves>();
        }

        public Guid ID { get; set; }

        public string HotelName { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string HotelType { get; set; }

        public string HotelAddress { get; set; }

        public string Grade { get; set; }

        [StringLength(50)]
        public string TotalComment { get; set; }

        public string HotelMobile { get; set; }

        public string OpenTime { get; set; }

        public string RecentlyFitment { get; set; }

        [StringLength(100)]
        public string HouseNumner { get; set; }

        public int HotelFloors { get; set; }

        public string HotelDes { get; set; }

        public string HotelFacility { get; set; }

        public string HotelServe { get; set; }

        public string HouseFacility { get; set; }

        public string Impression { get; set; }

        public string ImgUrl { get; set; }

        public string HotelUrl { get; set; }

        public DateTime CreateTime { get; set; }

        public string Web { get; set; }

        public string HotelID { get; set; }

        public string LowPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelComments> HotelComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelReserves> HotelReserves { get; set; }
    }
}
