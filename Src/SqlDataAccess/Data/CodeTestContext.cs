using CodeTest.Domain.Areas.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeTest.SqlDataAccess.Data
{
    public class CodeTestContext : DbContext
    {
        public CodeTestContext(DbContextOptions<CodeTestContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Product>().ToTable("Product");
    }
}