using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityLayer;
using ServiceLayer;

namespace PresentationLayer.Controllers
{
    public class SuppliersController : Controller
    {

        private SupplierServices _supplierServices;
        
        public SuppliersController()
        {
            _supplierServices = new SupplierServices();
        }
        // GET: SUPPLIERS
        public ActionResult Index()
        {
            return View(_supplierServices.Get());
        }

        // GET: SUPPLIERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUPPLIERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SUPPLIER supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierServices.Insert(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: SUPPLIERS/Edit/5
        public ActionResult Edit(int id)
        {

            var selectedSupplier = _supplierServices.Search(id);
            if (selectedSupplier == null)
            {
                return HttpNotFound();
            }
            return View(selectedSupplier);
        }

        // POST: SUPPLIERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SUPPLIER supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierServices.Update(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: SUPPLIERS/Delete/5
        public ActionResult Delete(int id)
        {

            var selectedSupplier = _supplierServices.Search(id);
            if (selectedSupplier == null)
            {
                return HttpNotFound();
            }
            return View(selectedSupplier);
        }

        // POST: SUPPLIERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var selectedSupplier = _supplierServices.Search(id);
            _supplierServices.Delete(selectedSupplier);
            return RedirectToAction("Index");
        }

    }
}
