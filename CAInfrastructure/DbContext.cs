using Microsoft.EntityFrameworkCore;
using MvcProductCA.Entities;
using System.Collections.Generic;
using MvcProductCA.UseCases;

namespace MvcProductCA.Infrastructure
{
    // Infrastructure/Data/DbContext.cs
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
      
        public DbSet<MvcProductCA.UseCases.ProductDTO>? ProductDTO { get; set; }
    }
}
