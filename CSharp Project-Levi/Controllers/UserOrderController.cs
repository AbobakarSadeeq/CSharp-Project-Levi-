using AutoMapper;
using Bussiness_Core.Entities;
using Bussiness_Core.IServices;
using DataAccess.Data.DataContext_Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.ViewModels.UserOrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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

        [HttpGet]
        public async Task<IActionResult> GetAllUserOrders()
        {
            var gettingOrdersData = await _dataContext.Orders
                .Include(a => a.CustomIdentity)
                .ThenInclude(a => a.UserAddress)
                .ThenInclude(a => a.City)
                .ThenInclude(a => a.Country)
                .Include(a => a.OrderDetails)
                .ToListAsync();

            var convertDataToViewModel = new List<OrderUserAddressViewModel>();

            foreach (var listData in gettingOrdersData)
            {
                convertDataToViewModel.Add(new OrderUserAddressViewModel
                {
                    OrderId = listData.OrderId,
                    UserName = listData.CustomIdentity.UserName,
                    OrderStatus = listData.OrderStatus,
                    OrderDate = listData.OrderDate.ToString(),
                    CountryName = listData.CustomIdentity.UserAddress.City.Country.CountryName,
                    OrderItemsCount = listData.OrderDetails.Count
                });
            }
            return Ok(convertDataToViewModel);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> OrderDetails(int Id)
        {
            var gettingOrdersData = await _dataContext.Orders
              .Include(a => a.CustomIdentity)
              .ThenInclude(a => a.UserAddress)
              .ThenInclude(a => a.City)
              .ThenInclude(a => a.Country)
              .Include(a => a.OrderDetails)
              .ThenInclude(a => a.Mobile)
              .ThenInclude(a => a.Color)
              .FirstOrDefaultAsync(a => a.OrderId == Id);


            var convertDataToViewModel = new OrderDetailViewModel();
            convertDataToViewModel.OrderId = gettingOrdersData.OrderId;
            convertDataToViewModel.UserName = gettingOrdersData.CustomIdentity.UserName;
            convertDataToViewModel.Email = gettingOrdersData.CustomIdentity.Email;
            convertDataToViewModel.CompleteAddress = gettingOrdersData.CustomIdentity.UserAddress.CompleteAddress;
            convertDataToViewModel.CountryName = gettingOrdersData.CustomIdentity.UserAddress.City.CityName;
            convertDataToViewModel.CityName = gettingOrdersData.CustomIdentity.UserAddress.City.Country.CountryName;
            convertDataToViewModel.PhoneNumber = gettingOrdersData.CustomIdentity.UserAddress.PhoneNumber;
            convertDataToViewModel.OrderStatus = gettingOrdersData.OrderStatus;
            convertDataToViewModel.OrderDate = gettingOrdersData.OrderDate.ToString();
            convertDataToViewModel.ShippedDate = gettingOrdersData.ShippedDate.ToString();

                // Adding Its OrderDetails
                foreach (var item in gettingOrdersData.OrderDetails)
                {
                    convertDataToViewModel.OrderDetail.Add(new GetOrderDetailsDataViewModel
                    {
                        MobileId = item.Mobile_Id,
                        ProductName = item.Mobile.MobileName + " " + item.Mobile.Color.ColorName + " " + item.Mobile.Storage,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

            return Ok(convertDataToViewModel);
        }

        [HttpPut("AcceptOrder")]
        public async Task<IActionResult> AcceptOrder(ConfirmOrderViewModel viewModel)
        {
            // Finding the Order
            var findOrder = await _dataContext.Orders.FirstOrDefaultAsync(a => a.OrderId == viewModel.OrderId);
            findOrder.OrderStatus = "Shipped";
            findOrder.ShippedDate = DateTime.Now;
            _dataContext.SaveChanges();

            string multipleProductDataConcatinating = "";
            int noProduct = 1;
            int totalPrice = 0;
            

            foreach (var data in viewModel.OrderDetail)
            {
                
                var updateMobileData = await _MobileService.GetMobile(data.MobileId);
                updateMobileData.Quantity = updateMobileData.Quantity - data.Quantity;
                updateMobileData.SellUnits = updateMobileData.SellUnits + data.Quantity;
                if(updateMobileData.Quantity == 0)
                {
                    updateMobileData.StockAvailiability = false;
                }
                _dataContext.SaveChanges();

                // Sending Email for Accepting Order
                totalPrice = totalPrice + (data.Quantity * data.Price);
               var newData =  @$"<h3 style='text-decoration: underline;'>{viewModel.UserName},</h3><h3 style='text-decoration: underline;'>Product No: {noProduct},</h3><p>Your Order Has been Succeussfully Done!</p>  
                                 <p>Your Address is {viewModel.CompleteAddress},</p><p>Your Email Is: {viewModel.Email}</p>
                                  <p>Your Product Name is {data.ProductName} and Quantity is {data.Quantity}</p>
                                  <p>Your Mobile Number Is: {viewModel.PhoneNumber}</p><p>Your Order Date Was: {viewModel.OrderDate}</p><hr>
                                   <p><strong>Your Total Amount of this Products Rs{data.Price * data.Quantity}</strong></p>
                                   <h3>Thank You For Order and your Order Has been Succeussfully done and delivering tommarow!</h3><p>Regards From <strong>New Mobiles Home Delivery</strong></p><hr><br>";
                 multipleProductDataConcatinating = multipleProductDataConcatinating + newData;
                if(noProduct == viewModel.OrderDetail.Count)
                {
                    string extraMoreEmailInfo =  @$"<br><br><hr>
                    <h3 style = 'text-align: right; padding-right: 270px;' > TOTAL BILL = {totalPrice} </h3>";
                    multipleProductDataConcatinating = multipleProductDataConcatinating + extraMoreEmailInfo;
                }
                noProduct++;


                // Sending Email to the Admin if Quantity is less or equal to 5
                if (updateMobileData.Quantity <= 5)
                {
                    
                   

                    MailMessage emailMessage = new MailMessage("abobakarpaen@gmail.com", "abobakarpaen@gmail.com");
                    emailMessage.Subject = "New Mobiles Home Delivery";
                    emailMessage.IsBodyHtml = true;
                    emailMessage.Body = @$"
                        <h2 class='text-warning'>WARNING!</h2>
                        <h1>This product is less then 5 quantities remaining!</h1>
                        <p>Product Name is <strong> {data.ProductName} </strong> and Quantity is <strong> {data.Quantity} </strong> </p><hr>";


                    SmtpClient clientData = new SmtpClient("smtp.gmail.com", 587);
                    clientData.EnableSsl = true;
                    clientData.DeliveryMethod = SmtpDeliveryMethod.Network;
                    clientData.UseDefaultCredentials = false;
                    clientData.Credentials = new NetworkCredential() { UserName = "abobakarpaen@gmail.com", Password = "kzrcgwljcfpvbpko" };
                    clientData.Send(emailMessage);



                }







            }

            // Sending Email to the User that your order has been accepted

            var msgObj = new MailMessage("abobakarpaen@gmail.com", viewModel.Email);
            msgObj.Subject = "New Mobiles Home Delivery";
            msgObj.IsBodyHtml = true;
            msgObj.Body = multipleProductDataConcatinating;



            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential() { UserName = "abobakarpaen@gmail.com", Password = "kzrcgwljcfpvbpko" };
            client.Send(msgObj);

            // Add the Account Balance Or Modifing balance

            var getAccountData = await _dataContext.AccountBalances.OrderByDescending(a => a.BalanceAccountId).
                FirstOrDefaultAsync();

            if(getAccountData == null)
            {
                var convertAccountData = new AccountBalance();
                convertAccountData.Balance =  totalPrice;
                convertAccountData.User_ID = getAccountData.User_ID;
                convertAccountData.Created_At = DateTime.Now;
                await _dataContext.AccountBalances.AddAsync(convertAccountData);
                await _dataContext.SaveChangesAsync();
            }

            else
            {
                if (getAccountData.Created_At.Value.Month < DateTime.Now.Date.Month){

                var convertAccountData = new AccountBalance();
                convertAccountData.Balance = getAccountData.Balance + totalPrice;
                convertAccountData.User_ID = getAccountData.User_ID;
                convertAccountData.Created_At = DateTime.Now;

                await _dataContext.AccountBalances.AddAsync(convertAccountData);
                await _dataContext.SaveChangesAsync();
                }

                else{
                getAccountData.Balance = getAccountData.Balance + totalPrice;
                getAccountData.Modified_At = DateTime.Now;
                await _dataContext.SaveChangesAsync();
                }
            }













            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.OrderId}", viewModel);

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
                    Quantity = OrderData.Quantity, Price = OrderData.Price});

                // Sending Email

                MailMessage msgObj = new MailMessage("abobakarpaen@gmail.com", OrderData.UserEmail);
                msgObj.Subject = "New Mobiles Home Delivery";
                msgObj.IsBodyHtml = true;
                msgObj.Body = @$"<h3>{OrderData.UserName},</h3><p>Your Order Has been Succeussfully Done!</p>  
                                  <p>Your Address is {OrderData.UserAddress},</p><p>Your Email Is: {OrderData.UserEmail}</p>
                                  <p>Your Product Name is {OrderData.ProductName} and Quantity is {OrderData.Quantity}</p>
                                   <p>Your Mobile Number Is: {OrderData.MobileNumber}</p><p>Your Order Date Was: {OrderData.OrderDate}</p><hr>
                                    <p>Your Total Amount of this Products Rs{OrderData.Price * OrderData.Quantity}</p>
                                   <h3>Thank You For Order and your Order Has been on Pending!</h3><p>Regards From <strong>New Mobiles Home Delivery</strong></p>";


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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var findingOrderId = await _dataContext.Orders.Include(a=>a.CustomIdentity).Include(a=>a.OrderDetails).FirstOrDefaultAsync(a=>a.OrderId == Id);
            findingOrderId.OrderStatus = "Canceled";
            await _dataContext.SaveChangesAsync();
            MailMessage msgObj = new MailMessage("abobakarpaen@gmail.com", findingOrderId.CustomIdentity.Email);
            msgObj.Subject = "New Mobiles Home Delivery";
            msgObj.IsBodyHtml = true;
            msgObj.Body = @$"<h1>Dear {findingOrderId.CustomIdentity.UserName},</h1>
            <p>We would like to cancel our order vide purchase order number <strong>{findingOrderId.OrderId}</strong> dated <strong>{findingOrderId.OrderDate}</strong> and number of product <strong>{findingOrderId.OrderDetails.Count}</strong> We apologize for the same.</p>
            <p>Our warehouse manager, who was on leave for a long time, has joined back this week. He has informed us that we have sufficient stock of the ordered goods in our warehouse,
            which would last for next months. Therefore, we have to request you to cancel the order immediately.</p>
            <p>I hope this does not cause too much of an inconvenience to you.</p>
            <p>Thank you for your understanding in the matter!</p>
            <p><strong>Regards,</strong></p>
            <p>{findingOrderId.CustomIdentity.UserName}</p>
            <p><strong>New Mobiles Home Delivery</strong></p>";


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential() { UserName = "abobakarpaen@gmail.com", Password = "kzrcgwljcfpvbpko" };
            client.Send(msgObj);


            return Ok();
        }


        // Orders Chart Graph Data
        [HttpGet("OrdersChart")]
        public async Task<IActionResult> OrdersChart()
        {

            var monthtOrders = new List<int>();


            for (int month = 1; month <= 12; month++)
            {
                var shippedData = await _dataContext.Orders.Where(a => a.ShippedDate.Value.Date.Month == month).ToListAsync();
                if(shippedData.Count == 0)
                {
                    monthtOrders.Add(0);
                }
                else
                {
                    monthtOrders.Add(shippedData.Count);
                }

            }


            return Ok(monthtOrders);
        }

        [HttpGet("GetSingleUserOrder/{userId}")]
        public async Task<IActionResult> GetSingleUserOrder(string userId)
        {
            var getSingleUserOrders = await _dataContext.Orders
              .Include(a => a.CustomIdentity)
               .ThenInclude(a => a.UserAddress)
               .ThenInclude(a => a.City)
               .ThenInclude(a => a.Country)
               .Include(a => a.OrderDetails)
              .Where(a => a.CustomIdentityId == userId)
              .ToListAsync();
            var convertDataToViewModel = new List<OrderUserAddressViewModel>();

            foreach (var listData in getSingleUserOrders)
            {
                convertDataToViewModel.Add(new OrderUserAddressViewModel
                {
                    OrderId = listData.OrderId,
                    UserName = listData.CustomIdentity.UserName,
                    OrderStatus = listData.OrderStatus,
                    OrderDate = listData.OrderDate.ToString(),
                    CountryName = listData.CustomIdentity.UserAddress.City.Country.CountryName,
                    OrderItemsCount = listData.OrderDetails.Count
                });
            }


            return Ok(convertDataToViewModel);
        }

        // Deleting Complete Order By User until admin didnt accept it
        [HttpDelete("DeleteOrderByUser/{Id}")]
        public async Task<IActionResult> DeleteOrderByUser(int Id)
        {
            var findingOrderById = await _dataContext.Orders.FirstOrDefaultAsync(a => a.OrderId == Id);
            findingOrderById.OrderStatus = "Canceled";
            await _dataContext.SaveChangesAsync();
            return Ok();
        }




    }
}
