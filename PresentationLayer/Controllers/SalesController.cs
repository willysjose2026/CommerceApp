using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using ServiceLayer;
using EntityLayer.DTO;

namespace PresentationLayer.Controllers
{
    public class SalesController : Controller
    {
        #region variables
        private readonly CustomerServices customerServices;
        private readonly ProductsServices productServices;
        private readonly StockServices stockServices;
        private readonly InvoiceServices invoiceServices;
        #endregion


        public SalesController()
        {
            stockServices = new StockServices();
            customerServices = new CustomerServices();
            productServices = new ProductsServices();
            invoiceServices = new InvoiceServices();
        }
        // GET: Sales
        public ActionResult Index()
        {
            List<SelectListItem> customerList = customerServices.Get().ConvertAll( d =>
            {
                return new SelectListItem
                {
                    Text = d.CUSTOMER_NAME,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            }).ToList();

            List<SelectListItem> productList = productServices.Get().ConvertAll(d =>
            {
                return new SelectListItem
                {
                    Text = d.PRODUCT_NAME,
                    Value = d.Id.ToString(),
                    Selected = false
                };
            }).ToList();

            var model = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(customerList, productList);

            return View(model);
        }

        [HttpPost]
        public JsonResult Index(InvoiceDTO Invoice)
        {
            invoiceServices.Insert(Invoice);   
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUnitPrice(int productId)
        {
            var unitPrice = productServices.Search(productId).UNIT_PRICE;   
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSuscriptionType(int customerId)
        {
            var customerSubscription = customerServices.Search(customerId).CATEGORY;
            return Json(customerSubscription, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUnitMeasure(int productId)
        {
            var unitMeasure = productServices.Search(productId).UNIT_MEASUREMENT;
            return Json(unitMeasure, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetStockAvailability(int productId)
        {
            var quantity = stockServices.Get().Single(a => a.PRODUCT_ID == productId).QUANTITY;
            return Json(quantity, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public JsonResult GetDiscount(int customerId, decimal price)
        {
            if (customerServices.isPremium(customerId))
            {
                var discountPrice = Calculations.calculateDiscount(price);
                return Json(discountPrice, JsonRequestBehavior.AllowGet);
            }

            return Json(price, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetItbis(decimal totalBT)
        {
            var total = new
            {
                ITBIS = Calculations.getITBIS(totalBT),
                Total = Calculations.addITBIS(totalBT)
            };
            return Json(total, JsonRequestBehavior.AllowGet);
        }
    }
}