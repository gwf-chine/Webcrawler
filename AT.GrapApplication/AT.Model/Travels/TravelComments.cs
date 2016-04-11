namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TravelComments
    {

        /// <summary>
        /// 流水号
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>

        public string ProductCode { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductTitle { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public string UserGrade { get; set; }
        /// <summary>
        /// 旅游类型
        /// </summary>
        public string TravelType { get; set; }
        /// <summary>
        /// 总体评价
        /// </summary>
        public string OverComment { get; set; }
        /// <summary>
        /// 服务
        /// </summary>

        public string TourService { get; set; }
        /// <summary>
        /// 路线
        /// </summary>
        public string Scheduling { get; set; }

        public string CaterHotel { get; set; }
        /// <summary>
        /// 旅游路线
        /// </summary>
        public string TravelTraficc { get; set; }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 评价时间
        /// </summary>
        public string CommentTime { get; set; }
        /// <summary>
        /// 评价来源
        /// </summary>
        public string UserClient { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// travelbase ID
        /// </summary>
        public Guid TravelID { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; set; }
        /// <summary>
        /// 回复时间
        /// </summary>
        public string ReplyTime { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string CommentTitle { get; set; }
        /// <summary>
        /// 评论标识
        /// </summary>
        public string RateId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string userName { get; set; }
    }

}
