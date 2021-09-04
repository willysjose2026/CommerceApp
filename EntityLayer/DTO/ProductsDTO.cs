using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class ProductsDTO
    {
        
        public int Id { get; set; }
        [DisplayName ("Producto")]
        public string productName { get; set; }
        [DisplayName("Precio Unitario")]
        public decimal unitPrice { get; set; }
        [DisplayName("Unidad")]
        public string unitMeasurement { get; set; }
    }
}
