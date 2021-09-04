using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        
        [Required]
        [DisplayName ("RNC o Cedula")]
        public  string RNC_ID { get; set; }
        
        [Required]
        [DisplayName("Nombre del Cliente")]
        public string customerName { get; set; }
        
        [DisplayName("Numero Telefonico")]
        public string phoneNumber { get; set; }
        
        [Required]
        [DisplayName("Correo Electronico")]
        public string email{ get; set; }
        
        [Required]
        [DisplayName("Categoria")]
        public string Category { get; set; }
    }
}
