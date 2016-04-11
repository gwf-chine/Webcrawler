namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class TravelBases
    {
        public Guid ID { get; set; }
        /// <summary>
        /// ���α���
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string TravelType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string StartCity { get; set; }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string ProductCode { get; set; }
        /// <summary>
        /// �۸�
        /// </summary>
        public string WebPrice { get; set; }
        /// <summary>
        /// �Ż���Ϣ
        /// </summary>
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
        public int CommentCount { get; set; }
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
        /// ��ӷ���
        /// </summary>
        public string LeadService { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>

        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ��վ����
        /// </summary>

        public string Web { get; set; }
        /// <summary>
        /// ��Ӧ��վ��ʶ
        /// </summary>

        public string TravelID { get; set; }
    }

}
