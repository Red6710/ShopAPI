using Microsoft.EntityFrameworkCore;
using SzkolkaRoslin_API.Models;

namespace SzkolkaRoslin_API.Controllers.Data
{
    
        public class ApplicationDbContext(DbContextOptions options) : DbContext(options) 
        { 
            public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Fikus Benjamina",
                        Description = "Elegancka roślina doniczkowa idealna do salonu. Łatwa w pielęgnacji, oczyszcza powietrze.",
                        Price = 49.99,
                        ImageUrl = "https://example.com/images/fikus-benjamina.jpg",
                        CreateDate = new DateTime(2024, 1, 15),
                        UpdatedDate = new DateTime(2024, 4, 10)
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Monstera Deliciosa",
                        Description = "Popularna roślina tropikalna o charakterystycznych dziurawych liściach. Idealna do jasnych pomieszczeń.",
                        Price = 79.99,
                        ImageUrl = "https://example.com/images/monstera.jpg",
                        CreateDate = new DateTime(2024, 2, 20),
                        UpdatedDate = new DateTime(2024, 3, 1)
                    },
                   new Product
                    {
                       Id = 3,
                       Name = "Podłoże uniwersalne 10L",
                       Description = "Wysokiej jakości ziemia do większości roślin doniczkowych i ogrodowych.",
                       Price = 19.99,
                       ImageUrl = "https://example.com/images/podloze.jpg",
                       CreateDate = new DateTime(2024, 1, 10),
                       UpdatedDate = new DateTime(2024, 4, 12)
                   },
                    new Product
                    {
                        Id = 4,
                        Name = "Nawóz do roślin zielonych",
                        Description = "Płynny nawóz mineralny wspomagający wzrost i intensywność koloru liści. Pojemność 500ml.",
                        Price = 24.99,
                        ImageUrl = "https://example.com/images/nawoz.jpg",
                        CreateDate = new DateTime(2024, 3, 5),
                        UpdatedDate = new DateTime(2024, 3, 10)
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Doniczka ceramiczna 20cm",
                        Description = "Ręcznie robiona doniczka ceramiczna z podstawką. Dostępna w kolorze terakoty.",
                        Price = 34.99,
                        ImageUrl = "https://example.com/images/doniczka.jpg",
                        CreateDate = new DateTime(2024, 2, 1),
                        UpdatedDate = new DateTime(2024, 4, 15)
                    }
                );
        }

        }
    
}
