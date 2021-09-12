using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_Core.Entities
{
   public class Mobile
    {
        public int Mobile_Id { get; set; }
        public string MobileName{ get; set; }
        public string Processor { get; set; }
        public string Storage { get; set; }
        public string BatteryMah { get; set; }
        public string Ram { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LaunchDate { get; set; }
        public string MobileWeight { get; set; }
        public string ScreenSize { get; set; }
        public string ScreenType { get; set; }
        public string Charger { get; set; }
        public string Resolution { get; set; }
        public string HeadPhoneJack { get; set; }
        public string Bluetooth { get; set; }
        public string Wifi { get; set; }
        public string USBConnector { get; set; }
        //Relationship Between Tables:
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int OSVersionId { get; set; }
        public  OperatingSystemVersion OperatingSystemVersion { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }


        // Navigation Properties
        public ICollection<NetworksMobile> NetworksMobiles { get; set; }
        public ICollection<MobileFrontCamera>  MobileFrontCameras { get; set; }
        public ICollection<MobileBackCamera>  MobileBackCameras { get; set; }
        public ICollection<MobileImages> MobileImagess { get; set; }


        //Mobile Price
        public int MobilePrice { get; set; }
        public int SellUnits { get; set; }
        public bool StockAvailiability { get; set; }
        public int Quantity { get; set; }
     
        public DateTime? Created_At { get; set; } = DateTime.Now;
        public DateTime? Modified_At { get; set; } 

        public Mobile()
        {
            NetworksMobiles = new HashSet<NetworksMobile>();
            MobileFrontCameras = new HashSet<MobileFrontCamera>();
            MobileBackCameras = new HashSet<MobileBackCamera>();
            MobileImagess = new HashSet<MobileImages>();
        }
        //Mobiles Images

    }
}
