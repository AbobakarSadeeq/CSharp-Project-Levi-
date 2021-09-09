using Bussiness_Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.MobileViewModels
{
   public class ImageInsertingViewModel
    {
        public int MobileImages_Id { get; set; }
        // when we want to Insert photo then we should send some properties to the API not All photo Detail.
        public string URL { get; set; }
         // Photo that we want to uploading and it will be send with HTTP request.
        public string PublicId { get; set; }
        public int MobileId { get; set; }
        public Mobile Mobile { get; set; }

    }
}
