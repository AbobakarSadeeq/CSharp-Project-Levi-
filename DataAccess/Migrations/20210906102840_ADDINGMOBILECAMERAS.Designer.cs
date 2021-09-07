﻿// <auto-generated />
using System;
using DataAccess.Data.DataContext_Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210906102840_ADDINGMOBILECAMERAS")]
    partial class ADDINGMOBILECAMERAS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Bussiness_Core.Entities.Mobile", b =>
                {
                    b.Property<int>("Mobile_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BatteryMah")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bluetooth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Charger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("HeadPhoneJack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaunchData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MobilePrice")
                        .HasColumnType("int");

                    b.Property<string>("MobileWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("OSVersionId")
                        .HasColumnType("int");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellUnits")
                        .HasColumnType("int");

                    b.Property<bool>("StockAvailiability")
                        .HasColumnType("bit");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("USBConnector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wifi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Mobile_Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.HasIndex("OSVersionId");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.MobileBackCamera", b =>
                {
                    b.Property<int>("MobileBackCamera_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CameraDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MobileId")
                        .HasColumnType("int");

                    b.HasKey("MobileBackCamera_Id");

                    b.HasIndex("MobileId");

                    b.ToTable("MobileBackCameras");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.MobileFrontCamera", b =>
                {
                    b.Property<int>("MobileFrontCamera_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CameraDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MobileId")
                        .HasColumnType("int");

                    b.HasKey("MobileFrontCamera_Id");

                    b.HasIndex("MobileId");

                    b.ToTable("MobileFrontCameras");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.NetworksMobile", b =>
                {
                    b.Property<int>("MobileNetwork_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InternetNetworkId")
                        .HasColumnType("int");

                    b.Property<int>("MobileId")
                        .HasColumnType("int");

                    b.HasKey("MobileNetwork_Id");

                    b.HasIndex("InternetNetworkId");

                    b.HasIndex("MobileId");

                    b.ToTable("NetworksMobiles");
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

            modelBuilder.Entity("Bussiness_Core.Entities.Mobile", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bussiness_Core.Entities.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bussiness_Core.Entities.OperatingSystemVersion", "OperatingSystemVersion")
                        .WithMany()
                        .HasForeignKey("OSVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");

                    b.Navigation("OperatingSystemVersion");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.MobileBackCamera", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Mobile", "Mobile")
                        .WithMany("MobileBackCameras")
                        .HasForeignKey("MobileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mobile");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.MobileFrontCamera", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Mobile", "Mobile")
                        .WithMany("MobileFrontCameras")
                        .HasForeignKey("MobileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mobile");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.NetworksMobile", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.InternetNetwork", "InternetNetwork")
                        .WithMany()
                        .HasForeignKey("InternetNetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bussiness_Core.Entities.Mobile", "Mobile")
                        .WithMany("NetworksMobiles")
                        .HasForeignKey("MobileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InternetNetwork");

                    b.Navigation("Mobile");
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

            modelBuilder.Entity("Bussiness_Core.Entities.Mobile", b =>
                {
                    b.Navigation("MobileBackCameras");

                    b.Navigation("MobileFrontCameras");

                    b.Navigation("NetworksMobiles");
                });
#pragma warning restore 612, 618
        }
    }
}
