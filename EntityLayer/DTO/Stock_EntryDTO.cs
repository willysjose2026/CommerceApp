using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class Stock_EntryDTO
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName ("PRODUCTO")]
        public string PRODUCT_NAME { get; set; }
        [DisplayName("PRECIO X UNIDAD")]
        public float UNIT_PRICE { get; set; }
        [Required]
        [DisplayName("SUPLIDOR")]
        public string SUPPLIER_NAME { get; set; }
        [Required]
        [DisplayName("CANTIDAD")]
        public int QUANTITY { get; set; }
        [DisplayName("FECHA DE ENTRADA")]
        public string ENTRY_DATE { get; set; }
    }
}
