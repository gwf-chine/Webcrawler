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
        /// �����
        /// </summary>
        public string Satisfaction { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string SalesCount { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string CommentCount { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string FeedBackRate { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string MassTime { get; set; }
        /// <summary>
        /// ��ͨ��Ϣ
        /// </summary>
        public string TraficcInfo { get; set; }
        /// <summary>
        /// ����ָ��
        /// </summary>
        public string Popular { get; set; }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// �Ƽ�
        /// </summary>
        public string Recommend { get; set; }
        /// <summary>
        /// �Ż���Ϣ
        /// </summary>
        public string SpecialInfo { get; set; }
        /// <summary>
        /// ��Ʒ��ɫ
        /// </summary>
        public string ProductSpecial { get; set; }
        /// <summary>
        /// �г̰���
        /// </summary>
        public string Scheduling { get; set; }
        /// <summary>
        /// Ԥ����֪
        /// </summary>
        public string Notice { get; set; }
        /// <summary>
        /// ������ʿ
        /// </summary>
        public string TravelTips { get; set; }
        /// <summary>
        /// �ۺϵ÷�
        /// </summary>
        public string CommonPoint { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string TravelExperience { get; set; }

        /// <summary>
        /// ר���ͷ�
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
