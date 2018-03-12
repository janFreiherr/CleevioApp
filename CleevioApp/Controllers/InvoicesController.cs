using AutoMapper;
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
    public class InvoicesController : ApiController
    {
        IInvoiceRepository _invoiceRepository;


        public InvoicesController()
        {
            _invoiceRepository = new InvoiceRepository(new CleevioDBContext());
        }

        public IEnumerable<InvoiceWithProductsDto> Get()
        {
            var invoices = _invoiceRepository.GetInvoices();

            var result = Mapper.Map<IEnumerable<InvoiceWithProductsDto>>(invoices);

            foreach (var invoice in result)
            {
                invoice.Products = _invoiceRepository.GetProductsForInvoice(invoice);
            }

            return result;
        }
    }
}
