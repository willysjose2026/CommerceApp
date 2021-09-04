using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace DataLayer
{
    public class InvoiceData : IData<INVOICE>
    {
        private FacturacionDBEntities db;
        private INVOICE _invoice;

        public InvoiceData()
        {
            db = FacturacionDBEntities.getInstance();
            _invoice = null;
        }
        public void Delete(INVOICE variable)
        {
            _invoice = db.INVOICES.Find(variable.Id);
            db.INVOICES.Remove(_invoice);
            db.SaveChanges();
        }

        public List<INVOICE> Get()
        {
            return db.INVOICES.ToList();
        }

        public void Insert(INVOICE variable)
        {
            db.INVOICES.Add(variable);
            db.SaveChanges();
        }

        public INVOICE Search(int? id)
        {
            return db.INVOICES.Find(id);
        }

        public void Update(INVOICE variable)
        {
            _invoice = db.INVOICES.Find(variable.Id);
            _invoice.CUSTOMER_ID = variable.CUSTOMER_ID;
            _invoice.INVOICE_TOTAL = variable.INVOICE_TOTAL;
            _invoice.INVOICE_DATE = variable.INVOICE_DATE;

            db.Entry(_invoice).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
