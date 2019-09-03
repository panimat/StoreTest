using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using POSStore.Data.Model;

namespace POSStore.Data
{
    public class AppDBInfo : DbContext
    {
        public AppDBInfo(DbContextOptions<AppDBInfo> options) : base (options)
        {

        }

        //Tables in database STORE_DB

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
