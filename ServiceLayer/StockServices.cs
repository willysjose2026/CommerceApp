using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataLayer;

namespace ServiceLayer
{
    public class StockServices : IServices<STOCK>
    {
        private StockData _stockData;

        public StockServices()
        {
            _stockData = new StockData();
        }

        public List<GetStockData_Result> getStockData()
        {
            return _stockData.getStockData();
        }

        public void Delete(STOCK variable)
        {
            _stockData.Delete(variable);
        }

        public List<STOCK> Get()
        {
            return _stockData.Get();
        }

        public void Insert(STOCK variable)
        {
            _stockData.Insert(variable);
        }

        public STOCK Search(int Id)
        {
            return _stockData.Search(Id);
        }

        public void Update(STOCK variable)
        {
            _stockData.Update(variable);
        }
    }
}
