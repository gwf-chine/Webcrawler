namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelComments
    {
        public Guid ID { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public string UserGrade { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 酒店评分
        /// </summary>
        public string HotelGrade { get; set; }
        /// <summary>
        /// 入住房型
        /// </summary>
        public string HouseType { get; set; }
        /// <summary>
        /// 入住时间
        /// </summary>
        public string HouseTime { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public string CommentTime { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// 连接
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid HotelID { get; set; }
        /// <summary>
        /// 回复
        /// </summary>
        public string Reply { get; set; }
        /// <summary>
        /// 评论ID
        /// </summary>
        public string DataRateid { get; set; }

        public virtual HotelBase HotelBase { get; set; }
    }
}
