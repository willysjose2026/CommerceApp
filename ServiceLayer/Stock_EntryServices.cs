using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;
using EntityLayer.DTO;

namespace ServiceLayer
{
    public class Stock_EntryServices
    {
        private Stock_EntryData _stockEntry_Data;
        private StockServices _stockServices;

        public Stock_EntryServices()
        {
            _stockEntry_Data = new Stock_EntryData();
            _stockServices = new StockServices();
        }

        public void Delete(STOCK_ENTRY variable)
        {
            _stockEntry_Data.Delete(variable);
        }

        public List<STOCK_ENTRY> Get()
        {
            return _stockEntry_Data.Get();
        }

        public void Insert(STOCK_ENTRY variable)
        {
            var stockList = _stockServices.Get();
            foreach(var stock in stockList)
            {
                if (stock.PRODUCT_ID == variable.PRODUCT_ID)
                {
                    stock.QUANTITY += variable.QUANTITY;
                    _stockServices.Update(stock);
                }
            }

            _stockEntry_Data.Insert(variable);
        }

        public STOCK_ENTRY Search(int Id)
        {
            return _stockEntry_Data.Search(Id);
        }

        public void Update(STOCK_ENTRY variable)
        {
            _stockEntry_Data.Update(variable);
        }

        public List<GetStockEntryData_Result> getStockEntryData()
        {
            return _stockEntry_Data.getStockEntryData();
        }

        public List<Stock_EntryDTO> FilterByProduct(string product)
        {
            IEnumerable<Stock_EntryDTO> filteredEntry =
                AutoMapper.Mapper.Map<IEnumerable<GetStockEntryData_Result>, IEnumerable<Stock_EntryDTO>>
                (_stockEntry_Data.FilterByProduct(product));
            return (List<Stock_EntryDTO>)filteredEntry;
        }

        public List<Stock_EntryDTO> FilterBySupplier(string supplierName)
        {
            IEnumerable<Stock_EntryDTO> filteredEntry =
                AutoMapper.Mapper.Map<IEnumerable<GetStockEntryData_Result>, IEnumerable<Stock_EntryDTO>>
                (_stockEntry_Data.FilterBySupplier(supplierName));
            return (List<Stock_EntryDTO>)filteredEntry;
        }

        public List<Stock_EntryDTO> FilterByDate(DateTime entryDate)
        {
            IEnumerable<Stock_EntryDTO> filteredEntry =
                AutoMapper.Mapper.Map<IEnumerable<GetStockEntryData_Result>, IEnumerable<Stock_EntryDTO>>
                (_stockEntry_Data.FilterByDate(entryDate));
            return (List<Stock_EntryDTO>)filteredEntry;
        }
    }
}
