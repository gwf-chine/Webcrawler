using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model
{
    /// <summary>
    /// 新楼盘
    /// </summary>
    [Table("NewHouses")]
   public class NewHouse
    {
        /// <summary>
        /// 装修案例
        /// </summary>
        [StringLength(50)]
        public string caseFitment { get; set; }
        /// <summary>
        /// 环线
        /// </summary>
        [StringLength(50)]
        public string loopLine { get; set; }

        [Key]
        public Guid ID { get; set; }
        /// <summary>
        /// 开发许可证
        /// </summary>
        [StringLength(400)]
        public string estateLicence { get; set; }
        /// <summary>
        /// 物业地址
        /// </summary>
        [StringLength(400)]
        public string estateManagerAddress { get; set; }

        /// <summary>
        /// 楼盘容积率
        /// </summary>
        [StringLength(50)]
        public string estatePlot { get; set; }
        /// <summary>
        /// 楼盘绿化率
        /// </summary>
        [StringLength(50)]
        public string estateGreen { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        [StringLength(50)]
        public string spaceArea { get; set; }
        /// <summary>
        /// 特色
        /// </summary>
        [StringLength(50)]
        public string feature { get; set; }

   

  
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



        #region [ 小区信息 ]

        /// <summary>
        /// 小区名称
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }
    
        /// <summary>
        ///   业开发商
        /// </summary>
        [StringLength(50)]
        public string developers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string managerType { get; set; }
        /// <summary>
        /// 小区面积
        /// </summary>
        [StringLength(50)]
        public string Area { get; set; }
        /// <summary>
        /// 绿化率
        /// </summary>
        [StringLength(50)]
        public string GreenRatio { get; set; }
        /// <summary>
        /// 物业名
        /// </summary>
        [StringLength(50)]
        public string ManagerName { get; set; }
     
        /// <summary>
        ///车位数量 
        /// </summary>
        [StringLength(50)]
        public string CarNum { get; set; }
        /// <summary>
        /// 位费用
        /// </summary>
        [StringLength(50)]
        public string CarPrice { get; set; }
    
        /// <summary>
        /// 容积率
        /// </summary>
        [StringLength(50)]
        public string PlotRatio { get; set; }
        /// <summary>
        /// 装修
        /// </summary>
        [StringLength(50)]
        public string Decoration { get; set; }
        /// <summary>
        /// 均价
        /// </summary>
        [StringLength(50)]
        public string unitPrice { get; set; }
        /// <summary>
        /// 楼盘描述
        /// </summary>
        [StringLength(4000)]
        public string description { get; set; }
        /// <summary>
        /// 装修
        /// </summary>
        [StringLength(50)]
        public string fitment { get; set; }
        /// <summary>
        /// 开盘时间
        /// </summary>
        [StringLength(50)]
        public string openTime { get; set; }
        /// <summary>
        /// 交房时间
        /// </summary>
        [StringLength(50)]
        public string houseTime { get; set; }
        /// <summary>
        /// 物业费用
        /// </summary>
        [StringLength(50)]
        public string managerFlot { get; set; }
        /// <summary>
        /// 主推户型
        /// </summary>
        [StringLength(50)]
        public string buildType { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(500)]
        public string estateSellAddress { get; set; }
        /// <summary>
        /// 咨询电话
        /// </summary>
        [StringLength(50)]
        public string mobile { get; set; }
        /// <summary>
        /// 交通情况
        /// </summary>
        [StringLength(500)]
        public string estateTraffic { get; set; }
        /// <summary>
        /// 历史价格
        /// </summary>
        [StringLength(5000)]
        public string historyPrice { get; set; }
        /// <summary>
        /// 项目配套
        /// </summary>
        [StringLength(5000)]
        public string projectMating { get; set; }
        /// <summary>
        /// 车位信息
        /// </summary>
        [StringLength(500)]
        public string carport { get; set; }
        /// <summary>
        /// 建材装修
        /// </summary>
        [StringLength(50)]
        public string buildFitment { get; set; }
        /// <summary>
        /// 楼层情况
        /// </summary>
        [StringLength(500)]
        public string floor { get; set; }

        /// <summary>
        /// 相关信息
        /// </summary>
        [StringLength(5000)]
        public string elseInfo { get; set; }
        public string Description { get; set; }


        #endregion


    }
}
