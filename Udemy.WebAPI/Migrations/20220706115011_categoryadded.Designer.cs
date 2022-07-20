﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Udemy.WebAPI.Data;

namespace Udemy.WebAPI.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20220706115011_categoryadded")]
    partial class categoryadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Udemy.WebAPI.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Elektronik"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Giyim"
                        });
                });

            modelBuilder.Entity("Udemy.WebAPI.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 7, 3, 14, 50, 11, 72, DateTimeKind.Local).AddTicks(9947),
                            Name = "Bilgisayar",
                            Price = 15000m,
                            Stock = 300
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 6, 6, 14, 50, 11, 74, DateTimeKind.Local).AddTicks(3865),
                            Name = "Telefon",
                            Price = 10000m,
                            Stock = 500
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreateDate = new DateTime(2022, 5, 7, 14, 50, 11, 74, DateTimeKind.Local).AddTicks(3887),
                            Name = "Klavye",
                            Price = 100m,
                            Stock = 1000
                        });
                });

            modelBuilder.Entity("Udemy.WebAPI.Data.Product", b =>
                {
                    b.HasOne("Udemy.WebAPI.Data.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Udemy.WebAPI.Data.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
