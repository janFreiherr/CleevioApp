using CleevioApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CleevioApp.Services
{
    public class AutoMapperBootStrapper
    {
        public static void BootStrap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceWithProductsDto>();
                cfg.CreateMap<Product, ProductForDeleteDto>();
                cfg.CreateMap<Product, ProductForAddDto>();
                cfg.CreateMap<Product, ProductWithQuantityDto>();

            });
        }
    }
}