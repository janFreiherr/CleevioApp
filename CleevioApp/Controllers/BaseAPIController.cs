using CleevioApp.Models;
using CleevioApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CleevioApp.Controllers
{
    public abstract class BaseAPIController : ApiController
    {
        private IInvoiceRepository _invoiceRepository;


        public BaseAPIController(IInvoiceRepository repository)
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
