using CleevioApp.Models;
using CleevioApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CleevioApp.Controllers
{
    public abstract class BaseController : Controller
    {

        private IInvoiceRepository _invoiceRepository;

        public BaseController()
        {
            _invoiceRepository = new InvoiceRepository(new CleevioDBContext());
        }


        public BaseController(IInvoiceRepository repository)
        {
            _invoiceRepository = repository;
        }

        protected IInvoiceRepository TheRepository
        {
            get
            {
                return _invoiceRepository;
            }
        }
    }
}
