﻿namespace MemoryCaching.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product 1", Price = 10.0m, Description = "Description 1" },
            new Product { Id = 2, Name = "Product 2", Price = 20.0m, Description = "Description 2" },
            new Product { Id = 3, Name = "Product 3", Price = 30.0m, Description = "Description 3" }
        );
    }
}
