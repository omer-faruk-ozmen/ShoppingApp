using Bogus;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Persistence.Contexts
{
    public class SeedData
    {
        private static List<Product> GetProducts()
        {
            var result = new Faker<Product>("tr")
                .RuleFor(i=>i.Id,i=>Guid.NewGuid())
                .RuleFor(i => i.Name, i => i.Lorem.Sentence(3,3))
                .RuleFor(i=>i.Stock,i=>i.Random.Number(0,500))
                .RuleFor(i=>i.Price,i=>i.Random.Number(10,5000))
                .RuleFor(i=>i.CreatedDate,i=>i.Date.Between(DateTime.UtcNow.AddDays(-100),DateTime.UtcNow))
                .Generate(500);
                

            return result;
        }

        public async Task SeedAsync()
        {
            var dbContextBuilder = new DbContextOptionsBuilder();

            var connStr = Configuration.ConnectionString;
            dbContextBuilder.UseNpgsql(connStr);

            var context = new ShoppingAppDbContext(dbContextBuilder.Options);

            if (context.Products.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var products = GetProducts();
            await context.Products.AddRangeAsync(products);

            await context.SaveChangesAsync();
            
        }
    }
}
