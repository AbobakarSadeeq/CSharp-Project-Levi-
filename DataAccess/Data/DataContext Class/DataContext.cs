using Bussiness_Core.Entities;
using Bussiness_Core.EntitiesConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.DataContext_Class
{
   public class DataContext : IdentityDbContext<CustomIdentity>
   {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;

        }

        // Registration of Entity Classes in Database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<InternetNetwork>  InternetNetworks { get; set; }
        public DbSet<OperatingSystems> OperatingSystems { get; set; }
        public DbSet<OperatingSystemVersion>  OperatingSystemVersions { get; set; }
        public DbSet<Mobile>  Mobiles { get; set; }
        public DbSet<NetworksMobile> NetworksMobiles { get; set; }
        public DbSet<MobileFrontCamera> MobileFrontCameras { get; set; }
        public DbSet<MobileBackCamera> MobileBackCameras { get; set; }
        public DbSet<MobileImages>  MobileImages { get; set; }
        public DbSet<Carousel> Carousels { get; set; } 






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OSVersionConfiguration());
            modelBuilder.ApplyConfiguration(new MobileConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasKey(a => a.Category_Id);

        }

    }
}
