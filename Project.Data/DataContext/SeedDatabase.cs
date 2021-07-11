using Microsoft.EntityFrameworkCore;
using Project.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Data.DataContext
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
            }
        }

        private static Product[] Products = {
            new Product() { Name = "test1" },
            new Product() { Name= "Bilgisayar" },
            new Product() { Name="Elektronik"}
        };
    }
}
