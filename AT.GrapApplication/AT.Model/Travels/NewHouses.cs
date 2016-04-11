namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// 新房基本信息表
    /// </summary>
    public partial class NewHouses
    {
        public Guid ID { get; set; }
        /// <summary>
        /// 新房标题
        /// </summary>
        [StringLength(500)]
        public string modelTitle { get; set; }
        /// <summary>
        /// 网站
        /// </summary>
        [StringLength(50)]
        public string web { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string modelID { get; set; }
        /// <summary>
        /// 网站地址
        /// </summary>
        [StringLength(100)]
        public string modelUrl { get; set; }
        /// <summary>
        /// 开发商
        /// </summary>
        [StringLength(50)]
        public string Developers { get; set; }
        /// <summary>
        /// 物业类型
        /// </summary>
        [StringLength(50)]
        public string ManagerType { get; set; }
        /// <summary>
        /// 装修
        /// </summary>
        [StringLength(50)]
        public string Decoration { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        [StringLength(50)]
        public string UnitPrice { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(4000)]
        public string Description { get; set; }
        /// <summary>
        /// 开盘时间
        /// </summary>
        [StringLength(50)]
        public string OpenTime { get; set; }
        /// <summary>
        /// 交房时间
        /// </summary>
        [StringLength(50)]
        public string HouseTime { get; set; }
        /// <summary>
        /// 售楼电话
        /// </summary>
        [StringLength(50)]
        public string Mobile { get; set; }
        /// <summary>
        /// 装修案例
        /// </summary>
        [StringLength(50)]
        public string CaseFitment { get; set; }
        /// <summary>
        /// 环线
        /// </summary>
        [StringLength(50)]
        public string LoopLine { get; set; }
        /// <summary>
        /// 开发证明
        /// </summary>
        [StringLength(400)]
        public string EstateLicence { get; set; }
        /// <summary>
        /// 物业地址
        /// </summary>
        [StringLength(400)]
        public string EstateManagerAddress { get; set; }
        /// <summary>
        /// 小区容积率
        /// </summary>
        [StringLength(50)]
        public string EstatePlot { get; set; }
        /// <summary>
        /// 小区绿化率
        /// </summary>
        [StringLength(50)]
        public string EstateGreen { get; set; }
        /// <summary>
        /// 占地面积
        /// </summary>
        [StringLength(50)]
        public string SpaceArea { get; set; }
        /// <summary>
        /// 特色
        /// </summary>
        [StringLength(50)]
        public string Feature { get; set; }
        /// <summary>
        /// 售楼地址
        /// </summary>
        [StringLength(500)]
        public string EstateSellAddress { get; set; }
        /// <summary>
        /// 交通路线
        /// </summary>
        [StringLength(500)]
        public string EstateTraffic { get; set; }
        /// <summary>
        /// 历史价格
        /// </summary>
        public string HistoryPrice { get; set; }
        /// <summary>
        /// 项目配套
        /// </summary>
        public string ProjectMating { get; set; }
        /// <summary>
        /// 其他信息
        /// </summary>
        public string ElseInfo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 小区名称
        /// </summary>
        [StringLength(50)]
        public string EstateName { get; set; }
        /// <summary>
        /// 小区面积
        /// </summary>
        [StringLength(50)]
        public string EstateArea { get; set; }
        /// <summary>
        /// 绿化率
        /// </summary>
        [StringLength(50)]
        public string EstateGreenRatio { get; set; }
        /// <summary>
        /// 小区物业
        /// </summary>
        [StringLength(50)]
        public string EstateManager { get; set; }
        /// <summary>
        /// 小区车位
        /// </summary>
        [StringLength(50)]
        public string EstateCarNum { get; set; }
        /// <summary>
        /// 车位费
        /// </summary>
        [StringLength(50)]
        public string EstateCarPrice { get; set; }
        /// <summary>
        /// 容积率
        /// </summary>
        [StringLength(50)]
        public string EstatePlotRatio { get; set; }
        /// <summary>
        /// 装修
        /// </summary>
        [StringLength(50)]
        public string EstateFitment { get; set; }
        /// <summary>
        /// 物业费用
        /// </summary>
        [StringLength(50)]
        public string EstateManagerFlot { get; set; }
        /// <summary>
        /// 建筑类型
        /// </summary>
        [StringLength(50)]
        public string EstateBuildType { get; set; }
        /// <summary>
        /// 停车场
        /// </summary>
        [StringLength(500)]
        public string EstateCarport { get; set; }
        /// <summary>
        /// 建筑装修
        /// </summary>
        [StringLength(50)]
        public string EstateBuildFitment { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        [StringLength(500)]
        public string EstateFloor { get; set; }

        public string EstateTitling { get; set; }
        /// <summary>
        /// 房屋数量
        /// </summary>
        public string EstateHouseNumber { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public string TotalPrice { get; set; }
        /// <summary>
        /// 销售电话
        /// </summary>
        public string EstateSellMobile { get; set; }
        /// <summary>
        /// 最低首付
        /// </summary>
        public string LowestPayment { get; set; }
        /// <summary>
        /// 月供
        /// </summary>
        public string MonthPayment { get; set; }
        /// <summary>
        /// 房屋类型
        /// </summary>
        public string HouseType { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        public string TotalSize { get; set; }
        /// <summary>
        /// 产权
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public string BuildSize { get; set; }
        /// <summary>
        /// 供暖类型
        /// </summary>
        public string HeatingType { get; set; }
        /// <summary>
        /// 公共设施
        /// </summary>
        public string Utilities { get; set; }
        /// <summary>
        /// 厌恶设施
        /// </summary>
        public string Disgust { get; set; }
    }
}
