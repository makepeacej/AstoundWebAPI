using Microsoft.EntityFrameworkCore;
using AstoundWebAPI.Models;

namespace AstoundWebAPI.Data
{    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Contact>(a =>
            {
                a.HasData(new Contact
                {
                    Id = 25,
                    Name = "J.K. Rowling",
                    Email = "jkr@email.com",
                    Phone = "5565899987",
                    TechNum = 35687,
                    JobCategory = Jobs.Manager
                });
                
            });

            _builder.Entity<Link>(b =>
            {
                b.HasData(new Link
                {
                    Id = 23,
                    Name = "Harry Potter Site",
                    Url = "https://www.wizardingworld.com/"
                });
               
            });
        }
    }
}