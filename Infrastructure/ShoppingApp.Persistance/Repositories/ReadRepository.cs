﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Repositories;
using ShoppingApp.Domain.Entities.Common;
using ShoppingApp.Persistence.Contexts;

namespace ShoppingApp.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly ShoppingAppDbContext _context;

    public ReadRepository(ShoppingAppDbContext context)
    {
        _context = context;
    }


    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T?> GetByIdAsync(string id, bool tracking = true)
    {
        //return await Table.FirstOrDefaultAsync(data => data.Id==Guid.Parse(id));
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }
}