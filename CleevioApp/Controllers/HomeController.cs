using CleevioApp.Models;
using CleevioApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CleevioApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() { }
        public HomeController(IInvoiceRepository repository) : base(repository)
        {

        }

        public ActionResult Index()
        {
            var invoices = TheRepository.GetInvoices();
            
            return View(invoices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice)
        {
            invoice.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                TheRepository.AddInvoice(invoice);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = TheRepository.GetInvoice(id.GetValueOrDefault());
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice = TheRepository.EditInvoice(invoice);
                return RedirectToAction("Index");
            }
            return View(invoice);
        }
    }
}