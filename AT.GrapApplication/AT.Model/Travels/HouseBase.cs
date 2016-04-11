namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// ���ⷿ�Ͷ��ַ�
    /// </summary>
    [Table("HouseBase")]
    public partial class HouseBase
    {
        public Guid ID { get; set; }

        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        [StringLength(100)]
        public string modelUrl { get; set; }
        /// <summary>
        /// �ܼ�
        /// </summary>
        [StringLength(500)]
        public string totalPrice { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [StringLength(50)]
        public string unitPrice { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(500)]
        public string houseType { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [StringLength(50)]
        public string houseSize { get; set; }
        /// <summary>
        /// ����¥��
        /// </summary>
        [StringLength(50)]
        public string houseFloor { get; set; }
        /// <summary>
        /// ����װ��
        /// </summary>
        [StringLength(50)]
        public string houseFitment { get; set; }
        /// <summary>
        /// ���ݳ���
        /// </summary>
        [StringLength(50)]
        public string houseOrt { get; set; }
        /// <summary>
        /// ���� ����
        /// </summary>
        [StringLength(50)]
        public string buildType { get; set; }
        /// <summary>
        /// ���ݵ�ַ
        /// </summary>
        [StringLength(50)]
        public string houseAddress { get; set; }

        [StringLength(50)]
        public string brokerName { get; set; }

        [StringLength(2000)]
        public string brokerWeb { get; set; }

        [StringLength(200)]
        public string brokerShoper { get; set; }

        [StringLength(200)]
        public string brokerMobile { get; set; }
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        [StringLength(50)]
        public string web { get; set; }
        /// <summary>
        /// ����ID
        /// </summary>
        public string modelID { get; set; }
        /// <summary>
        /// ���ݱ���
        /// </summary>
        [StringLength(500)]
        public string modelTitle { get; set; }

        [StringLength(50)]
        public string houseProportion { get; set; }
        /// <summary>
        /// ���� ���ַ� or ���ⷿ
        /// </summary>
        [StringLength(20)]
        public string Type { get; set; }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        [StringLength(50)]
        public string ManagerName { get; set; }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        [StringLength(50)]
        public string ManagerType { get; set; }
        /// <summary>
        /// ��ҵ��
        /// </summary>
        [StringLength(50)]
        public string ManagerPrice { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        [StringLength(50)]
        public string CarNum { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        [StringLength(50)]
        public string CarPrice { get; set; }
        /// <summary>
        /// ���۷�Դ����
        /// </summary>
        [StringLength(50)]
        public string SellHouseNum { get; set; }
        /// <summary>
        /// С���ⷿ����
        /// </summary>
        [StringLength(50)]
        public string Rentingnum { get; set; }
        /// <summary>
        /// С�����۾���
        /// </summary>
        [StringLength(500)]
        public string EstatePriceTrent { get; set; }
        /// <summary>
        /// С����ַ
        /// </summary>
        [StringLength(50)]
        public string EstateAdress { get; set; }
        /// <summary>
        /// ��¥��ַ
        /// </summary>
        public string EstateLocal { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(50)]
        public string HouseTotal { get; set; }
        /// <summary>
        /// С�����
        /// </summary>
        [StringLength(50)]
        public string EstateAge { get; set; }
        /// <summary>
        /// С���ݻ���
        /// </summary>
        [StringLength(50)]
        public string EstatePlot { get; set; }
        /// <summary>
        /// С������
        /// </summary>
        [StringLength(50)]
        public string EstateName { get; set; }
        /// <summary>
        /// С��������
        /// </summary>
        [StringLength(50)]
        public string EstateDevelopers { get; set; }
        /// <summary>
        /// С�����
        /// </summary>
        [StringLength(50)]
        public string EstateArea { get; set; }
        /// <summary>
        /// С���̻���
        /// </summary>
        [StringLength(50)]
        public string EstateGreen { get; set; }
        /// <summary>
        /// С������
        /// </summary>
        [StringLength(200)]
        public string EstateAvgPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        public string Feature { get; set; }

        [StringLength(200)]
        public string Compare { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(200)]
        public string SpaceArea { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [StringLength(200)]
        public string BuildArea { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(4000)]
        public string HouseDes { get; set; }
        /// <summary>
        /// �۸�����
        /// </summary>
        public string PriceType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string RentType { get; set; }

        public string HouseDeploy { get; set; }
        /// <summary>
        /// С�����
        /// </summary>
        public string EstateSize { get; set; }
        /// <summary>
        /// �����׸�
        /// </summary>
        public string FirstPayment { get; set; }
        /// <summary>
        /// �¹�
        /// </summary>
        public string MonthPayment { get; set; }
        /// <summary>
        /// ��Ԣ
        /// </summary>
        public string Apartments { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string BuildStructure { get; set; }
        /// <summary>
        /// ��Ȩ
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string District { get; set; }
    }
}
