namespace Antuo.Model.Travels
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
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 酒店类型
        /// </summary>
        public string HotelType { get; set; }
        /// <summary>
        /// 酒店地址
        /// </summary>
        public string HotelAddress { get; set; }
        /// <summary>
        /// 酒店评分
        /// </summary>
        public string Grade { get; set; }

       /// <summary>
       /// 评价量
       /// </summary>
        public int TotalComment { get; set; }
        /// <summary>
        /// 酒店电话号
        /// </summary>
        public string HotelMobile { get; set; }
        /// <summary>
        /// 开业时间
        /// </summary>
        public string OpenTime { get; set; }
        /// <summary>
        /// 装修年份
        /// </summary>
        public string RecentlyFitment { get; set; }

       /// <summary>
       /// 房间数量
       /// </summary>
        public int HouseNumner { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public int HotelFloors { get; set; }
        /// <summary>
        /// 酒店简介
        /// </summary>
        public string HotelDes { get; set; }
        /// <summary>
        /// 酒店设施
        /// </summary>
        public string HotelFacility { get; set; }
        /// <summary>
        /// 酒店服务
        /// </summary>
        public string HotelServe { get; set; }
        /// <summary>
        /// 房间服务
        /// </summary>
        public string HouseFacility { get; set; }
        /// <summary>
        /// 印象
        /// </summary>
        public string Impression { get; set; }
        /// <summary>
        /// 主图连接
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 酒店连接
        /// </summary>
        public string HotelUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 网站
        /// </summary>
        public string Web { get; set; }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public string HotelID { get; set; }
        /// <summary>
        /// 最低价
        /// </summary>
        public string LowPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelComments> HotelComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelReserves> HotelReserves { get; set; }
    }
}
