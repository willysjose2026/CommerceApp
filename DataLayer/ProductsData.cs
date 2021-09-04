using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class ProductsData : IData<PRODUCT>
    {
        private FacturacionDBEntities db;

        public ProductsData()
        {
            db = FacturacionDBEntities.getInstance();
        }

        public void Delete(PRODUCT variable)
        {
            var selectedProduct = db.PRODUCTS.Find(variable.Id);
            db.PRODUCTS.Remove(selectedProduct);
            db.SaveChanges();
        }

        public List<PRODUCT> Get()
        {
            return db.PRODUCTS.ToList();
        }

        public void Insert(PRODUCT variable)
        {
            db.PRODUCTS.Add(variable);
            db.SaveChanges();
        }

        public PRODUCT Search(int? id)
        {
            using(var db = new FacturacionDBEntities())
            {
                return db.PRODUCTS.Find(id);
            }
        }

        public void Update(PRODUCT variable)
        {
            var selectedProduct = db.PRODUCTS.Find(variable.Id);
            selectedProduct.Id = variable.Id;
            selectedProduct.PRODUCT_NAME = variable.PRODUCT_NAME;
            selectedProduct.UNIT_PRICE = variable.UNIT_PRICE;
            selectedProduct.UNIT_MEASUREMENT = variable.UNIT_MEASUREMENT;
     
            db.Entry(selectedProduct).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
