using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CleevioApp.Models;
using CleevioApp.Services;

namespace CleevioApp.Controllers
{
    public class DetailsController : Controller
    {
        private IInvoiceRepository _invoiceRepository;

        public DetailsController()
        {
            _invoiceRepository = new InvoiceRepository(new CleevioDBContext());
        }

        public DetailsController(IInvoiceRepository repository)
        {
            _invoiceRepository = repository;
        }

        // GET: Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Invoice invoice = _invoiceRepository.GetInvoiceById(id.GetValueOrDefault());

            var poductsForInvoice = _invoiceRepository.GetProductsForInvoice(invoice);

            var model = Mapper.Map<InvoiceWithProductsDto>(invoice);
            model.Products = poductsForInvoice;

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Details/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductForAddDto productForAdd)
        {
            if (ModelState.IsValid)
            {
                _invoiceRepository.AddProductToInvoice(productForAdd.InvoiceId,
                                                        productForAdd.ProductId,
                                                    productForAdd.Quantity);

                return RedirectToAction("Details", "Details", new { id = productForAdd.InvoiceId });
            }

            return View(productForAdd);
        }

        // GET: Details/Add/5
        public ActionResult Add(int? id)
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
            var allProducts = _invoiceRepository.GetProducts();

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var product in allProducts)
            {
                items.Add(new SelectListItem()
                {
                    Text = product.Name,
                    Value = product.ProductId.ToString()
                });
            }   

            var addModel = new ProductForAddDto()
            {
                InvoiceId = id.GetValueOrDefault(),
                ProductsList = items                                 
            };
            return View(addModel);
        }

        //GET: Details/Delete/5
        public ActionResult Delete(int? id, int invoiceId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var invoice = _invoiceRepository.GetInvoiceById(invoiceId);
            
            Product productToDelete = _invoiceRepository.GetProductFromInvoice(invoice, id.GetValueOrDefault());

            var model = Mapper.Map<ProductForDeleteDto>(productToDelete);
            model.InvoiceId = invoiceId;
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ProductForDeleteDto product)
        {
            _invoiceRepository.RemoveProductFromInvoice(product.InvoiceId, product.ProductId);
            return RedirectToAction("Details", "Details", new { id = product.InvoiceId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _invoiceRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
