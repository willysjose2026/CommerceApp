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
    public class CustomersController : Controller
    {
        IServices<CUSTOMER> _customerService = null;
        public CustomersController()
        {
            _customerService = new CustomerServices();
        }
        
        // GET: Customers
        public ActionResult Index()
        {
            return View(_customerService.Get());
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CUSTOMER cUSTOMER)
        {

            if (ModelState.IsValid)
            {
                _customerService.Insert(cUSTOMER);
                return RedirectToAction("Index");
            }

            return View(cUSTOMER);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            CUSTOMER cUSTOMER = _customerService.Search(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                _customerService.Update(cUSTOMER);
                return RedirectToAction("Index");
            }
            return View(cUSTOMER);   
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            CUSTOMER cUSTOMER = _customerService.Search(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER cUSTOMER = _customerService.Search(id);
            _customerService.Delete(cUSTOMER);
            return RedirectToAction("Index");            
        }
    }
}
