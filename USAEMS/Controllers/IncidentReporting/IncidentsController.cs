using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USAEMS.ApiModels;
using USAEMS.Core.Models;
using USAEMS.Core.Services;

namespace USAEMS.Controllers
{
    [Authorize (Roles = "SuperAdmin, Admin, IncidentSubmit")]
    [Route("api/[controller]")]
    public class IncidentsController : Controller
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        // GET api/incidents
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // to return all incidents
                var allIncidents = _incidentService
                    .GetAll()
                    .ToApiModels();
                return Ok(allIncidents);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetIncidents", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/incidents/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //to return an incident by id
                var incident = _incidentService.Get(id);
                if (incident == null) return NotFound();
                return Ok(incident.ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetIncidents", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/incidents
        [HttpPost]
        public IActionResult Post([FromBody] Incident newIncident)
        {
            try
            {
                return Ok(_incidentService.Add(newIncident).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddIncident", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/incidents/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Incident updatedIncident)
        {
            try
            {
                return Ok(_incidentService.Update(updatedIncident).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateIncident", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/incidents/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Incident deleteIncident)
        {
            try
            {
                _incidentService.Remove(deleteIncident);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeletedIncident", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}