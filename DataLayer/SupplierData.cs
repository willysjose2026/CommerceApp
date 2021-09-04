using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class SupplierData : IData<SUPPLIER>
    {

        private FacturacionDBEntities db;

        public SupplierData()
        {
            db = FacturacionDBEntities.getInstance();
        }
        public void Delete(SUPPLIER variable)
        {
            var selectedSupplier = db.SUPPLIERS.Find(variable.Id);
            db.SUPPLIERS.Remove(selectedSupplier);
            db.SaveChanges();

        }

        public List<SUPPLIER> Get()
        {
            return db.SUPPLIERS.ToList();
        }

        public void Insert(SUPPLIER variable)
        {
            db.SUPPLIERS.Add(variable);
            db.SaveChanges();
        }

        public SUPPLIER Search(int? id)
        {
            return db.SUPPLIERS.Find(id);
        }

        public void Update(SUPPLIER variable)
        {
            var selectedSupplier = Search(variable.Id);
            selectedSupplier.RNC_ID_NUMBER = variable.RNC_ID_NUMBER;
            selectedSupplier.SUPPLIER_NAME = variable.SUPPLIER_NAME;
            selectedSupplier.PHONE_NUMBER = variable.PHONE_NUMBER;
            selectedSupplier.EMAIL = variable.EMAIL;

            db.Entry(selectedSupplier).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
