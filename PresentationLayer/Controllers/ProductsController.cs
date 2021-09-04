using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using ServiceLayer;

namespace PresentationLayer.Controllers
{
    public class ProductsController : Controller
    {

        private ProductsServices _productServices = null;

        public ProductsController()
        {
            _productServices = new ProductsServices();
        }

        // GET: Products
        public ActionResult Index()
        {

            return View(_productServices.Get());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(PRODUCT product)
        {
            try
            {

                _productServices.Insert(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            
            PRODUCT selectedProduct = _productServices.Search(id);
            if(selectedProduct == null)
            {
                return HttpNotFound();
            }
            return View(selectedProduct);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(PRODUCT product)
        {
            if (ModelState.IsValid)
            {
                _productServices.Update(product);
                return RedirectToAction("Index");

            }
            return View(product);
            
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            PRODUCT selectedProduct = _productServices.Search(id);
            if (selectedProduct == null)
            {
                return HttpNotFound();
            }
            return View(selectedProduct);   
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(PRODUCT product)
        {
            try
            {
                _productServices.Delete(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }
    }
}
