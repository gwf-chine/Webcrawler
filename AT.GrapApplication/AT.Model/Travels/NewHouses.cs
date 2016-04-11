namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    /// <summary>
    /// �·�������Ϣ��
    /// </summary>
    public partial class NewHouses
    {
        public Guid ID { get; set; }
        /// <summary>
        /// �·�����
        /// </summary>
        [StringLength(500)]
        public string modelTitle { get; set; }
        /// <summary>
        /// ��վ
        /// </summary>
        [StringLength(50)]
        public string web { get; set; }
        /// <summary>
        /// ��ʶ
        /// </summary>
        public string modelID { get; set; }
        /// <summary>
        /// ��վ��ַ
        /// </summary>
        [StringLength(100)]
        public string modelUrl { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        [StringLength(50)]
        public string Developers { get; set; }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        [StringLength(50)]
        public string ManagerType { get; set; }
        /// <summary>
        /// װ��
        /// </summary>
        [StringLength(50)]
        public string Decoration { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [StringLength(50)]
        public string UnitPrice { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [StringLength(4000)]
        public string Description { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [StringLength(50)]
        public string OpenTime { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        [StringLength(50)]
        public string HouseTime { get; set; }
        /// <summary>
        /// ��¥�绰
        /// </summary>
        [StringLength(50)]
        public string Mobile { get; set; }
        /// <summary>
        /// װ�ް���
        /// </summary>
        [StringLength(50)]
        public string CaseFitment { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [StringLength(50)]
        public string LoopLine { get; set; }
        /// <summary>
        /// ����֤��
        /// </summary>
        [StringLength(400)]
        public string EstateLicence { get; set; }
        /// <summary>
        /// ��ҵ��ַ
        /// </summary>
        [StringLength(400)]
        public string EstateManagerAddress { get; set; }
        /// <summary>
        /// С���ݻ���
        /// </summary>
        [StringLength(50)]
        public string EstatePlot { get; set; }
        /// <summary>
        /// С���̻���
        /// </summary>
        [StringLength(50)]
        public string EstateGreen { get; set; }
        /// <summary>
        /// ռ�����
        /// </summary>
        [StringLength(50)]
        public string SpaceArea { get; set; }
        /// <summary>
        /// ��ɫ
        /// </summary>
        [StringLength(50)]
        public string Feature { get; set; }
        /// <summary>
        /// ��¥��ַ
        /// </summary>
        [StringLength(500)]
        public string EstateSellAddress { get; set; }
        /// <summary>
        /// ��ͨ·��
        /// </summary>
        [StringLength(500)]
        public string EstateTraffic { get; set; }
        /// <summary>
        /// ��ʷ�۸�
        /// </summary>
        public string HistoryPrice { get; set; }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ProjectMating { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string ElseInfo { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// С������
        /// </summary>
        [StringLength(50)]
        public string EstateName { get; set; }
        /// <summary>
        /// С�����
        /// </summary>
        [StringLength(50)]
        public string EstateArea { get; set; }
        /// <summary>
        /// �̻���
        /// </summary>
        [StringLength(50)]
        public string EstateGreenRatio { get; set; }
        /// <summary>
        /// С����ҵ
        /// </summary>
        [StringLength(50)]
        public string EstateManager { get; set; }
        /// <summary>
        /// С����λ
        /// </summary>
        [StringLength(50)]
        public string EstateCarNum { get; set; }
        /// <summary>
        /// ��λ��
        /// </summary>
        [StringLength(50)]
        public string EstateCarPrice { get; set; }
        /// <summary>
        /// �ݻ���
        /// </summary>
        [StringLength(50)]
        public string EstatePlotRatio { get; set; }
        /// <summary>
        /// װ��
        /// </summary>
        [StringLength(50)]
        public string EstateFitment { get; set; }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        [StringLength(50)]
        public string EstateManagerFlot { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        [StringLength(50)]
        public string EstateBuildType { get; set; }
        /// <summary>
        /// ͣ����
        /// </summary>
        [StringLength(500)]
        public string EstateCarport { get; set; }
        /// <summary>
        /// ����װ��
        /// </summary>
        [StringLength(50)]
        public string EstateBuildFitment { get; set; }
        /// <summary>
        /// ¥��
        /// </summary>
        [StringLength(500)]
        public string EstateFloor { get; set; }

        public string EstateTitling { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string EstateHouseNumber { get; set; }
        /// <summary>
        /// �ܼ�
        /// </summary>
        public string TotalPrice { get; set; }
        /// <summary>
        /// ���۵绰
        /// </summary>
        public string EstateSellMobile { get; set; }
        /// <summary>
        /// ����׸�
        /// </summary>
        public string LowestPayment { get; set; }
        /// <summary>
        /// �¹�
        /// </summary>
        public string MonthPayment { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string HouseType { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public string TotalSize { get; set; }
        /// <summary>
        /// ��Ȩ
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string BuildSize { get; set; }
        /// <summary>
        /// ��ů����
        /// </summary>
        public string HeatingType { get; set; }
        /// <summary>
        /// ������ʩ
        /// </summary>
        public string Utilities { get; set; }
        /// <summary>
        /// �����ʩ
        /// </summary>
        public string Disgust { get; set; }
    }
}
