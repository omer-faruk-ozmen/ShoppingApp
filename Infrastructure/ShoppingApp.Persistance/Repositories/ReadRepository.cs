using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Repositories;
using ShoppingApp.Domain.Entities.Common;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ShoppingAppDbContext _context;

        public ReadRepository(ShoppingAppDbContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            //return await Table.FirstOrDefaultAsync(data => data.Id==Guid.Parse(id));
            return await Table.FindAsync(Guid.Parse(id));
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }
    }
}
