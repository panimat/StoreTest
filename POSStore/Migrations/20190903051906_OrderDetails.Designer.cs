﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSStore.Data;

namespace POSStore.Migrations
{
    [DbContext(typeof(AppDBInfo))]
    [Migration("20190903051906_OrderDetails")]
    partial class OrderDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POSStore.Data.Model.CartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StoreCartId");

                    b.Property<decimal>("price");

                    b.Property<int?>("productid");

                    b.HasKey("id");

                    b.HasIndex("productid");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("POSStore.Data.Model.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("img");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("POSStore.Data.Model.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<DateTime>("orderTime");

                    b.Property<string>("phone");

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("POSStore.Data.Model.OrderItems", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<int>("orderId");

                    b.Property<string>("phone");

                    b.Property<decimal>("price");

                    b.Property<int>("productId");

                    b.HasKey("id");

                    b.HasIndex("orderId");

                    b.HasIndex("productId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("POSStore.Data.Model.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryId");

                    b.Property<string>("description");

                    b.Property<string>("img");

                    b.Property<bool>("isAvailable");

                    b.Property<bool>("isMostPopular");

                    b.Property<string>("name");

                    b.Property<decimal>("price");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("POSStore.Data.Model.CartItem", b =>
                {
                    b.HasOne("POSStore.Data.Model.Product", "product")
                        .WithMany()
                        .HasForeignKey("productid");
                });

            modelBuilder.Entity("POSStore.Data.Model.OrderItems", b =>
                {
                    b.HasOne("POSStore.Data.Model.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("POSStore.Data.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("POSStore.Data.Model.Product", b =>
                {
                    b.HasOne("POSStore.Data.Model.Category", "Categ")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
