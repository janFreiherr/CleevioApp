using CleevioApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CleevioApp.Migrations
{
    public class CleevioDBInitializer : DropCreateDatabaseAlways<CleevioDBContext>
    {
        protected override void Seed(CleevioDBContext context)
        {

            var products = new List<Product>()
            {
                new Product{ Name = "IPhone X", Price = 25000.00m},
                new Product{ Name = "Lenoveo ThinkPad P51", Price = 90190.00m},
                new Product{ Name = "Microsoft Keyboard", Price = 2590.00m},
                new Product{ Name = "Benq 27", Price = 6300.00m},
                new Product{ Name = "Rival 100 optical mouse", Price = 600.00m},
                new Product{ Name = "Speakers 7.1 DB", Price = 3800.00m},
                new Product{ Name = "Router ASUS RT-AC58U ", Price = 2299.00m},
                new Product{ Name = "Router TP-Link ", Price = 2299.00m},
                new Product{ Name = "HP NVIDIA Graphics PLUS Quadro P6000 24GB", Price = 138500.00m},
                new Product{ Name = "Intel Core i7-8700K", Price = 8790.00m},
                new Product{ Name = "Intel Core i5-7400", Price = 4190.00m},
                new Product{ Name = "AMD RYZEN Threadripper 1900X", Price = 11190.00m}
            };

            var invoices = new List<Invoice>()
            {
                    new Invoice
                    {
                        ClientName = "Novak",
                        Address = "Baltimore, MD",
                        Date = new DateTime(2018, 3, 5),
                        PaymentStatus = false,
                        Total = 35100.00m,
                    },
                    new Invoice
                    {
                        ClientName = "Freiherr",
                        Address = "Honolulu, Hawaii",
                        Date = new DateTime(2017, 1, 30),
                        PaymentStatus = false,
                        Total = 7188.00m,
                    },
                    new Invoice
                    {
                        ClientName = "Jan",
                        Address = "Banff, CA",
                        Date = new DateTime(2018, 6, 7),
                        PaymentStatus = false,
                        Total = 108078.00m,
                    },
                    new Invoice
                    {
                        ClientName = "CleevioMan",
                        Address = "San Jose, Costa rica",
                        Date = new DateTime(2018, 2, 11),
                        PaymentStatus = false,
                        Total = 111379.00m,
                    },
                    new Invoice
                    {
                        ClientName = "Freeman",
                        Address = "Apia, Samoa",
                        Date = new DateTime(2018, 1, 11),
                        PaymentStatus = false,
                        Total = 248060.00m,
                    }
            };
            
            List<InvoiceProduct> invoiceProducts = new List<InvoiceProduct>()
            {
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Novak"), Product = products[0], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Novak"), Product = products[3], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Novak"), Product = products[5], Quantity = 1},

                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freiherr"), Product = products[2], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freiherr"), Product = products[6], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freiherr"), Product = products[7], Quantity = 1 },

                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Jan"), Product = products[1], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Jan"), Product = products[2], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Jan"), Product = products[3], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Jan"), Product = products[4], Quantity = 1},
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Jan"), Product = products[5], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Jan"), Product = products[6], Quantity = 1},

                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="CleevioMan"), Product = products[1], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="CleevioMan"), Product = products[3], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="CleevioMan"), Product = products[5], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="CleevioMan"), Product = products[7], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="CleevioMan"), Product = products[9], Quantity = 1 },

                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freeman"), Product = products[1], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freeman"), Product = products[2], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freeman"), Product = products[8], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freeman"), Product = products[9], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freeman"), Product = products[5], Quantity = 1 },
                new InvoiceProduct { Invoice = invoices.Find(i => i.ClientName =="Freeman"), Product = products[10], Quantity = 1 }
            };

            context.InvoiceProduct.AddOrUpdate(invoiceProducts.ToArray());
            //var invoice1 = new Invoice
            //{
            //    ClientName = "Novak",
            //    Address = "Baltimore, MD",
            //    Date = new DateTime(2018, 3, 5),
            //    PaymentStatus = false,
            //    Total = 100.34m,
            //};

            //var product1 = new Product()
            //{
            //    Name = "IPhone",
            //    Price = 25000.00m
            //};
            //var product2 = new Product()
            //{
            //    Name = "Honor 8",
            //    Price = 9000.00m
            //};

            //var InvoiceProduct = new InvoiceProduct { Invoice = invoice1, Product = product1 };
            //context.InvoiceProduct.Add(InvoiceProduct);
            //InvoiceProduct = new InvoiceProduct { Invoice = invoice1, Product = product2 };
            //context.InvoiceProduct.Add(InvoiceProduct);

            //var invoice2 = new Invoice
            //{                        
            //    ClientName = "Freiherr",
            //    Address = "Honolulu, Hawaii",
            //    Date = new DateTime(2017, 1, 30),
            //    PaymentStatus = false,
            //    Total = 100.34m,

            //};

            //var product3 = new Product()
            //{
            //    Name = "Samsung Galaxy",
            //    Price = 12340.00m
            //};
            //var product4 = new Product()
            //{
            //    Name = "Lenovo Y510",
            //    Price = 28000.00m
            //};

            //InvoiceProduct = new InvoiceProduct { Invoice = invoice2, Product = product3 };
            //context.InvoiceProduct.Add();
            //InvoiceProduct = new InvoiceProduct { Invoice = invoice2, Product = product4 };
            //context.InvoiceProduct.Add(InvoiceProduct);
            //InvoiceProduct = new InvoiceProduct { Invoice = invoice2, Product = product1 };
            //context.InvoiceProduct.Add(InvoiceProduct);



            //var invoices = new List<Invoice>()
            //{
            //        new Invoice
            //        {
            //            ClientName = "Novak",
            //            Address = "Baltimore, MD",
            //            Date = new DateTime(2018, 3, 5),
            //            PaymentStatus = false,
            //            Total = 100.34m,
            //        },
            //        new Invoice
            //        {
            //            ClientName = "Freiherr",
            //            Address = "Honolulu, Hawaii",
            //            Date = new DateTime(2017, 1, 30),
            //            PaymentStatus = false,
            //            Total = 100.34m,
            //        },
            //        new Invoice
            //        {
            //            ClientName = "Jan",
            //            Address = "Banff, CA",
            //            Date = new DateTime(2018, 6, 7),
            //            PaymentStatus = false,
            //            Total = 100.34m,
            //        },
            //        new Invoice
            //        {
            //            ClientName = "CleevioMan",
            //            Address = "San Jose, Costa rica",
            //            Date = new DateTime(2018, 7, 11),
            //            PaymentStatus = false,
            //            Total = 19.34m,
            //        }
            //};




            base.Seed(context);
        }
    }
}