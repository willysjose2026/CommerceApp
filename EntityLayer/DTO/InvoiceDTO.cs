using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int customerId { get; set; }
        public DateTime invoiceDate { get; set; }
        public decimal invoiceTotal { get; set; }
        public decimal Discount { get; set;}
        public IEnumerable<InvoiceItemsDTO> ListInvoiceItems { get; set; }
    }
}
