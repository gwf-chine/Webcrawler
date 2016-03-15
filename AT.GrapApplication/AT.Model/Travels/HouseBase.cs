namespace Antuo.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseBase")]
    public partial class HouseBase
    {
        public Guid ID { get; set; }

        [StringLength(100)]
        public string modelUrl { get; set; }

        [StringLength(500)]
        public string totalPrice { get; set; }

        [StringLength(50)]
        public string unitPrice { get; set; }

        [StringLength(500)]
        public string houseType { get; set; }

        [StringLength(50)]
        public string houseSize { get; set; }

        [StringLength(50)]
        public string houseFloor { get; set; }

        [StringLength(50)]
        public string houseFitment { get; set; }

        [StringLength(50)]
        public string houseOrt { get; set; }

        [StringLength(50)]
        public string buildType { get; set; }

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

        [StringLength(50)]
        public string web { get; set; }

        public string modelID { get; set; }

        [StringLength(500)]
        public string modelTitle { get; set; }

        [StringLength(50)]
        public string houseProportion { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(50)]
        public string ManagerName { get; set; }

        [StringLength(50)]
        public string ManagerType { get; set; }

        [StringLength(50)]
        public string ManagerPrice { get; set; }

        [StringLength(50)]
        public string CarNum { get; set; }

        [StringLength(50)]
        public string CarPrice { get; set; }

        [StringLength(50)]
        public string SellHouseNum { get; set; }

        [StringLength(50)]
        public string Rentingnum { get; set; }

        [StringLength(500)]
        public string EstatePriceTrent { get; set; }

        [StringLength(50)]
        public string EstateAdress { get; set; }

        public string EstateLocal { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string HouseTotal { get; set; }

        [StringLength(50)]
        public string EstateAge { get; set; }

        [StringLength(50)]
        public string EstatePlot { get; set; }

        [StringLength(50)]
        public string EstateName { get; set; }

        [StringLength(50)]
        public string EstateDevelopers { get; set; }

        [StringLength(50)]
        public string EstateArea { get; set; }

        [StringLength(50)]
        public string EstateGreen { get; set; }

        [StringLength(200)]
        public string EstateAvgPrice { get; set; }

        [StringLength(200)]
        public string Feature { get; set; }

        [StringLength(200)]
        public string Compare { get; set; }

        [StringLength(200)]
        public string SpaceArea { get; set; }

        [StringLength(200)]
        public string BuildArea { get; set; }

        [StringLength(4000)]
        public string HouseDes { get; set; }

        public string PriceType { get; set; }

        public string RentType { get; set; }

        public string HouseDeploy { get; set; }

        public string EstateSize { get; set; }

        public string FirstPayment { get; set; }

        public string MonthPayment { get; set; }

        public string Apartments { get; set; }

        public string BuildStructure { get; set; }

        public string Property { get; set; }

        public string District { get; set; }
    }
}
