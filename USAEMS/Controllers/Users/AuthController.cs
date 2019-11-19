using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using USAEMS.ApiModels;
using USAEMS.Core.Models;
using USAEMS.Core.Services;

namespace USAEMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;
        private readonly IConfiguration _config;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration, IAppUserService appUserService)
        {
            _userManager = userManager;
            _config = configuration;
            _appUserService = appUserService;
        }

        //POST api/auth/register
        [AllowAnonymous]
        [HttpPost("register")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Register([FromBody]RegistrationModel registration)
        {
            var newUser = new AppUser
            {
                UserName = registration.Email,
                Email = registration.Email,
                PhoneNumber = registration.PhoneNumber,
                CarrierId = registration.CarrierId,
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                EmployerId = registration.EmployerId
            };

            //use userManager to create a new AppUser. Pass in the password so it can be hashed.
            var result = await _userManager.CreateAsync(newUser, registration.Password);
            if (result.Succeeded)
            {
                return Ok(newUser.ToApiModel());
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        //POST api/auth/manageroles
        [Authorize (Roles = "SuperAdmin, Admin")]
        [HttpPost("manageroles")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> AddRoles([FromBody] UserRole userRole)
        {
            var user = _userManager.FindByIdAsync(userRole.UserId); var currentUserId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = _appUserService.Get(currentUserId);
            bool isSuperAdmin = HttpContext.User.IsInRole("SuperAdmin");
            
            if (isSuperAdmin == true)
            {
                var result = await _userManager.AddToRoleAsync(user.Result, userRole.RoleName);
                if (result.Succeeded)
                {
                    string message = message = user.Result.FullName + " has been added to " + userRole.RoleName + ".";
                    return Ok(message);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
            else if (currentUser.EmployerId == user.Result.EmployerId)
            {
                var result = await _userManager.AddToRoleAsync(user.Result, userRole.RoleName);
                if (result.Succeeded)
                {
                    string message = message = user.Result.FullName + " has been added to " + userRole.RoleName + ".";
                    return Ok(message);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
            else
            {
                return BadRequest();
            }
        }

        //POST api/auth/manageroles
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpDelete("manageroles")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> DeleteUserFromRole([FromBody] UserRole userRole)
        {
            var user = _userManager.FindByIdAsync(userRole.UserId);
            var currentUserId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = _appUserService.Get(currentUserId);
            bool isSuperAdmin = HttpContext.User.IsInRole("SuperAdmin");

            if(isSuperAdmin == true)
            {
                var result = await _userManager.RemoveFromRoleAsync(user.Result, userRole.RoleName);
                if (result.Succeeded)
                {
                    string message = message = user.Result.FullName + " has been removed from " + userRole.RoleName + ".";
                    return Ok(message);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
            else if(currentUser.EmployerId == user.Result.EmployerId)
            {
                var result = await _userManager.RemoveFromRoleAsync(user.Result, userRole.RoleName);
                if (result.Succeeded)
                {
                    string message = message = user.Result.FullName + " has been removed from " + userRole.RoleName + ".";
                    return Ok(message);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
            else
            {
                return BadRequest();
            }
        }

        //POST api/auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();

            //try to authenticate the user
            var user = await AuthenticateUserAsync(login.Email, login.Password);

            if (user != null)
            {
                //generate the JWT
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString, user });
            }

            return response;
        }

        private string GenerateJSONWebToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            //retrieve the secret key from configuration
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            
            //create signing credentials based on secret key
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            var roles = _userManager.GetRolesAsync(user).Result;
            var claims = new List<Claim>
            {
                //add Email to the token payload
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };
            
            //add role claims
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            //create the token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), //make the token valid for 7 days
                signingCredentials: credentials);

            //return the string representation of the token
            return tokenHandler.WriteToken(token);
        }

        private async Task<AppUser> AuthenticateUserAsync(string userName, string password)
        {
            //retrieve the user by username and then check password
            var user = await _userManager.FindByNameAsync(userName);
            if(user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }
    }
}