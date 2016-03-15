using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antuo.Model
{
    [Serializable]
    [Table("HuaWei")]
    public partial class HuaWei
    {
        [Key]
        public Guid ID { get; set; }
        public string pro_title { get; set; }
        public string pro_subTitle { get; set; }

         public string pro_price { get; set; }

        public string pro_coding { get; set; }
        
        public string pro_detail { get; set; }
        
        public string pro_comment { get; set; }
    }

    [Serializable]
    public class HuaWeiConfig
    {
        public HuaWeiConfig()
        {
            this.xmlPath = @"XmlConfig/HWConfig.xml";
        }
        public string _pro_title { get; set; }
        public string _pro_subTitle { get; set; }

        public string _pro_price { get; set; }

        public string _pro_coding { get; set; }

        public string _pro_detail { get; set; }

        public string _pro_comment { get; set; }

        public string xmlPath { get; }
    }
}
