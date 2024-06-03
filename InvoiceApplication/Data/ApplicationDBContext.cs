using InvoiceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Data
{
    public class ApplicationDbContext : DbContext 
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<InvoiceItem> InvoiceItems { get; set; } 
    }
}