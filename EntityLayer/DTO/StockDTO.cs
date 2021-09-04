using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class StockDTO
    {
        public int PRODUCT_ID { get; set; }
        
        [DisplayName("PRODUCTO")]
        public string PRODUCT_NAME { get; set; }
        [DisplayName("PRECIO X UNIDAD")]
        public float UNIT_PRICE { get; set; }
        [DisplayName("CANTIDAD EXISTENTE")]
        public int QUANTITY { get; set; }
    }
}
