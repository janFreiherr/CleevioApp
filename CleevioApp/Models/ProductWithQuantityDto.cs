using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CleevioApp.Models
{
    public class ProductWithQuantityDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}