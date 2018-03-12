using CleevioApp.Migrations;
using CleevioApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CleevioApp.Models
{
    public class CleevioDBContext : DbContext
    {
        public CleevioDBContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CleevioDBInitializer());
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<InvoiceProduct> InvoiceProduct { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}