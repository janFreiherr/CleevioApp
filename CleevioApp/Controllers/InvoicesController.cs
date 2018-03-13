using AutoMapper;
using CleevioApp.Filters;
using CleevioApp.Models;
using CleevioApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace CleevioApp.Controllers
{
    public class InvoicesController : BaseAPIController
    {
        public InvoicesController(IInvoiceRepository repository) : base(repository)
        {
        }

        [InvoicesAuthorizeAttribute]
        public HttpResponseMessage Get(bool paid = false)
        {
            if (!Thread.CurrentPrincipal.Identity.Name.Equals("admin"))
            {
                Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            var invoices = TheRepository
                .GetInvoices()
                .Where(i => i.PaymentStatus == paid);

            var result = Mapper.Map<IEnumerable<InvoiceWithProductsDto>>(invoices);

            foreach (var invoice in result)
            {
                invoice.Products = TheRepository.GetProductsForInvoice(invoice.InvoiceId);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPatch]
        [InvoicesAuthorizeAttribute]
        public HttpResponseMessage Patch(int id, [FromBody] Invoice changedInvoice)
        {

            if (changedInvoice == null) return Request.CreateResponse(HttpStatusCode.NotFound);

            var invoice = TheRepository.GetInvoice(id);

            if (changedInvoice.ClientName != null)
            {
                invoice.ClientName = changedInvoice.ClientName;
            }

            if (changedInvoice.Address != null)
            {
                invoice.Address = changedInvoice.Address;
            }

            if (invoice.PaymentStatus != changedInvoice.PaymentStatus)
            {
                invoice.PaymentStatus = changedInvoice.PaymentStatus;
            }

            TheRepository.EditInvoice(invoice);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
