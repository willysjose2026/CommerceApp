using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;


namespace DataLayer
{
    public class StockData : IData<STOCK>
    {
        private FacturacionDBEntities db;
        private STOCK stockReg;
        public StockData()
        {
            db = FacturacionDBEntities.getInstance();
            stockReg = null;
        }

        public List<GetStockData_Result> getStockData()
        {
            return db.GetStockData().ToList();
        }

        public void Delete(STOCK variable)
        {
            stockReg = db.STOCKs.Find(variable.Id);
            db.STOCKs.Remove(stockReg);
            db.SaveChanges();
        }

        public List<STOCK> Get()
        {
            return db.STOCKs.ToList();
        }

        public void Insert(STOCK variable)
        {
            db.STOCKs.Add(variable);
            db.SaveChanges();
        }

        public STOCK Search(int? id)
        {
            return db.STOCKs.Find(id);
        }

        public void Update(STOCK variable)
        {
            stockReg = db.STOCKs.Find(variable.Id);
            stockReg.PRODUCT_ID = variable.PRODUCT_ID;
            stockReg.QUANTITY = variable.QUANTITY;

            db.Entry(stockReg).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
