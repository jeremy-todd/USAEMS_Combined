using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USAEMS.ApiModels;
using USAEMS.Core.Models;
using USAEMS.Core.Services;

namespace USAEMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IAppUserService _appUserService;

        public EventsController(IEventService eventService, IAppUserService appUserService)
        {
            _eventService = eventService;
            _appUserService = appUserService;
        }

        // GET api/events
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // to return all events
                var allEvents = _eventService
                    .GetAll()
                    .ToApiModels();
                return Ok(allEvents);
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetEvents", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/events/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //to return an event by id
                var evt = _eventService.Get(id);
                if (evt == null) return NotFound();
                return Ok(evt.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetEvents", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/events
        [Authorize (Roles = "SuperAdmin, Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] Event newEvent)
        {
            try
            {
                return Ok(_eventService.Add(newEvent).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddEvent", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/events/{id}
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Event updatedEvent)
        {
            try
            {
                return Ok(_eventService.Update(updatedEvent).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateEvent", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/events/{id}
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Event deleteEvent)
        {
            try
            {
                _eventService.Remove(deleteEvent);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeletedEvent", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}