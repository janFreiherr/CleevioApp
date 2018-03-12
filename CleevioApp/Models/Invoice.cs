using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CleevioApp.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required]
        public string Address { get; set; }
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        [Display(Name = "Paid")]
        public bool PaymentStatus { get; set; }
        public decimal Total { get; set; }
    }
}