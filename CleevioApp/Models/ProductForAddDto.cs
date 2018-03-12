using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CleevioApp.Models
{
    public class ProductForAddDto
    {
        [Key]
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        [Display(Name = "Product")]
        public virtual List<SelectListItem> ProductsList { get; set; }
        [Range(1,100)]
        public int Quantity { get; set; }
    }
}