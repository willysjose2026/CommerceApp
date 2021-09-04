using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataLayer;

namespace ServiceLayer
{
    public class ProductsServices : IServices<PRODUCT>
    {
        private ProductsData _productsData = null;

        public ProductsServices()
        {
            _productsData = new ProductsData();
        }

        public void Delete(PRODUCT variable)
        {
            _productsData.Delete(variable);
        }

        public List<PRODUCT> Get()
        {
            return _productsData.Get();
        }

        public void Insert(PRODUCT variable)
        {
            _productsData.Insert(variable);

            var stock = new STOCK()
            {
                PRODUCT_ID = variable.Id,
                QUANTITY = 0,
            };

            var stockData = new StockData();
            stockData.Insert(stock);
        }

        public PRODUCT Search(int Id)
        {
            return _productsData.Search(Id);
        }

        public void Update(PRODUCT variable)
        {
            _productsData.Update(variable);
        }
    }
}
