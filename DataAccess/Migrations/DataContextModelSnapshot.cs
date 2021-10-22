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

            modelBuilder.Entity("Bussiness_Core.Entities.AccountBalance", b =>
                {
                    b.Property<int>("BalanceAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("User_ID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BalanceAccountId");

                    b.HasIndex("User_ID");

                    b.ToTable("AccountBalances");
                });

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

            modelBuilder.Entity("Bussiness_Core.Entities.Carousel", b =>
                {
                    b.Property<int>("CarouselID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImagePriority")
                        .HasColumnType("int");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarouselID");

                    b.ToTable("Carousels");
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

            modelBuilder.Entity("Bussiness_Core.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Country_ID")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("Country_ID");

                    b.ToTable("Cities");
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

            modelBuilder.Entity("Bussiness_Core.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.CustomIdentity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DathOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeHireDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("User_ID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("User_ID")
                        .IsUnique()
                        .HasFilter("[User_ID] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.EmployeeMonthlyPayment", b =>
                {
                    b.Property<int>("EmployeeMonthlyPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Employee_ID")
                        .HasColumnType("int");

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Payment_At")
                        .HasColumnType("date");

                    b.HasKey("EmployeeMonthlyPaymentId");

                    b.HasIndex("Employee_ID");

                    b.ToTable("EmployeeMonthlyPayments");
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

                    b.Property<DateTime?>("LaunchDate")
                        .HasColumnType("date");

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

            modelBuilder.Entity("Bussiness_Core.Entities.MobileImages", b =>
                {
                    b.Property<int>("MobileImages_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MobileId")
                        .HasColumnType("int");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MobileImages_Id");

                    b.HasIndex("MobileId");

                    b.ToTable("MobileImages");
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

            modelBuilder.Entity("Bussiness_Core.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomIdentityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomIdentityId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Mobile_Id")
                        .HasColumnType("int");

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("Mobile_Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.UserAddress", b =>
                {
                    b.Property<int>("UserAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("City_ID")
                        .HasColumnType("int");

                    b.Property<string>("CompleteAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_ID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserAddressId");

                    b.HasIndex("City_ID");

                    b.HasIndex("User_ID")
                        .IsUnique()
                        .HasFilter("[User_ID] IS NOT NULL");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.UserImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomIdentityId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionHeader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainPhoto")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomIdentityId");

                    b.ToTable("UserImages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.AccountBalance", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", "User")
                        .WithMany()
                        .HasForeignKey("User_ID");

                    b.Navigation("User");
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

            modelBuilder.Entity("Bussiness_Core.Entities.City", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("Country_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Employee", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", "User")
                        .WithOne("Employee")
                        .HasForeignKey("Bussiness_Core.Entities.Employee", "User_ID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.EmployeeMonthlyPayment", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employee_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
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

            modelBuilder.Entity("Bussiness_Core.Entities.MobileImages", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Mobile", "Mobile")
                        .WithMany("MobileImagess")
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
                        .WithMany("networksMobiles")
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

            modelBuilder.Entity("Bussiness_Core.Entities.Order", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", "CustomIdentity")
                        .WithMany()
                        .HasForeignKey("CustomIdentityId");

                    b.Navigation("CustomIdentity");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.OrderDetail", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.Mobile", "Mobile")
                        .WithMany()
                        .HasForeignKey("Mobile_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bussiness_Core.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mobile");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.UserAddress", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("City_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", "User")
                        .WithOne("UserAddress")
                        .HasForeignKey("Bussiness_Core.Entities.UserAddress", "User_ID");

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.UserImage", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", "CustomIdentity")
                        .WithMany("UserImages")
                        .HasForeignKey("CustomIdentityId");

                    b.Navigation("CustomIdentity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bussiness_Core.Entities.CustomIdentity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bussiness_Core.Entities.CustomIdentity", b =>
                {
                    b.Navigation("Employee");

                    b.Navigation("UserAddress");

                    b.Navigation("UserImages");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Mobile", b =>
                {
                    b.Navigation("MobileBackCameras");

                    b.Navigation("MobileFrontCameras");

                    b.Navigation("MobileImagess");

                    b.Navigation("networksMobiles");
                });

            modelBuilder.Entity("Bussiness_Core.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
