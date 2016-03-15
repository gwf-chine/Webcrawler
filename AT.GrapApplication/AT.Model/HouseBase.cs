namespace Service.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseBase")]
    public partial class HouseBase
    {
        /// <summary>
        /// 小区价格趋势
        /// </summary>
        [StringLength(500)]
        public string estatePriceTrent { get; set; }

        /// <summary>
        /// 小区描述
        /// </summary>
        [StringLength(4000)]
        public string estateDes { get; set; }

        /// <summary>
        /// 小区地址
        /// </summary>
        [StringLength(50)]
        public string estateAdress { get; set; }

        /// <summary>
        /// 小区区域
        /// </summary>
        [StringLength(50)]
        public string estateLocal { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime createTime { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        [StringLength(50)]
        public string houseProportion { get; set; }

        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// 房屋类型（二手，租房，新房）
        /// </summary>
        [StringLength(20)]
        public string  type { get; set; }
        [StringLength(500)]
        public string modelTitle { get; set; }
        /// <summary>
        /// 网站名称
        /// </summary>
        [StringLength(50)]
        public string web { get; set; }
        /// <summary>
        /// 网站对应ID
        /// </summary>
        
        public string modelID { get; set; }

        [StringLength(100)]
        public string modelUrl { get; set; }

        #region [ 房源信息 ]


        //总价
        [StringLength(50)]
        public string totalPrice { get; set; }
        // 价
        [StringLength(50)]
        public string unitPrice { get; set; }
        /// <summary>
        /// 房屋类型
        /// </summary>
        [StringLength(50)]
        public string houseType { get; set; }
        /// <summary>
        /// 房屋组数
        /// </summary>
        [StringLength(50)]
        public string houseTotal { get; set; }
        // 筑面积
        [StringLength(50)]
        public string houseSize { get; set; }
        // 在楼层
        [StringLength(50)]
        public string houseFloor { get; set; }
        // 修情况
        [StringLength(50)]
        public string houseFitment { get; set; }
        // 向
        [StringLength(50)]
        public string houseOrt { get; set; }
        // 筑类型
        [StringLength(50)]
        public string buildType { get; set; }
  
        // 筑年代
        [StringLength(50)]
        public string estateAge { get; set; }
        //区名称
        [StringLength(50)]
        public string estatePlot { get; set; }
        // 址
        [StringLength(50)]
        public string houseAddress { get; set; }

        #endregion

        #region [ 小区信息 ]

        /// <summary>
        /// 小区名称
        /// </summary>
        [StringLength(50)]
        public string estateName { get; set; }
        /// <summary>
        /// 物业名
        /// </summary>
        [StringLength(50)]
        public string managerName { get; set; }
        /// <summary>
        ///   //业开发商
        /// </summary>
        [StringLength(50)]
        public string estateDevelopers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string managerType { get; set; }
        /// <summary>
        /// 小区区域
        /// </summary>
        [StringLength(50)]
        public string estateArea { get; set; }
        /// <summary>
        /// 绿化率
        /// </summary>
        [StringLength(50)]
        public string estateGreen { get; set; }
        /// <summary>
        /// 物业费用
        /// </summary>
        [StringLength(50)]
        public string managerPrice { get; set; }
        /// <summary>
        ///车位数量 
        /// </summary>
        [StringLength(50)]
        public string carNum { get; set; }
        /// <summary>
        /// 位费用
        /// </summary>
        [StringLength(50)]
        public string carPrice { get; set; }
        /// <summary>
        /// 售房源
        /// </summary>
        [StringLength(50)]
        public string sellHouseNum { get; set; }
        /// <summary>
        /// 租房数量
        /// </summary>
        [StringLength(50)]
        public string rentingNum { get; set; }
        /// <summary>
        /// 区当前均价与上月均价比较
        /// </summary>
        [StringLength(200)]
        public string estateAvgPrice { get; set; }




        #endregion

        #region [ 中介信息 ]

        /// <summary>
        /// 中介名称
        /// </summary>
        [StringLength(50)]
        public string brokerName { get; set; }
        /// <summary>
        /// 中介网站
        /// </summary>
        [StringLength(50)]
        public string brokerWeb { get; set; }
        /// <summary>
        /// 中介店铺
        /// </summary>
        [StringLength(50)]
        public string brokerShoper { get; set; }
        /// <summary>
        /// 中介手机号
        /// </summary>
        [StringLength(50)]
        public string brokerMobile { get; set; }
        /// <summary>
        /// 特色
        /// </summary>
        [StringLength(50)]
        public string feature { get; set; }
        /// <summary>
        /// 月价比较
        /// </summary>
        [StringLength(50)]
        public string compare { get; set; }
  
        /// <summary>
        /// 占地面积
        /// </summary>
        [StringLength(50)]
        public string spaceArea { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        [StringLength(50)]
        public string buildArea { get; set; }



        #endregion

    }
}
