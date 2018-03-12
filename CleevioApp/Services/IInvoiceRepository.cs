using CleevioApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleevioApp.Services
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoices();
        IEnumerable<Product> GetProducts();
        Invoice GetInvoiceById(int id);
        IEnumerable<ProductWithQuantityDto> GetProductsForInvoice(Invoice invoice);
        void AddInvoice(Invoice invoice);
        Invoice EditInvoice(Invoice invoice);
        void AddProductToInvoice(int invoice, int product, int quantity);
        Product GetProductFromInvoice(Invoice invoice, int productId);
        void RemoveProductFromInvoice(int invoiceId, int productId);
        void Dispose();
        bool Save();
    }
}