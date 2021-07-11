using Microsoft.EntityFrameworkCore;
using Project.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Infrastructure.DataContext
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new StoreContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.SaveChanges();
                }
                if (context.ProductBrands.Count() == 0)
                {
                    context.ProductBrands.AddRange(ProductBrands);
                    context.SaveChanges();
                }
                if (context.ProductTypes.Count() == 0)
                {
                    context.ProductTypes.AddRange(ProductTypes);
                    context.SaveChanges();
                }
            }
        }

        private static Product[] Products = {
            new Product() { Name = "product1" , Description = "description" , PictureUrl = "url", Price=56, ProductTypeId = 1, ProductBrandId=1 },
            new Product() { Name = "product2" , Description = "description" , PictureUrl = "url", Price=28,ProductTypeId = 1, ProductBrandId=1},
            new Product() { Name = "product3" , Description = "description" , PictureUrl = "url", Price=77, ProductTypeId = 1, ProductBrandId=1}
        };

        private static ProductBrand[] ProductBrands = {
            new ProductBrand() { Name = "brand1" },
            new ProductBrand() { Name = "brand2" },
            new ProductBrand() { Name = "brand3"}
        };
        private static ProductType[] ProductTypes = {
            new ProductType() { Name = "type1" },
            new ProductType() { Name = "type2" },
            new ProductType() { Name = "type3"}
        };
    }
}
