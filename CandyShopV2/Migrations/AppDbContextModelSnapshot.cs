﻿// <auto-generated />
using System;
using CandyShopV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CandyShopV2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CandyShopV2.Models.Candy", b =>
                {
                    b.Property<int>("CandyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<string>("Descrition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbNail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("CandyId");

                    b.HasIndex("CatagoryId");

                    b.ToTable("Candies");

                    b.HasData(
                        new
                        {
                            CandyId = 1,
                            CatagoryId = 3,
                            Descrition = "Very sweet",
                            ImageThumbNail = "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\thumbnails\\FruitCandy-small.jpg",
                            ImageUrl = "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\FruitCandy.jpg",
                            IsOnSale = true,
                            IsOnStock = true,
                            Name = "Sweet candy",
                            Price = 20f
                        },
                        new
                        {
                            CandyId = 2,
                            CatagoryId = 2,
                            Descrition = "Very sour",
                            ImageThumbNail = "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\thumbnails\\halloweenCandy-small.jpg",
                            ImageUrl = "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\halloweenCandy.jpg",
                            IsOnSale = true,
                            IsOnStock = true,
                            Name = "Sour",
                            Price = 50f
                        },
                        new
                        {
                            CandyId = 3,
                            CatagoryId = 1,
                            Descrition = "Very beary",
                            ImageThumbNail = "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\gummyCandy2.jpg",
                            ImageUrl = "C:\\Users\\Mathias\\source\\repos\\CandyShopV2\\CandyShopV2\\wwwroot\\images\\thumbnails\\gummyCandy2-small.jpg",
                            IsOnSale = true,
                            IsOnStock = true,
                            Name = "Gummy bears",
                            Price = 5f
                        });
                });

            modelBuilder.Entity("CandyShopV2.Models.Catagory", b =>
                {
                    b.Property<int>("CatagoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatagoryId");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            CatagoryId = 1,
                            CategoryDescription = "The worst candy",
                            CategoryName = "Chocolate candy"
                        },
                        new
                        {
                            CatagoryId = 3,
                            CategoryDescription = "This is the one for candys with P.H levels below 6",
                            CategoryName = "Sweet"
                        },
                        new
                        {
                            CatagoryId = 2,
                            CategoryDescription = "This is the one for candys with P.H levels above 6",
                            CategoryName = "Sore"
                        });
                });

            modelBuilder.Entity("CandyShopV2.Models.ShoppingCardItem", b =>
                {
                    b.Property<int>("ShoppingCardItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("CandyId")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCardId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCardItemId");

                    b.HasIndex("CandyId");

                    b.ToTable("ShoppingCardItems");
                });

            modelBuilder.Entity("CandyShopV2.Models.Candy", b =>
                {
                    b.HasOne("CandyShopV2.Models.Catagory", "Catagory")
                        .WithMany("Candies")
                        .HasForeignKey("CatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CandyShopV2.Models.ShoppingCardItem", b =>
                {
                    b.HasOne("CandyShopV2.Models.Candy", "Candy")
                        .WithMany()
                        .HasForeignKey("CandyId");
                });
#pragma warning restore 612, 618
        }
    }
}
