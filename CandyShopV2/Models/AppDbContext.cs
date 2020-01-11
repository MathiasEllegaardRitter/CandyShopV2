using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopV2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Candy> Candies { get; set; }
        public DbSet<Catagory> categories { get; set; }
        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category hard code

            modelBuilder.Entity<Catagory>().HasData(new Catagory 
            { CatagoryId = 1, CategoryName = "Chocolate candy", CategoryDescription = "The worst candy" });
            modelBuilder.Entity<Catagory>().HasData(new Catagory 
            { CatagoryId = 3, CategoryName = "Sweet", CategoryDescription = "This is the one for candys with P.H levels below 6" });
            modelBuilder.Entity<Catagory>().HasData(new Catagory 
            { CatagoryId = 2, CategoryName = "Sore", CategoryDescription = "This is the one for candys with P.H levels above 6" });


            // Candy hard code

            modelBuilder.Entity<Candy>().HasData(new Candy { 
                CandyId = 1, 
                Name = "Sweet candy", 
                IsOnStock = true,
                IsOnSale = true,
                Descrition = "Very sweet", 
                Price = 20, 
                CatagoryId = 3, 
                ImageUrl = @"C:\Users\Mathias\source\repos\CandyShopV2\CandyShopV2\wwwroot\images\FruitCandy.jpg",
                ImageThumbNail = @"C:\Users\Mathias\source\repos\CandyShopV2\CandyShopV2\wwwroot\images\thumbnails\FruitCandy-small.jpg"
                });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 2,
                Name = "Sour",
                IsOnStock = true,
                IsOnSale = true,
                Descrition = "Very sour",
                Price = 50,
                CatagoryId = 2,
                ImageUrl = @"C:\Users\Mathias\source\repos\CandyShopV2\CandyShopV2\wwwroot\images\halloweenCandy.jpg",
                ImageThumbNail = @"C:\Users\Mathias\source\repos\CandyShopV2\CandyShopV2\wwwroot\images\thumbnails\halloweenCandy-small.jpg"
            });
            modelBuilder.Entity<Candy>().HasData(new Candy
            {
                CandyId = 3,
                Name = "Gummy bears",
                IsOnStock = true,
                Descrition = "Very beary",
                IsOnSale = true,
                Price = 5,
                CatagoryId = 1,
                ImageUrl = @"C:\Users\Mathias\source\repos\CandyShopV2\CandyShopV2\wwwroot\images\thumbnails\gummyCandy2-small.jpg",
                ImageThumbNail = @"C:\Users\Mathias\source\repos\CandyShopV2\CandyShopV2\wwwroot\images\gummyCandy2.jpg"
            });

        }
        
        


    }
}
