namespace Service.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseBase")]
    public partial class HouseBase
    {
        /// <summary>
        /// С���۸�����
        /// </summary>
        [StringLength(500)]
        public string estatePriceTrent { get; set; }

        /// <summary>
        /// С������
        /// </summary>
        [StringLength(4000)]
        public string estateDes { get; set; }

        /// <summary>
        /// С����ַ
        /// </summary>
        [StringLength(50)]
        public string estateAdress { get; set; }

        /// <summary>
        /// С������
        /// </summary>
        [StringLength(50)]
        public string estateLocal { get; set; }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime createTime { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        [StringLength(50)]
        public string houseProportion { get; set; }

        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// �������ͣ����֣��ⷿ���·���
        /// </summary>
        [StringLength(20)]
        public string  type { get; set; }
        [StringLength(500)]
        public string modelTitle { get; set; }
        /// <summary>
        /// ��վ����
        /// </summary>
        [StringLength(50)]
        public string web { get; set; }
        /// <summary>
        /// ��վ��ӦID
        /// </summary>
        
        public string modelID { get; set; }

        [StringLength(100)]
        public string modelUrl { get; set; }

        #region [ ��Դ��Ϣ ]


        //�ܼ�
        [StringLength(50)]
        public string totalPrice { get; set; }
        // ��
        [StringLength(50)]
        public string unitPrice { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(50)]
        public string houseType { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(50)]
        public string houseTotal { get; set; }
        // �����
        [StringLength(50)]
        public string houseSize { get; set; }
        // ��¥��
        [StringLength(50)]
        public string houseFloor { get; set; }
        // �����
        [StringLength(50)]
        public string houseFitment { get; set; }
        // ��
        [StringLength(50)]
        public string houseOrt { get; set; }
        // ������
        [StringLength(50)]
        public string buildType { get; set; }
  
        // �����
        [StringLength(50)]
        public string estateAge { get; set; }
        //������
        [StringLength(50)]
        public string estatePlot { get; set; }
        // ַ
        [StringLength(50)]
        public string houseAddress { get; set; }

        #endregion

        #region [ С����Ϣ ]

        /// <summary>
        /// С������
        /// </summary>
        [StringLength(50)]
        public string estateName { get; set; }
        /// <summary>
        /// ��ҵ��
        /// </summary>
        [StringLength(50)]
        public string managerName { get; set; }
        /// <summary>
        ///   //ҵ������
        /// </summary>
        [StringLength(50)]
        public string estateDevelopers { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [StringLength(50)]
        public string managerType { get; set; }
        /// <summary>
        /// С������
        /// </summary>
        [StringLength(50)]
        public string estateArea { get; set; }
        /// <summary>
        /// �̻���
        /// </summary>
        [StringLength(50)]
        public string estateGreen { get; set; }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        [StringLength(50)]
        public string managerPrice { get; set; }
        /// <summary>
        ///��λ���� 
        /// </summary>
        [StringLength(50)]
        public string carNum { get; set; }
        /// <summary>
        /// λ����
        /// </summary>
        [StringLength(50)]
        public string carPrice { get; set; }
        /// <summary>
        /// �۷�Դ
        /// </summary>
        [StringLength(50)]
        public string sellHouseNum { get; set; }
        /// <summary>
        /// �ⷿ����
        /// </summary>
        [StringLength(50)]
        public string rentingNum { get; set; }
        /// <summary>
        /// ����ǰ���������¾��۱Ƚ�
        /// </summary>
        [StringLength(200)]
        public string estateAvgPrice { get; set; }




        #endregion

        #region [ �н���Ϣ ]

        /// <summary>
        /// �н�����
        /// </summary>
        [StringLength(50)]
        public string brokerName { get; set; }
        /// <summary>
        /// �н���վ
        /// </summary>
        [StringLength(50)]
        public string brokerWeb { get; set; }
        /// <summary>
        /// �н����
        /// </summary>
        [StringLength(50)]
        public string brokerShoper { get; set; }
        /// <summary>
        /// �н��ֻ���
        /// </summary>
        [StringLength(50)]
        public string brokerMobile { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        [StringLength(50)]
        public string feature { get; set; }
        /// <summary>
        /// �¼۱Ƚ�
        /// </summary>
        [StringLength(50)]
        public string compare { get; set; }
  
        /// <summary>
        /// ռ�����
        /// </summary>
        [StringLength(50)]
        public string spaceArea { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        [StringLength(50)]
        public string buildArea { get; set; }



        #endregion

    }
}
