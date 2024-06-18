﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eCommerce.Database;

#nullable disable

namespace eCommerce.Database.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    partial class ECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("eCommerce.Database.DbEntities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bulding")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<int?>("UsersAddressesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsersAddressesId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.CartElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartElement");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("Mark")
                        .HasColumnType("double precision");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.PointOfDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("PointOfDeliveries");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double?>("Rating")
                        .HasColumnType("double precision");

                    b.Property<string>("Reference")
                        .HasColumnType("text");

                    b.Property<int?>("SellerId")
                        .HasColumnType("integer");

                    b.Property<int?>("StockId")
                        .HasColumnType("integer");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("SuppliersId")
                        .HasColumnType("integer");

                    b.Property<int>("Unit")
                        .HasColumnType("integer");

                    b.Property<double>("Volume")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.HasIndex("StockId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<List<int>>("Products")
                        .HasColumnType("integer[]");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("CashAccount")
                        .HasColumnType("double precision");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Supplies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("SellerId")
                        .HasColumnType("integer");

                    b.Property<double>("Sum")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.UsersAddresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UsersAddresses");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.UsersFavourites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<List<int>>("Products")
                        .HasColumnType("integer[]");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UsersFavourites");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Address", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.UsersAddresses", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UsersAddressesId");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.CartElement", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("eCommerce.Database.DbEntities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.FeedBack", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Product", "Product")
                        .WithMany("FeedBacks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Database.DbEntities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.PointOfDelivery", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerce.Database.DbEntities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Product", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Seller", null)
                        .WithMany("Products")
                        .HasForeignKey("SellerId");

                    b.HasOne("eCommerce.Database.DbEntities.Stock", null)
                        .WithMany("Products")
                        .HasForeignKey("StockId");

                    b.HasOne("eCommerce.Database.DbEntities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId");

                    b.HasOne("eCommerce.Database.DbEntities.Suppliers", null)
                        .WithMany("ProductsList")
                        .HasForeignKey("SuppliersId");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Stock", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.SubCategory", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Category", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Supplies", b =>
                {
                    b.HasOne("eCommerce.Database.DbEntities.Seller", null)
                        .WithMany("Supplies")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Product", b =>
                {
                    b.Navigation("FeedBacks");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Seller", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Stock", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.SubCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.Suppliers", b =>
                {
                    b.Navigation("ProductsList");
                });

            modelBuilder.Entity("eCommerce.Database.DbEntities.UsersAddresses", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
