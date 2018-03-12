namespace CleevioApp.Migrations
{
    using CleevioApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CleevioApp.Models.CleevioDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CleevioApp.Models.CleevioDBContext context)
        {

            //var items = new List<InvoiceProduct>()
            //{
            //    new InvoiceProduct{ Name = "Phone", Price = 8900.00m},
            //    new InvoiceProduct{ Name = "NoteBook", Price = 18900.00m},
            //    new InvoiceProduct{ Name = "Keyboard", Price = 820.00m},
            //    new InvoiceProduct{ Name = "Display", Price = 4500.00m},
            //    new InvoiceProduct{ Name = "Mouse", Price = 600.00m},
            //    new InvoiceProduct{ Name = "Speakers", Price = 800.00m},
            //    new InvoiceProduct{ Name = "Router", Price = 1090.00m}
            //};
            //context.Items.AddOrUpdate(item => item.Name, items.ToArray());
            

            //context.Invoices.AddOrUpdate(i => new { i.Id, i.ClientName },
            //    new Invoice
            //    {
            //        ClientName = "Novak",
            //        Address = "Baltimore, USA",
            //        Date = new DateTime(2018, 3, 5),
            //        PaymentStatus = false,
            //        Total = 100.34m,
            //        //Items = null
            //    }
            //    );
        }
    }
}
