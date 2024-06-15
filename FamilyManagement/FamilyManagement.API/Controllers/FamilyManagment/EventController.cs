 using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;
        public EventController(IEventService service)
        {
            this.service = service;
        }

        // GET: api/<EventController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var events = this.service.GetAllEvents();

            return Ok(events);
        }

        // GET api/<EventController>/5
        [HttpGet("eventById/{id}")]
        public IActionResult GetById(int id)
        {
            var currentEvent = this.service.GetEventById(id);

            if (currentEvent == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = currentEvent
            });
        }

        // POST api/<EventController>
        [HttpPost("create")]
        public IActionResult Post([FromBody]  EventModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var newEvent = this.service.CreateEvent(model);

            var eventId = newEvent.Id.ToString();

            return Created(eventId, newEvent);
        }

        // PUT api/<EventController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] EventModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var currentEvent = this.service.EditEvent(model, id);
            if (currentEvent == null)
            {
                return NotFound(currentEvent);
            }

            return Ok(new
            {
                data = currentEvent
            });
        }

        // DELETE api/<EventController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var currentEvent = this.service.DeleteEvent(id);

            return Ok(new
            {
                data = currentEvent
            });
        }
    }
}
