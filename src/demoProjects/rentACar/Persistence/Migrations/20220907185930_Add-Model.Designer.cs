﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220907185930_Add-Model")]
    partial class AddModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Porsche"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alfa Romeo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "BMW"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("BrandId");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            DailyPrice = 1899.99m,
                            ImageUrl = "",
                            Name = "911"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            DailyPrice = 1699.99m,
                            ImageUrl = "",
                            Name = "Cayman"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 2,
                            DailyPrice = 1299.99m,
                            ImageUrl = "",
                            Name = "C"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            DailyPrice = 1499.99m,
                            ImageUrl = "",
                            Name = "E"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 3,
                            DailyPrice = 1399.99m,
                            ImageUrl = "",
                            Name = "Guilia"
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 3,
                            DailyPrice = 1499.99m,
                            ImageUrl = "",
                            Name = "Stelvio"
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 4,
                            DailyPrice = 1499.99m,
                            ImageUrl = "",
                            Name = "Series 5"
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 4,
                            DailyPrice = 999.99m,
                            ImageUrl = "",
                            Name = "Series 1"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Model", b =>
                {
                    b.HasOne("Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}