using AutoMapper;
using Bussiness_Core.Entities;
using DataAccess.Data.DataContext_Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<CustomIdentity> _userManager;
        private readonly SignInManager<CustomIdentity> signInManger;

        public EmployeeController(DataContext dataContext, IMapper mapper, SignInManager<CustomIdentity> signInManger, RoleManager<IdentityRole> roleManager, UserManager<CustomIdentity> userManager)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this._roleManager = roleManager;
            this._userManager = userManager;
            this.signInManger = signInManger;

        }




        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var getEmployees = await dataContext.Employees.ToListAsync();
            var convertingViewModel = mapper.Map<List<EmployeeViewModel>>(getEmployees);
            return Ok(convertingViewModel);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            var getEmployee = await dataContext.Employees.Include(a => a.User).SingleOrDefaultAsync(a=>a.EmployeeId == Id);
            var convertingViewModel = mapper.Map<EmployeeViewModel>(getEmployee);
            return Ok(convertingViewModel);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {

            var gettingEmployeeId = await dataContext.Employees.SingleOrDefaultAsync(a => a.EmployeeId == Id);
            var gettingEmployeeMonthlyData = await dataContext.EmployeeMonthlyPayments.SingleOrDefaultAsync(a => a.Employee_ID == Id);
            dataContext.Employees.Remove(gettingEmployeeId);
            dataContext.EmployeeMonthlyPayments.Remove(gettingEmployeeMonthlyData);
            await dataContext.SaveChangesAsync();
            var findingUserId = await _userManager.FindByIdAsync(gettingEmployeeId.User_ID);
            await _userManager.DeleteAsync(findingUserId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromForm] CreateEmployeeViewModel viewModel)
        {
            var customIdentity = new CustomIdentity
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email
            };

            var findingUser = await _userManager.FindByNameAsync(viewModel.UserName);
            if (findingUser == null)
            {
                customIdentity.UserName = viewModel.UserName;
            }
            else
            {
                return BadRequest($"UserName Already in Use {viewModel.UserName}");

            }
            var findingEmail = await _userManager.FindByEmailAsync(viewModel.Email);
            if (findingEmail == null)
            {
                customIdentity.Email = viewModel.Email;
            }
            else
            {
                return BadRequest($"Email Already in Use {viewModel.Email}");
            }

            var addingUser = await _userManager.CreateAsync(customIdentity, viewModel.UserPassword);
            IdentityResult result = null;
            if (addingUser.Succeeded)
            {
                if (!await _userManager.IsInRoleAsync(customIdentity, viewModel.RoleName))
                {
                    result = await _userManager.AddToRoleAsync(customIdentity, viewModel.RoleName);
                }
            }
            // AddingEmployee
            var convertingData = new Employee
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DathOfBirth = viewModel.DathOfBirth,
                PhoneNumber = viewModel.PhoneNumber,
                HomeAddress = viewModel.HomeAddress,
                Salary = viewModel.Salary,
                Gender = viewModel.Gender,
                EmployeeHireDate = viewModel.EmployeeHireDate,
                User_ID = customIdentity.Id,
                RoleName = viewModel.RoleName
                
            };

            await dataContext.Employees.AddAsync(convertingData);
            await dataContext.SaveChangesAsync();

            // Addning Employee Monthly Payment
            var employeePayment = new EmployeeMonthlyPayment
            {
                Payment = false,
                Payment_At = null,
                Employee_ID = convertingData.EmployeeId
            };
            await dataContext.EmployeeMonthlyPayments.AddAsync(employeePayment);
            await dataContext.SaveChangesAsync();

            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.EmployeeId}", viewModel);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromForm]  UpdateEmployeeViewModel viewModel)
        {
            var findingEmployeeOldData = await dataContext.Employees.SingleOrDefaultAsync(a=>a.EmployeeId == viewModel.EmployeeId);
            findingEmployeeOldData.FirstName = viewModel.FirstName;
            findingEmployeeOldData.LastName = viewModel.LastName;
            findingEmployeeOldData.DathOfBirth = viewModel.DathOfBirth;
            findingEmployeeOldData.PhoneNumber = viewModel.PhoneNumber;
            findingEmployeeOldData.HomeAddress = viewModel.HomeAddress;
            findingEmployeeOldData.Salary = viewModel.Salary;
            findingEmployeeOldData.Gender = viewModel.Gender;
            findingEmployeeOldData.EmployeeHireDate = viewModel.EmployeeHireDate;
            findingEmployeeOldData.User_ID = findingEmployeeOldData.User_ID;
            findingEmployeeOldData.Modified_At = DateTime.Now;
            IdentityResult result = null;
            var user = await _userManager.FindByIdAsync(findingEmployeeOldData.User_ID);
            if (await _userManager.IsInRoleAsync(user, findingEmployeeOldData.RoleName))
            {
                await _userManager.RemoveFromRoleAsync(user, findingEmployeeOldData.RoleName);
                await _userManager.AddToRoleAsync(user, viewModel.NewRoleName);
            }
            findingEmployeeOldData.RoleName = viewModel.NewRoleName;

            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.EmployeeId}", viewModel);

        }

        [HttpPut("UpdateEmployeePayment")]
        public async Task<IActionResult> UpdateEmployeePayment(EmployeeMonthlyPaymentViewModel viewModel)
        {
            var gettingEmployeePaymentOldData = await dataContext.EmployeeMonthlyPayments.SingleOrDefaultAsync(a => a.EmployeeMonthlyPaymentId == viewModel.EmployeeMonthlyPaymentId);
            gettingEmployeePaymentOldData.Payment = viewModel.Payment;
            gettingEmployeePaymentOldData.Payment_At = DateTime.Now;
            await dataContext.SaveChangesAsync();
            return Created($"{Request.Scheme://request.host}{Request.Path}/{viewModel.EmployeeMonthlyPaymentId}", viewModel);

        }

        [HttpGet("GetEmployeesPayment")]
        public async Task<IActionResult> GetAllEmployeePayment()
        {
            var gettingAllData = await dataContext.EmployeeMonthlyPayments.Include(a=>a.Employee).ToListAsync();
            var convertingViewModel = mapper.Map<List<EmployeeMonthlyPaymentViewModel>>(gettingAllData);
            return Ok(convertingViewModel);

        }


    }
}
