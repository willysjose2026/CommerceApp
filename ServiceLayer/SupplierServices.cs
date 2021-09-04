using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace ServiceLayer
{
    public class SupplierServices : IServices<SUPPLIER>
    {
        SupplierData _supplierData;

        public SupplierServices()
        {
            _supplierData = new SupplierData();
        }

        public void Delete(SUPPLIER variable)
        {
            _supplierData.Delete(variable);
        }

        public List<SUPPLIER> Get()
        {
            return _supplierData.Get();
        }

        public void Insert(SUPPLIER variable)
        {
            _supplierData.Insert(variable);
        }

        public SUPPLIER Search(int Id)
        {
            return _supplierData.Search(Id);
        }

        public void Update(SUPPLIER variable)
        {
            _supplierData.Update(variable);
        }
    }
}
