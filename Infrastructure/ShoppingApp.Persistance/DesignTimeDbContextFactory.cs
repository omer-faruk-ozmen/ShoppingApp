using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoppingAppDbContext>
    {
        public ShoppingAppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ShoppingAppDbContext> dbConeContextOptionsBuilder = new();
            dbConeContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbConeContextOptionsBuilder.Options);
        }
    }
}
