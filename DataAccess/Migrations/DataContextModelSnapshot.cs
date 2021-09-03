﻿// <auto-generated />
using System;
using DataAccess.Data.DataContext_Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bussiness_Core.Entities.Brand", b =>
                {
                    b.Property<int>("Brand_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Brand_Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Category", b =>
                {
                    b.Property<int>("Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Category_Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Color", b =>
                {
                    b.Property<int>("Color_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Color_Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.InternetNetwork", b =>
                {
                    b.Property<int>("InternetNetwork_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NetworkName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InternetNetwork_Id");

                    b.ToTable("InternetNetworks");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.OperatingSystemVersion", b =>
                {
                    b.Property<int>("OSV_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OSVName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperatingSystemId")
                        .HasColumnType("int");

                    b.HasKey("OSV_Id");

                    b.HasIndex("OperatingSystemId");

                    b.ToTable("OperatingSystemVersions");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.OperatingSystems", b =>
                {
                    b.Property<int>("OperatingSystem_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("OperatingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperatingSystem_Id");

                    b.ToTable("OperatingSystems");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Brand", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.OperatingSystemVersion", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.OperatingSystems", "OperatingSystemss")
                        .WithMany()
                        .HasForeignKey("OperatingSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperatingSystemss");
                });
#pragma warning restore 612, 618
        }
    }
}
