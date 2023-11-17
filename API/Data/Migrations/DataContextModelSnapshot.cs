﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemName = "Pepper"
                        },
                        new
                        {
                            Id = 2,
                            ItemName = "Soap"
                        },
                        new
                        {
                            Id = 3,
                            ItemName = "Salmon"
                        },
                        new
                        {
                            Id = 4,
                            ItemName = "Milk"
                        },
                        new
                        {
                            Id = 5,
                            ItemName = "Lightbulb"
                        });
                });

            modelBuilder.Entity("API.Entities.Shopper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ShopperName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shoppers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ShopperName = "Till"
                        },
                        new
                        {
                            Id = 2,
                            ShopperName = "Iago"
                        },
                        new
                        {
                            Id = 3,
                            ShopperName = "Flo"
                        },
                        new
                        {
                            Id = 4,
                            ShopperName = "Eli"
                        },
                        new
                        {
                            Id = 5,
                            ShopperName = "Jon"
                        });
                });

            modelBuilder.Entity("API.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShopperId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopperId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("API.Entities.ShoppingListItem", b =>
                {
                    b.Property<int>("ShoppingListId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingListId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ShoppingListItems");
                });

            modelBuilder.Entity("API.Entities.ShoppingList", b =>
                {
                    b.HasOne("API.Entities.Shopper", "Shopper")
                        .WithMany("ShoppingList")
                        .HasForeignKey("ShopperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shopper");
                });

            modelBuilder.Entity("API.Entities.ShoppingListItem", b =>
                {
                    b.HasOne("API.Entities.Item", "Item")
                        .WithMany("ShoppingListItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListItems")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.Navigation("ShoppingListItems");
                });

            modelBuilder.Entity("API.Entities.Shopper", b =>
                {
                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("API.Entities.ShoppingList", b =>
                {
                    b.Navigation("ShoppingListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
