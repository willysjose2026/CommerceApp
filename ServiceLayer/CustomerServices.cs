using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace ServiceLayer
{
    public class CustomerServices : IServices<CUSTOMER>
    {
        CustomerData _customerData = new CustomerData();
        
        public bool isPremium(int Id)
        {
            if (_customerData.Search(Id).CATEGORY == "PREMIUM")
            {
                return true;
            }
            return false;
        }
        public void Insert(CUSTOMER customer)
        {
            _customerData.Insert(customer);
        }
        
        public List<CUSTOMER> Get()
        {
            return _customerData.Get();
        }

        public void Update(CUSTOMER customer)
        {
            _customerData.Update(customer);
        }

        public void Delete (CUSTOMER customer)
        {
            _customerData.Delete(customer);
        }

        public CUSTOMER Search(int id)
        {
            return _customerData.Search(id);
        }
    }
}
