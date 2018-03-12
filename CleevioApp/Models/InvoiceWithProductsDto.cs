using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CleevioApp.Models
{
    public class InvoiceWithProductsDto
    {
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public IEnumerable<ProductWithQuantityDto> Products { get; set; }
        [Display(Name = "Paid")]
        public bool PaymentStatus { get; set; }
        public decimal Total { get; set; }
    }
}