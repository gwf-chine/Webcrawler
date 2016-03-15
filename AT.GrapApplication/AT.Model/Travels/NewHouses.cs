namespace Service.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewHouses
    {
        public Guid ID { get; set; }

        [StringLength(500)]
        public string modelTitle { get; set; }

        [StringLength(50)]
        public string web { get; set; }

        public string modelID { get; set; }

        [StringLength(100)]
        public string modelUrl { get; set; }

        [StringLength(50)]
        public string Developers { get; set; }

        [StringLength(50)]
        public string ManagerType { get; set; }

        [StringLength(50)]
        public string Decoration { get; set; }

        [StringLength(50)]
        public string UnitPrice { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(50)]
        public string OpenTime { get; set; }

        [StringLength(50)]
        public string HouseTime { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string CaseFitment { get; set; }

        [StringLength(50)]
        public string LoopLine { get; set; }

        [StringLength(400)]
        public string EstateLicence { get; set; }

        [StringLength(400)]
        public string EstateManagerAddress { get; set; }

        [StringLength(50)]
        public string EstatePlot { get; set; }

        [StringLength(50)]
        public string EstateGreen { get; set; }

        [StringLength(50)]
        public string SpaceArea { get; set; }

        [StringLength(50)]
        public string Feature { get; set; }

        [StringLength(500)]
        public string EstateSellAddress { get; set; }

        [StringLength(500)]
        public string EstateTraffic { get; set; }

        public string HistoryPrice { get; set; }

        public string ProjectMating { get; set; }

        public string ElseInfo { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string EstateName { get; set; }

        [StringLength(50)]
        public string EstateArea { get; set; }

        [StringLength(50)]
        public string EstateGreenRatio { get; set; }

        [StringLength(50)]
        public string EstateManager { get; set; }

        [StringLength(50)]
        public string EstateCarNum { get; set; }

        [StringLength(50)]
        public string EstateCarPrice { get; set; }

        [StringLength(50)]
        public string EstatePlotRatio { get; set; }

        [StringLength(50)]
        public string EstateFitment { get; set; }

        [StringLength(50)]
        public string EstateManagerFlot { get; set; }

        [StringLength(50)]
        public string EstateBuildType { get; set; }

        [StringLength(500)]
        public string EstateCarport { get; set; }

        [StringLength(50)]
        public string EstateBuildFitment { get; set; }

        [StringLength(500)]
        public string EstateFloor { get; set; }

        public string EstateTitling { get; set; }

        public string EstateHouseNumber { get; set; }

        public string TotalPrice { get; set; }

        public string EstateSellMobile { get; set; }

        public string LowestPayment { get; set; }

        public string MonthPayment { get; set; }

        public string HouseType { get; set; }

        public string TotalSize { get; set; }

        public string Property { get; set; }

        public string BuildSize { get; set; }

        public string HeatingType { get; set; }

        public string Utilities { get; set; }

        public string Disgust { get; set; }
    }
}
