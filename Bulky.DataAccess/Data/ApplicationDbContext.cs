using Bulky.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    // Use IdentityDbContext base class if you are building login and registration
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);   // This line is ery important for Identity to run

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Romance", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Crime", DisplayOrder = 5 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title="Fortune of Time",
                    Author="Billy Spark",
                    Description="Praesent viate sodales libero. Praesent modales actionest.",
                    ISBN="SWD9999001",
                    ListPrice=99,
                    Price=98,
                    Price50=85,
                    Price100=80,
                    CategoryId = 3,
                    ImageUrl=""

                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent viate sodales libero. Praesent modales actionest.",
                    ISBN = "CAW777777701",
                    ListPrice = 48,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 4,
                    ImageUrl = ""
                },

                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent viate sodales libero. Praesent modales actionest.",
                    ISBN = "RIT05555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryId = 2,
                    ImageUrl = ""
                },

                new Product
                {
                    Id = 4,
                    Title = "Cotton candy",
                    Author = "Abby Muscles",
                    Description = "Praesent viate sodales libero. Praesent modales actionest.",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryId = 5,
                    ImageUrl = ""
                },

                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent viate sodales libero. Praesent modales actionest.",
                    ISBN = "SQTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                },

                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phanton",
                    Description = "Praesent viate sodales libero. Praesent modales actionest.",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryId = 3,
                    ImageUrl = ""
                }

                );






        }
    }
}
