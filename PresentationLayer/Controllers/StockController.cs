using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EntityLayer;
using EntityLayer.DTO;
using ServiceLayer;

namespace PresentationLayer.Controllers
{
    public class StockController : Controller
    {
        private StockServices _stockServices;
        public StockController()
        {
            _stockServices = new StockServices();
        }

        // GET: Stock
        public ActionResult Index()
        {
            IEnumerable<StockDTO> stockDTO = 
            Mapper.Map<IEnumerable<GetStockData_Result>, IEnumerable<StockDTO>>(_stockServices.getStockData()); 
            return View(stockDTO);
        }

        // REDIRECT: StockEntry/Create
        public ActionResult Create()
        {
            return RedirectToAction("../StockEntry/Create");
        }
    }
}
