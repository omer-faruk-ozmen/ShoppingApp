using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Persistence.Contexts
{
    public class ShoppingAppDbContext : DbContext   
    {
        public ShoppingAppDbContext(DbContextOptions options):base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
