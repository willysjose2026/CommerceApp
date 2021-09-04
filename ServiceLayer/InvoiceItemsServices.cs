using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace ServiceLayer
{
    public class InvoiceItemsServices : IServices<INVOICE_ITEMS>
    {
        private Invoice_ItemData _invoice_ItemData;
        private StockData stockData;

        public InvoiceItemsServices()
        {
            _invoice_ItemData = new Invoice_ItemData();
            stockData = new StockData();
        }

        public void Delete(INVOICE_ITEMS variable)
        {
            _invoice_ItemData.Delete(variable);
        }

        public List<INVOICE_ITEMS> Get()
        {
            return _invoice_ItemData.Get();
        }

        public List<GetSales_Result> getInvoiceItems()
        {
            return _invoice_ItemData.getInvoiceItems();
        }

        public void Insert(INVOICE_ITEMS variable)
        {
            var stockItem = stockData.Get().Single(a => a.PRODUCT_ID == variable.PRODUCT_ID);
            stockItem.QUANTITY -= variable.QUANTITY;
            _invoice_ItemData.Insert(variable);
            stockData.Update(stockItem);
        }

        public INVOICE_ITEMS Search(int Id)
        {
            return _invoice_ItemData.Search(Id);
        }

        public void Update(INVOICE_ITEMS variable)
        {
            _invoice_ItemData.Update(variable);
        }
    }
}
