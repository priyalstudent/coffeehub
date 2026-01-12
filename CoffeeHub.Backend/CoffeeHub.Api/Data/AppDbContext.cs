using CoffeeHub.Api.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace CoffeeHub.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Classic Espresso",
                    Price = 6.99m,
                    Image = "espresso.png",
                    Description = "A rich and bold espresso made from premium Arabica beans, perfect for strong coffee lovers."
                },
                new Product
                {
                    Id = 2,
                    Name = "Hazelnut Coffee",
                    Price = 7.49m,
                    Image = "hazelnut.png",
                    Description = "Smooth coffee infused with warm hazelnut notes for a nutty and comforting flavor.\",\r\n  },"
                },
                new Product
                {
                    Id = 3,
                    Name = "Vanilla Brew",
                    Price = 7.29m,
                    Image = "vanilla.png",
                    Description = "A balanced coffee blend with subtle vanilla sweetness for a smooth, aromatic cup."
                },
                new Product
                {
                     Id = 4,
                     Name = "Caramel Roast",
                     Price = 7.59m,
                     Image = "caramel.png",
                     Description = "Medium-roasted coffee with buttery caramel undertones and a naturally sweet finish.",
                },
                 new Product
                 {
                     Id = 5,
                     Name = "Mocha Blend",
                     Price = 7.89m,
                     Image = "mocha.png",
                     Description = "A deep coffee blend combined with chocolate notes for a rich and indulgent taste.",
                 },
                 new Product
                 {
                     Id = 6,
                     Name = "Chocolate Raspberry",
                     Price = 8.29m,
                     Image = "chocoRaspberry.png",
                     Description = "A bold coffee infused with dark chocolate and fruity raspberry accents for a unique twist.",
                 },
                 new Product
                 {
                     Id = 7,
                     Name = "Raw Mango",
                     Price = 7.99m,
                     Image = "mango.png",
                     Description = "A refreshing coffee blend with tangy raw mango notes for an unexpected, vibrant flavor.",
                 },
                  new Product
                  {
                      Id = 8,
                      Name = "Pineapple Delight",
                      Price = 7.79m,
                      Image = "pineapple.png",
                      Description = "Light coffee with tropical pineapple hints, delivering a bright and refreshing taste.",
                  },
                   new Product
                   {
                       Id = 9,
                       Name = "Royal Pistachio",
                       Price = 8.49m,
                       Image = "pistachio.png",
                       Description = "Smooth coffee infused with roasted pistachio flavor for a creamy, nut-forward finish.",
                   }
            );
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.Price)
        //        .HasPrecision(8, 2);
        //}
    }
}
