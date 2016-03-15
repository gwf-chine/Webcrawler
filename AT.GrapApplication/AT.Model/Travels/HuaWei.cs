namespace Service.Model.Travels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HuaWei")]
    public partial class HuaWei
    {
        public Guid ID { get; set; }

        public string pro_title { get; set; }

        public string pro_subTitle { get; set; }

        public string pro_price { get; set; }

        public string pro_coding { get; set; }

        public string pro_detail { get; set; }

        public string pro_comment { get; set; }
    }
}
