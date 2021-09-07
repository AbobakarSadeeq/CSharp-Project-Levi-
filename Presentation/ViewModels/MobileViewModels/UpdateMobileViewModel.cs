using Bussiness_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.MobileViewModels
{
   public class UpdateMobileViewModel
    {
        public int Mobile_Id { get; set; }
        public string MobileName { get; set; }
        public string Processor { get; set; }
        public string Storage { get; set; }
        public string BatteryMah { get; set; }
        public string Ram { get; set; }
        public string LaunchData { get; set; }
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
        public OperatingSystemVersion OperatingSystemVersion { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public List<NetworksMobile> networksMobiles { get; set; }
        public List<MobileFrontCamera> FrontCameras { get; set; }
        public List<MobileBackCamera> BackCameras { get; set; }
    }
}
