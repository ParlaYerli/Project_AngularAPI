using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Infrastructure.DataContext
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13; Database=StoreDatabase; Trusted_Connection=True; MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product() {Id=1, Name = "product1", Description = "description", PictureUrl = "url", Price = 56, ProductTypeId = 1, ProductBrandId = 1 },
                                                   new Product() {Id=2, Name = "product2", Description = "description", PictureUrl = "url", Price = 28, ProductTypeId = 1, ProductBrandId = 1 },
                                                   new Product() {Id=3, Name = "product3", Description = "description", PictureUrl = "url", Price = 77, ProductTypeId = 1, ProductBrandId = 1 });
            modelBuilder.Entity<ProductBrand>().HasData(new ProductBrand() {Id = 1,  Name = "brand1" },
                                                        new ProductBrand() {Id = 2,  Name = "brand2" },
                                                        new ProductBrand() {Id = 3, Name = "brand3" });
            modelBuilder.Entity<ProductType>().HasData(new ProductType() {Id = 1,  Name = "type1" },
                                                       new ProductType() {Id = 2,  Name = "type2" },
                                                       new ProductType() {Id = 3, Name = "type3" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
