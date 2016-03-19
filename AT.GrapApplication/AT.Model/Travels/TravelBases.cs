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

        /// <summary>
        /// 满意度
        /// </summary>
        public string Satisfaction { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public string SalesCount { get; set; }
        /// <summary>
        /// 评价量
        /// </summary>
        public string CommentCount { get; set; }
        /// <summary>
        /// 好评率
        /// </summary>
        public string FeedBackRate { get; set; }
        /// <summary>
        /// 发团时间
        /// </summary>
        public string MassTime { get; set; }
        /// <summary>
        /// 交通信息
        /// </summary>
        public string TraficcInfo { get; set; }
        /// <summary>
        /// 热门指数
        /// </summary>
        public string Popular { get; set; }
        /// <summary>
        /// 咨询热线
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 推荐
        /// </summary>
        public string Recommend { get; set; }
        /// <summary>
        /// 优惠信息
        /// </summary>
        public string SpecialInfo { get; set; }
        /// <summary>
        /// 产品特色
        /// </summary>
        public string ProductSpecial { get; set; }
        /// <summary>
        /// 行程安排
        /// </summary>
        public string Scheduling { get; set; }
        /// <summary>
        /// 预定须知
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// 出游贴士
        /// </summary>
        public string TravelTips { get; set; }
        /// <summary>
        /// 综合得分
        /// </summary>
        public string CommonPoint { get; set; }
        /// <summary>
        /// 出游体验
        /// </summary>
        public string TravelExperience { get; set; }

        /// <summary>
        /// 专属客服
        /// </summary>
        public string DedicatedService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LeadService { get; set; }

        public string Url { get; set; }

        public DateTime CreateTime { get; set; }

        public string Web { get; set; }

        public string TravelID { get; set; }
    }
}
