using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Data.DataContext
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13; Database=StoreDatabase; Trusted_Connection=True; MultipleActiveResultSets=True");
        }
    }
}
