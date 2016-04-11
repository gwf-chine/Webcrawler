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
        /// ��ˮ��
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>

        public string ProductCode { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string ProductTitle { get; set; }
        /// <summary>
        /// �û�ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// �û��ȼ�
        /// </summary>
        public string UserGrade { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string TravelType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string OverComment { get; set; }
        /// <summary>
        /// ����
        /// </summary>

        public string TourService { get; set; }
        /// <summary>
        /// ·��
        /// </summary>
        public string Scheduling { get; set; }

        public string CaterHotel { get; set; }
        /// <summary>
        /// ����·��
        /// </summary>
        public string TravelTraficc { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string CommentTime { get; set; }
        /// <summary>
        /// ������Դ
        /// </summary>
        public string UserClient { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// travelbase ID
        /// </summary>
        public Guid TravelID { get; set; }
        /// <summary>
        /// �ظ�����
        /// </summary>
        public string ReplyContent { get; set; }
        /// <summary>
        /// �ظ�ʱ��
        /// </summary>
        public string ReplyTime { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string CommentTitle { get; set; }
        /// <summary>
        /// ���۱�ʶ
        /// </summary>
        public string RateId { get; set; }
        /// <summary>
        /// �û��ǳ�
        /// </summary>
        public string userName { get; set; }
    }

}
