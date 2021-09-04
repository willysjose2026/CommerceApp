using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class Invoice_ItemData : IData<INVOICE_ITEMS>
    {
        private FacturacionDBEntities db;
        private INVOICE_ITEMS _invoice_item;

        public Invoice_ItemData()
        {
            db = FacturacionDBEntities.getInstance();
            _invoice_item = null;
        }

        public List<GetSales_Result> getInvoiceItems()
        {
            return db.GetSales().ToList();
        }


        public void Delete(INVOICE_ITEMS variable)
        {
            _invoice_item = db.INVOICE_ITEMS.Find(variable.Id);
            db.INVOICE_ITEMS.Remove(_invoice_item);
            db.SaveChanges();
        }

        public List<INVOICE_ITEMS> Get()
        {
            return db.INVOICE_ITEMS.ToList();
        }

        public void Insert(INVOICE_ITEMS variable)
        {
            db.INVOICE_ITEMS.Add(variable);
            db.SaveChanges();
        }

        public INVOICE_ITEMS Search(int? id)
        {
            return db.INVOICE_ITEMS.Find(id);
        }

        public void Update(INVOICE_ITEMS variable)
        {
            _invoice_item = db.INVOICE_ITEMS.Find(variable.Id);
            _invoice_item.INVOICE_ID = variable.INVOICE_ID;
            _invoice_item.PRODUCT_ID = variable.PRODUCT_ID;
            _invoice_item.QUANTITY = variable.QUANTITY;
            _invoice_item.TOTAL_PRICE = variable.TOTAL_PRICE;

            db.Entry(_invoice_item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
