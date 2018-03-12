using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleevioApp.Models;

namespace CleevioApp.Services
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private CleevioDBContext _context;

        public InvoiceRepository(CleevioDBContext context)
        {
            _context = context;
        }
        public Invoice GetInvoiceById(int id)
        {
            return _context.Invoices.FirstOrDefault(i => i.InvoiceId == id);
        }

        public IEnumerable<ProductWithQuantityDto> GetProductsForInvoice(Invoice invoice)
        {
            var result = _context.Invoices
                                    .Where(i => i.InvoiceId == invoice.InvoiceId)
                                    .SelectMany(i => i.InvoiceProducts
                                        .Select(ip => new ProductWithQuantityDto() { ProductId = ip.ProductId,
                                                                                        Name = ip.Product.Name,
                                                                                        Price = ip.Product.Price * ip.Quantity,
                                                                                        Quantity = ip.Quantity
                                                                                    } )).ToList();
            return result;
        }


        public IEnumerable<Product> GetProducts()
        {
           return _context.Products.Distinct().ToList();
        }

        public IEnumerable<Invoice> GetInvoices()
        {
            return _context.Invoices.OrderByDescending(i => i.Date)
                            .ThenBy(i => i.ClientName);
        }

        public void AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public Invoice EditInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();
            return invoice;
        }

        public Product GetProductFromInvoice(Invoice invoice, int productId)
        {
            var result = _context.Invoices
                                  .Where(i => i.InvoiceId == invoice.InvoiceId)
                                  .SelectMany(i => i.InvoiceProducts
                                                .Select(ip => ip.Product))
                                  .Where(p => p.ProductId == productId)
                                  .SingleOrDefault();
            return result;
        }

        public void AddProductToInvoice(int invoiceId, int productId, int quantity)
        {
            var targetedInvoice = _context.Invoices
                .Where(i => i.InvoiceId == invoiceId)
                .SingleOrDefault();

            var targetedProduct = _context.Products
                .Where(p => p.ProductId == productId)
                .SingleOrDefault();

            var invoiceProduct = _context.InvoiceProduct
                .FirstOrDefault(ip => ip.Invoice.InvoiceId == targetedInvoice.InvoiceId 
                                   && ip.Product.ProductId == targetedProduct.ProductId);

            if (invoiceProduct == null)
            {
                invoiceProduct = new InvoiceProduct()
                {
                    Invoice = targetedInvoice,
                    Product = targetedProduct,
                    Quantity = quantity
                };
                _context.InvoiceProduct.Add(invoiceProduct);
            }
            else
            {
                invoiceProduct.Quantity += quantity;
                _context.Entry(invoiceProduct).State = EntityState.Modified;
            }
            targetedInvoice.Total += targetedProduct.Price * quantity;
            _context.SaveChanges();
        }

        public void RemoveProductFromInvoice(int invoiceId, int productId)
        {
            var productToRemove = _context.InvoiceProduct
                .Where(i => i.Invoice.InvoiceId == invoiceId && i.Product.ProductId == productId)
                .SingleOrDefault();
            if (productToRemove != null)
            {
                productToRemove.Invoice.Total -= productToRemove.Product.Price * productToRemove.Quantity;
                _context.InvoiceProduct.Remove(productToRemove);
                _context.SaveChanges();
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
