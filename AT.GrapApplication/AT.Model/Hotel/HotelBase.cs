namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelBase")]
    public partial class HotelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelBase()
        {
            HotelComments = new HashSet<HotelComments>();
            HotelReserves = new HashSet<HotelReserves>();
        }

        public Guid ID { get; set; }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// ʡ��
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        public string HotelType { get; set; }
        /// <summary>
        /// �Ƶ��ַ
        /// </summary>
        public string HotelAddress { get; set; }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        public string Grade { get; set; }

       /// <summary>
       /// ������
       /// </summary>
        public int TotalComment { get; set; }
        /// <summary>
        /// �Ƶ�绰��
        /// </summary>
        public string HotelMobile { get; set; }
        /// <summary>
        /// ��ҵʱ��
        /// </summary>
        public string OpenTime { get; set; }
        /// <summary>
        /// װ�����
        /// </summary>
        public string RecentlyFitment { get; set; }

       /// <summary>
       /// ��������
       /// </summary>
        public int HouseNumner { get; set; }
        /// <summary>
        /// ¥��
        /// </summary>
        public int HotelFloors { get; set; }
        /// <summary>
        /// �Ƶ���
        /// </summary>
        public string HotelDes { get; set; }
        /// <summary>
        /// �Ƶ���ʩ
        /// </summary>
        public string HotelFacility { get; set; }
        /// <summary>
        /// �Ƶ����
        /// </summary>
        public string HotelServe { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string HouseFacility { get; set; }
        /// <summary>
        /// ӡ��
        /// </summary>
        public string Impression { get; set; }
        /// <summary>
        /// ��ͼ����
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// �Ƶ�����
        /// </summary>
        public string HotelUrl { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ��վ
        /// </summary>
        public string Web { get; set; }
        /// <summary>
        /// �Ƶ�ID
        /// </summary>
        public string HotelID { get; set; }
        /// <summary>
        /// ��ͼ�
        /// </summary>
        public string LowPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelComments> HotelComments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelReserves> HotelReserves { get; set; }
    }
}
