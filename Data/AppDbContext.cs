using Microsoft.EntityFrameworkCore;
using AstoundWebAPI.Models;

namespace AstoundWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Seed database with authors and books for demo
            new DbInitializer(builder).Seed();
        }
    }
}