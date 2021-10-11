using AutoMapper;
using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using DataAccess.Data.DataContext_Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.UserOrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CSharp_Project_Levi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper mapper;
        private readonly IMobileService _MobileService;


        public UserOrderController(DataContext dataContext, IMapper mapper, IMobileService MobileService)
        {
            _dataContext = dataContext;
            _MobileService = MobileService;
            this.mapper = mapper;
        }


        [HttpPost("{userId}")]
        public async Task<IActionResult> AddingUserOrder(string userId, List<AddUserOrderDetailViewModel> listOrderDetailData)
        {

            // Checking Mobile Quantity 
            foreach (var OrderDetail in listOrderDetailData)
            {
                var gettingOrderMobileData = await _MobileService.GetMobile(OrderDetail.Mobile_Id);
                if(gettingOrderMobileData.Quantity < OrderDetail.Quantity)
                {
                    return BadRequest($"Sorry {gettingOrderMobileData.MobileName} mobile quantity does not available, Only can purchased {gettingOrderMobileData.Quantity}");
                }
            }

            // First Add the Order Table Data and Save it
            var orderAcceptData = new Order
            {
                CustomIdentityId = userId,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending",
            };
            await _dataContext.Orders.AddAsync(orderAcceptData);
            await _dataContext.SaveChangesAsync();

            // Second Add the its order Detail data
            var orderDetailData = new List<OrderDetail>();
            foreach (var OrderData in listOrderDetailData)
            {
                orderDetailData.Add(new OrderDetail{ Order_Id = orderAcceptData.OrderId,Mobile_Id = OrderData.Mobile_Id,
                    Quantity = OrderData.Quantity, TotalWithQuantityPrice = OrderData.TotalWithQuantityPrice});
            
                // Sending Email

                MailMessage msgObj = new MailMessage("abobakarpaen@gmail.com", OrderData.UserEmail);
                msgObj.Subject = "New Mobiles Home Delivery";
                msgObj.IsBodyHtml = true;
                msgObj.Body = @$"<h3>{OrderData.UserName},</h3><p>Your Order Has been Succeussfully Done!</p>  
                                  <p>Your Address is {OrderData.UserAddress},</p><p>Your Email Is: {OrderData.UserEmail}</p>
                                  <p>Your Product Name is {OrderData.ProductName} and Quantity is {OrderData.Quantity}</p>
                                   <p>Your Mobile Number Is: {OrderData.MobileNumber}</p><p>Your Order Date Was: {OrderData.OrderDate}</p><hr>
                                    <p>Your Total Amount of this Products Rs{OrderData.TotalWithQuantityPrice}</p>
                                   <h3>Thank You For Order and your Order Has been Succeussfully Done!</h3><p>Regards From <strong>New Mobiles Home Delivery</strong></p>";


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential() { UserName = "abobakarpaen@gmail.com", Password = "kzrcgwljcfpvbpko" };
                client.Send(msgObj);
            }
            await _dataContext.OrderDetails.AddRangeAsync(orderDetailData);
            await _dataContext.SaveChangesAsync();


            return Created($"{Request.Scheme://request.host}{Request.Path}/{listOrderDetailData[0].OrderDetailId}", listOrderDetailData);

        }

    }
}
