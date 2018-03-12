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
    public class HomeController : Controller
    {
        private IInvoiceRepository _invoiceRepository;


        public HomeController()
        {
            _invoiceRepository = new InvoiceRepository(new CleevioDBContext());
        }

        public HomeController(IInvoiceRepository repository)
        {
            _invoiceRepository = repository;
        }

        public ActionResult Index()
        {
            var invoices = _invoiceRepository.GetInvoices();
            
            return View(invoices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice)
        {
            invoice.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                _invoiceRepository.AddInvoice(invoice);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // GET: /Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = _invoiceRepository.GetInvoiceById(id.GetValueOrDefault());
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: /Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice =_invoiceRepository.EditInvoice(invoice);
                return RedirectToAction("Index");
            }
            return View(invoice);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            _invoiceRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}