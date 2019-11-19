using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USAEMS.ApiModels;
using USAEMS.Core.Models;
using USAEMS.Core.Services;

namespace USAEMS.Controllers
{
    //[Authorize(Roles = "SuperAdmin, Admin, Supervisor")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class AppUsersController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppUsersController(IAppUserService appUserService, IHttpContextAccessor httpContextAccessor)
        {
            _appUserService = appUserService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET api/appUsers
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public IActionResult Get()
        {
            try
            {
                // to return all AppUsers
                var userId = HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var currentUser = _appUserService.Get(userId);
                bool isSuperAdmin = HttpContext.User.IsInRole("SuperAdmin");
                var allAppUsers = _appUserService
                    .GetAll()
                    .Where(aU => isSuperAdmin ? true: aU.EmployerId == currentUser.EmployerId)
                    .ToApiModels();
                return Ok(allAppUsers);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetAppUsers", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/appUsers/{id}
        [HttpGet("{id}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Get(string id)
        {
            try
            {
                //to return an AppUser by id
                var appUser = _appUserService.Get(id);
                if (appUser == null) return NotFound();
                return Ok(appUser.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AppUsers", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/appUsers
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public IActionResult Post([FromBody] AppUser newAppUser)
        {
            try
            {
                return Ok(_appUserService.Add(newAppUser).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddAppUser", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/appUsers/{id}
        [HttpPut("{id}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Put(int id, [FromBody]AppUser updatedAppUser)
        {
            try
            {
                return Ok(_appUserService.Update(updatedAppUser).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateAppUser", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/appUsers/{id}
        [HttpDelete("{id}")]
        [EnableCors("AllowOrigin")]
        public IActionResult Delete(AppUser deleteAppUser)
        {
            try
            {
                _appUserService.Remove(deleteAppUser);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeletedAppUser", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}