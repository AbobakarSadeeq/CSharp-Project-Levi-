using Bussiness_Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Presentation.ViewModels.Identity;
using Presentation.AppSettingClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace CSharp_Project_Levi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly UserManager<CustomIdentity> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentity> signInManger;
        private readonly ApplicationSettings _appSettings;
        public AccountController(UserManager<CustomIdentity> myuserManager,
            SignInManager<CustomIdentity> mysignIngManage, IOptions<ApplicationSettings> appSettings, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = myuserManager;
            _roleManager = roleManager;
            this.signInManger = mysignIngManage;
            this._appSettings = appSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel model)
        {
            var user = new CustomIdentity();
            var findingUserEntry = userManager.Users.ToList();
            var identityRole = new IdentityRole();
            if (findingUserEntry.Count == 0)
            {
                identityRole.Name = "User";
                await _roleManager.CreateAsync(identityRole);
            }
            var findingUser = await userManager.FindByNameAsync(model.UserName);
            if (findingUser == null)
            {
                user.UserName = model.UserName;
            }
            else
            {
                return BadRequest($"UserName Already in Use {model.UserName}");

            }
            var findingEmail = await userManager.FindByEmailAsync(model.Email);
            if (findingEmail == null)
            {
                user.Email = model.Email;
            }
            else
            {
                return BadRequest($"Email Already in Use {model.Email}");
            }
            var dataInserting = await userManager.CreateAsync(user, model.Password);
            IdentityResult result = null;
            if (dataInserting.Succeeded)
            {
                await signInManger.SignInAsync(user, isPersistent: false);

                if (!await userManager.IsInRoleAsync(user, "User"))
                {
                    result = await userManager.AddToRoleAsync(user, "User");
                }

                return Created($"{Request.Scheme://request.host}{Request.Path}/{model.Id}", model);
            }
            return BadRequest(dataInserting.Errors);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var roles = await userManager.GetRolesAsync(user);
                //HERE I USE THE CONDITION BECUASE WHENEVER USER HAVE NOT HAVING A ROLE IN A DATABASE THEN LOG HIM WITHOUT THE ROLE BUT HE/SHE NEED TO AUTHENTICATED OR REGISTAR FIRST
                if (roles.Count >= 1)
                {
                    IdentityOptions identityOptions = new IdentityOptions();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("UserID", user.Id.ToString()),
                    new Claim(identityOptions.ClaimsIdentity.RoleClaimType ,roles.FirstOrDefault())

                    }),
                        Expires = DateTime.UtcNow.AddDays(1), //the token will expire after the one day here
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);

                    return Ok(new { token, user.UserName, user.Email, user.Id });

                }
                else
                {
                    return BadRequest(new { message = "UserName or Password is Incorrect. Please Try Again" });
                }
                 
                   
            }
            return BadRequest("Something going Fishy!");

        }

        [HttpGet]
        [Authorize]
 
        public async Task<Object> GetUserProfile()
        {
             
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await userManager.FindByIdAsync(userId);
            var result = new
            {
                user.Id,
                user.UserName,
                user.Email,
            };
            return Ok(result);


        }
    }
}
