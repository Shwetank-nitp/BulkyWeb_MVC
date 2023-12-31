﻿// <auto-generated />
using BulkyEd_Razor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkyEd_Razor.Migrations
{
    [DbContext(typeof(ApplicationDbContent))]
    partial class ApplicationDbContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.7.23375.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkyEd_Razor.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CaregoryOrder")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CaregoryOrder = 1,
                            CategoryName = "Si-Fi"
                        },
                        new
                        {
                            ID = 2,
                            CaregoryOrder = 2,
                            CategoryName = "Suspense Thriller"
                        },
                        new
                        {
                            ID = 3,
                            CaregoryOrder = 3,
                            CategoryName = "MCU"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
