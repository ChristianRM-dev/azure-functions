﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Api.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Api.Models.OrderDish", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDish");
                });

            modelBuilder.Entity("Api.Models.OrderPackage", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "PackageId");

                    b.HasIndex("PackageId");

                    b.ToTable("OrderPackage");
                });

            modelBuilder.Entity("Api.Models.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            PackageId = 1,
                            Available = false,
                            Name = "Paquete 1",
                            Price = 190.00m
                        });
                });

            modelBuilder.Entity("Api.Models.PackageProduct", b =>
                {
                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("PackageId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("PackageProduct");

                    b.HasData(
                        new
                        {
                            PackageId = 1,
                            ProductId = 4
                        },
                        new
                        {
                            PackageId = 1,
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("Api.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Envase Chico",
                            Price = 35.00m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Envase Grande",
                            Price = 85.00m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Envase Mediado",
                            Price = 50.00m
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Kilo",
                            Price = 190.00m
                        });
                });

            modelBuilder.Entity("Api.Models.OrderDish", b =>
                {
                    b.HasOne("Api.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.OrderPackage", b =>
                {
                    b.HasOne("Api.Models.Order", "Order")
                        .WithMany("OrderPackages")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Package", "Package")
                        .WithMany("OrderPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.Models.PackageProduct", b =>
                {
                    b.HasOne("Api.Models.Package", "Package")
                        .WithMany("PackageProducts")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Product", "Product")
                        .WithMany("PackageProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
