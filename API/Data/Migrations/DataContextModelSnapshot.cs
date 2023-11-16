﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ShoppingListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("API.Entities.Shopper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShopperName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Shoppers");
                });

            modelBuilder.Entity("API.Entities.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShopperId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ShopperId");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.HasOne("API.Entities.ShoppingList", null)
                        .WithMany("Items")
                        .HasForeignKey("ShoppingListId");
                });

            modelBuilder.Entity("API.Entities.ShoppingList", b =>
                {
                    b.HasOne("API.Entities.Shopper", null)
                        .WithMany("ShoppingList")
                        .HasForeignKey("ShopperId");
                });

            modelBuilder.Entity("API.Entities.Shopper", b =>
                {
                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("API.Entities.ShoppingList", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
