using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer.DTO;
using EntityLayer;

namespace ServiceLayer
{
    public class InvoiceServices
    {
        private InvoiceData _invoiceData;
        private InvoiceItemsServices _invoiceItemServices;

        public InvoiceServices()
        {
            _invoiceData = new InvoiceData();
            _invoiceItemServices = new InvoiceItemsServices();
        }

        public void Delete(INVOICE variable)
        {
            _invoiceData.Delete(variable);
        }

        public List<INVOICE> Get()
        {
            return _invoiceData.Get();
        }

        public void Insert(InvoiceDTO invoiceDTO)
        {
            var invoice = new INVOICE();

            AutoMapper.Mapper.Map(invoiceDTO, invoice);
            _invoiceData.Insert(invoice);

            foreach(var item in invoiceDTO.ListInvoiceItems)
            {
                var invoiceItem = new INVOICE_ITEMS();
                AutoMapper.Mapper.Map(item, invoiceItem);
                invoiceItem.INVOICE_ID = invoice.Id;
                _invoiceItemServices.Insert(invoiceItem);
            }

        }

        public INVOICE Search(int Id)
        {
            return _invoiceData.Search(Id);
        }

        public void Update(INVOICE variable)
        {
            _invoiceData.Update(variable);
        }
    }
}
