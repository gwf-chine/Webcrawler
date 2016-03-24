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
        /// �û��ȼ�
        /// </summary>
        public string UserGrade { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        public string HotelGrade { get; set; }
        /// <summary>
        /// ��ס����
        /// </summary>
        public string HouseType { get; set; }
        /// <summary>
        /// ��סʱ��
        /// </summary>
        public string HouseTime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string CommentTime { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid HotelID { get; set; }
        /// <summary>
        /// �ظ�
        /// </summary>
        public string Reply { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public string DataRateid { get; set; }

        public virtual HotelBase HotelBase { get; set; }
    }
}
