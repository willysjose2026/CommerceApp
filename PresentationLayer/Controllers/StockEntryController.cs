using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer;
using EntityLayer;
using EntityLayer.DTO;

namespace PresentationLayer.Controllers
{
    public class StockEntryController : Controller
    {

        private Stock_EntryServices _EntryServices;
        private ProductsServices productsServices;
        private SupplierServices supplierServices;
        public StockEntryController()
        {
            _EntryServices = new Stock_EntryServices();
            productsServices = new ProductsServices();
            supplierServices = new SupplierServices();
        }
        // GET: StockEntry

        public ActionResult Index()
        {
            
            return View();


        }

        [HttpPost]
        public ActionResult LoadData()
        {
            IEnumerable<Stock_EntryDTO> data =
                AutoMapper.Mapper.Map<IEnumerable<GetStockEntryData_Result>, IEnumerable<Stock_EntryDTO>>
                (_EntryServices.getStockEntryData());


            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var productName = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            var supplier = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            var entryDate = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();

            if (!string.IsNullOrEmpty(productName))
            {
                data = _EntryServices.FilterByProduct(productName);
            }
            if (!string.IsNullOrEmpty(supplier))
            {
                data = _EntryServices.FilterBySupplier(supplier);
            }
            if (!string.IsNullOrEmpty(entryDate))
            {
                data = _EntryServices.FilterByDate(DateTime.Parse(entryDate));
            }

            var counter = data.Count();
            var jsonFile = new
            {
                draw = draw,
                data = data,
                records = counter
            };

            return Json(jsonFile, JsonRequestBehavior.AllowGet);
        }

        // GET: StockEntry/Create
        public ActionResult Create()
        {
            var products = productsServices.Get();
            var suppliers = supplierServices.Get();
            List<SelectListItem> productList = products.ConvertAll(d =>
                    {
                        return new SelectListItem
                        {
                            Text = d.PRODUCT_NAME,
                            Value = d.Id.ToString(),
                            Selected = false
                        };
                    }
                );

            List<SelectListItem> supplierList = suppliers.ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.SUPPLIER_NAME,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            }
                );

            ViewBag.products = productList;
            ViewBag.suppliers = supplierList;

            return View();
        }

        // POST: StockEntry/Create
        [HttpPost]
        public ActionResult Create(Stock_EntryDTO _EntryDTO)
        {
            try
            {

                var stockEntry = new STOCK_ENTRY();
                AutoMapper.Mapper.Map(_EntryDTO, stockEntry);
                stockEntry.PRODUCT_ID = int.Parse(Request.Form["products"]);
                stockEntry.SUPPLIER_ID = int.Parse(Request.Form["suppliers"]);
                _EntryServices.Insert(stockEntry);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockEntry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockEntry/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StockEntry/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockEntry/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
