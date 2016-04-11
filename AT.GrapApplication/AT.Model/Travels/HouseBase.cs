namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 出租房和二手房
    /// </summary>
    [Table("HouseBase")]
    public partial class HouseBase
    {
        public Guid ID { get; set; }

        /// <summary>
        /// 连接地址
        /// </summary>
        [StringLength(100)]
        public string modelUrl { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        [StringLength(500)]
        public string totalPrice { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [StringLength(50)]
        public string unitPrice { get; set; }
        /// <summary>
        /// 房屋类型
        /// </summary>
        [StringLength(500)]
        public string houseType { get; set; }
        /// <summary>
        /// 房屋面积
        /// </summary>
        [StringLength(50)]
        public string houseSize { get; set; }
        /// <summary>
        /// 房屋楼层
        /// </summary>
        [StringLength(50)]
        public string houseFloor { get; set; }
        /// <summary>
        /// 房屋装修
        /// </summary>
        [StringLength(50)]
        public string houseFitment { get; set; }
        /// <summary>
        /// 房屋朝向
        /// </summary>
        [StringLength(50)]
        public string houseOrt { get; set; }
        /// <summary>
        /// 建筑 类型
        /// </summary>
        [StringLength(50)]
        public string buildType { get; set; }
        /// <summary>
        /// 房屋地址
        /// </summary>
        [StringLength(50)]
        public string houseAddress { get; set; }

        [StringLength(50)]
        public string brokerName { get; set; }

        [StringLength(2000)]
        public string brokerWeb { get; set; }

        [StringLength(200)]
        public string brokerShoper { get; set; }

        [StringLength(200)]
        public string brokerMobile { get; set; }
        /// <summary>
        /// 连接地址
        /// </summary>
        [StringLength(50)]
        public string web { get; set; }
        /// <summary>
        /// 房屋ID
        /// </summary>
        public string modelID { get; set; }
        /// <summary>
        /// 房屋标题
        /// </summary>
        [StringLength(500)]
        public string modelTitle { get; set; }

        [StringLength(50)]
        public string houseProportion { get; set; }
        /// <summary>
        /// 类型 二手房 or 出租房
        /// </summary>
        [StringLength(20)]
        public string Type { get; set; }
        /// <summary>
        /// 物业名称
        /// </summary>
        [StringLength(50)]
        public string ManagerName { get; set; }
        /// <summary>
        /// 物业类型
        /// </summary>
        [StringLength(50)]
        public string ManagerType { get; set; }
        /// <summary>
        /// 物业费
        /// </summary>
        [StringLength(50)]
        public string ManagerPrice { get; set; }
        /// <summary>
        /// 车位数量
        /// </summary>
        [StringLength(50)]
        public string CarNum { get; set; }
        /// <summary>
        /// 车位费
        /// </summary>
        [StringLength(50)]
        public string CarPrice { get; set; }
        /// <summary>
        /// 在售房源数量
        /// </summary>
        [StringLength(50)]
        public string SellHouseNum { get; set; }
        /// <summary>
        /// 小区租房数量
        /// </summary>
        [StringLength(50)]
        public string Rentingnum { get; set; }
        /// <summary>
        /// 小区销售均价
        /// </summary>
        [StringLength(500)]
        public string EstatePriceTrent { get; set; }
        /// <summary>
        /// 小区地址
        /// </summary>
        [StringLength(50)]
        public string EstateAdress { get; set; }
        /// <summary>
        /// 售楼地址
        /// </summary>
        public string EstateLocal { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 房屋总数
        /// </summary>
        [StringLength(50)]
        public string HouseTotal { get; set; }
        /// <summary>
        /// 小区年份
        /// </summary>
        [StringLength(50)]
        public string EstateAge { get; set; }
        /// <summary>
        /// 小区容积率
        /// </summary>
        [StringLength(50)]
        public string EstatePlot { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        [StringLength(50)]
        public string EstateName { get; set; }
        /// <summary>
        /// 小区开发商
        /// </summary>
        [StringLength(50)]
        public string EstateDevelopers { get; set; }
        /// <summary>
        /// 小区面积
        /// </summary>
        [StringLength(50)]
        public string EstateArea { get; set; }
        /// <summary>
        /// 小区绿化率
        /// </summary>
        [StringLength(50)]
        public string EstateGreen { get; set; }
        /// <summary>
        /// 小区均价
        /// </summary>
        [StringLength(200)]
        public string EstateAvgPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        public string Feature { get; set; }

        [StringLength(200)]
        public string Compare { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        public string SpaceArea { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        [StringLength(200)]
        public string BuildArea { get; set; }
        /// <summary>
        /// 房屋描述
        /// </summary>
        [StringLength(4000)]
        public string HouseDes { get; set; }
        /// <summary>
        /// 价格类型
        /// </summary>
        public string PriceType { get; set; }
        /// <summary>
        /// 出租类型
        /// </summary>
        public string RentType { get; set; }

        public string HouseDeploy { get; set; }
        /// <summary>
        /// 小区面积
        /// </summary>
        public string EstateSize { get; set; }
        /// <summary>
        /// 购房首付
        /// </summary>
        public string FirstPayment { get; set; }
        /// <summary>
        /// 月供
        /// </summary>
        public string MonthPayment { get; set; }
        /// <summary>
        /// 公寓
        /// </summary>
        public string Apartments { get; set; }
        /// <summary>
        /// 建筑桀纣
        /// </summary>
        public string BuildStructure { get; set; }
        /// <summary>
        /// 产权
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string District { get; set; }
    }
}
