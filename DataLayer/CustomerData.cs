using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class CustomerData : IData<CUSTOMER>
    {
        private FacturacionDBEntities db;
        public CustomerData()
        {
            db = FacturacionDBEntities.getInstance();
        }
        public void Insert(CUSTOMER customer)
        {
            db.CUSTOMERS.Add(customer);
            db.SaveChanges();
        }
        
        public List<CUSTOMER> Get()
        {
            return db.CUSTOMERS.ToList();
        }

        public void Update(CUSTOMER customer)
        {
            var selectedCustomer = db.CUSTOMERS.Find(customer.Id);
            selectedCustomer.Id = customer.Id;
            selectedCustomer.RNC_ID_NUMBER = customer.RNC_ID_NUMBER;
            selectedCustomer.CUSTOMER_NAME = customer.CUSTOMER_NAME;
            selectedCustomer.PHONE_NUMBER = customer.PHONE_NUMBER;
            selectedCustomer.EMAIL = customer.EMAIL;
            selectedCustomer.CATEGORY = customer.CATEGORY;

            db.Entry(selectedCustomer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(CUSTOMER customer)
        {
            var selectedCustomer = db.CUSTOMERS.Find(customer.Id);
            db.CUSTOMERS.Remove(selectedCustomer);
            db.SaveChanges();
        }

        public CUSTOMER Search(int? id)
        {
            return db.CUSTOMERS.Find(id);
        }
    }
}
