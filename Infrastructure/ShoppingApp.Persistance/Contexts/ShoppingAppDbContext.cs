﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Domain.Entities.Common;
using ShoppingApp.Domain.Entities.File;
using ShoppingApp.Domain.Entities.Identity;
using File = ShoppingApp.Domain.Entities.File.File;

namespace ShoppingApp.Persistence.Contexts;

public class ShoppingAppDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    public ShoppingAppDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Product>? Products { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Customer>? Customers { get; set; }

    public DbSet<File>? Files { get; set; }
    public DbSet<ProductImageFile>? ProductImages { get; set; }
    public DbSet<InvoiceFile>? InvoiceFiles { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<CompletedOrder> CompletedOrders { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>().HasKey(b => b.Id);

        builder.Entity<Order>()
            .HasIndex(o => o.OrderCode)
            .IsUnique();


        builder.Entity<Basket>()
            .HasOne(b => b.Order)
            .WithOne(o => o.Basket)
            .HasForeignKey<Order>(b => b.Id);

        builder.Entity<Order>()
            .HasOne(o => o.CompletedOrder)
            .WithOne(c => c.Order)
            .HasForeignKey<CompletedOrder>(c => c.OrderId);

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}