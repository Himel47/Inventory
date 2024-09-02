﻿// <auto-generated />
using System;
using Inventory.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace productsDetails.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240825041504_category-drop")]
    partial class categorydrop
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("productsDetails.Models.Product", b =>
                {
                    b.Property<Guid>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("productDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productUnitPrice")
                        .HasColumnType("int");

                    b.HasKey("productId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("productsDetails.Models.Stock", b =>
                {
                    b.Property<Guid>("skuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("categoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productQuantity")
                        .HasColumnType("int");

                    b.Property<int>("productUnitCost")
                        .HasColumnType("int");

                    b.Property<string>("stockStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stockTotalCost")
                        .HasColumnType("int");

                    b.Property<Guid?>("supplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("skuId");

                    b.ToTable("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
