using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace DataLayer
{
    public class Stock_EntryData : IData<STOCK_ENTRY>
    {
        private FacturacionDBEntities db;
        private STOCK_ENTRY _stockEntry;

        public Stock_EntryData()
        {
            db = FacturacionDBEntities.getInstance();
            _stockEntry = null;
        }

        public void Delete(STOCK_ENTRY variable)
        {
            _stockEntry = db.STOCK_ENTRY.Find(variable.Id);
            db.STOCK_ENTRY.Remove(_stockEntry);
            db.SaveChanges();
        }

        public List<STOCK_ENTRY> Get()
        {
            return db.STOCK_ENTRY.ToList();
        }

        public void Insert(STOCK_ENTRY variable)
        {
            db.STOCK_ENTRY.Add(variable);
            db.SaveChanges();
        }

        public STOCK_ENTRY Search(int? id)
        {
            return db.STOCK_ENTRY.Find(id);
        }

        public void Update(STOCK_ENTRY variable)
        {
            _stockEntry = db.STOCK_ENTRY.Find(variable.Id);
            _stockEntry.PRODUCT_ID = variable.PRODUCT_ID;
            _stockEntry.SUPPLIER_ID = variable.SUPPLIER_ID;
            _stockEntry.QUANTITY = variable.QUANTITY;
            _stockEntry.ENTRY_DATE = variable.ENTRY_DATE;

            db.Entry(_stockEntry).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        #region store procedures
        public List<GetStockEntryData_Result> getStockEntryData()
        {
            return db.GetStockEntryData().ToList();
        }

        public List<GetStockEntryData_Result> FilterByProduct(string productName)
        {
            return getStockEntryData().Where(a => a.PRODUCT_NAME.Contains(productName)).ToList();
        }

        public List<GetStockEntryData_Result> FilterBySupplier(string supplierName)
        {
            return getStockEntryData().Where(a => a.SUPPLIER_NAME.Contains(supplierName)).ToList();
        }

        public List<GetStockEntryData_Result> FilterByDate(DateTime entryDate)
        {
            return getStockEntryData().Where(a => a.ENTRY_DATE == entryDate).ToList();
        }
        #endregion
    }
}
