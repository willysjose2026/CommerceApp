using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Repositories
{
    public class CustomerRepository
    {
        CustomerServices customerServices;
        public CustomerRepository()
        {
            customerServices = new CustomerServices();
        }

        public IEnumerable<SelectListItem> getAllCustomers()
        {
            var customerList = new List<SelectListItem>();
            return customerList;
        }
    }
}
