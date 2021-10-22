using AutoMapper;
using Bussiness_Core.Entities;
using DataAccess.Data.DataContext_Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Project_Levi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminBalanceAccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper mapper;


        public AdminBalanceAccountController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            this.mapper = mapper;
        }

        // Adding the Balance to the account
        [HttpPost]
        public async Task<IActionResult> AddAccountBalance(AccountBalance accountData)
        {
            accountData.Modified_At = DateTime.Now;
            await _dataContext.AccountBalances.AddAsync(accountData);
            await _dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{accountData.BalanceAccountId}", accountData);
        }

        // Get the User Id First
        [HttpGet("GetLatestAccountDetail")]
        public async Task<IActionResult> GetLatestAccountDetail()
        {
            var getLastData = await _dataContext.AccountBalances.Include(a => a.User).OrderByDescending(a => a.BalanceAccountId).FirstOrDefaultAsync();
            if (getLastData == null)
            {
                return Ok("Not having any account balance");
            }
            var convertingData = new GetAccountBalanceViewModel();
            convertingData.UserName = getLastData.User.UserName;
            convertingData.Balance = getLastData.Balance;
            convertingData.Created_At = getLastData.Created_At;
            convertingData.Modified_At = getLastData.Modified_At;

            return Ok(convertingData);
        }

        // Update the balance of the account if admin want it but do not change the UserId here.
        [HttpPut]
        public async Task<IActionResult> UpdateAccountBalance(AccountBalance accountNewData)
        {
            var getLastData = await _dataContext.AccountBalances.OrderByDescending(a => a.BalanceAccountId).FirstOrDefaultAsync();
            getLastData.Balance = accountNewData.Balance;
            getLastData.Modified_At = DateTime.Now;
            await _dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{accountNewData.BalanceAccountId}", accountNewData);
        }

        // GetAll AccountBalance 
        [HttpGet]
        public async Task<IActionResult> GetAllAccountBalance()
        {
            var getAllData = await _dataContext.AccountBalances.Include(a => a.User).ToListAsync();
            var convertingData = new List<GetAccountBalanceViewModel>();
            foreach (var accountData in getAllData)
            {
                convertingData.Add(new GetAccountBalanceViewModel
                {
                    UserName = accountData.User.UserName,
                    Balance = accountData.Balance,
                    Created_At = accountData.Created_At,
                    Modified_At = accountData.Modified_At
                });
            }
            return Ok(convertingData);
        }
    }
}
