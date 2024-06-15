using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using FamilyManagement.Services.Models.UserManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService service;
        public CalendarController(ICalendarService service)
        {
            this.service = service;
        }

        // GET: api/<CalendarController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var calendars = this.service.GetAllCalendars();

            return Ok(calendars);
        }

        // GET api/<CalendarController>/5
        [HttpGet("calendarById/{id}")]
        public IActionResult GetById(int id)
        {
            var calendar = this.service.GetCalendarById(id);

            if (calendar == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = calendar
            });
        }

        // POST api/<CalendarController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] CalendarModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var calendar = this.service.CreateCalendar(model);

            var calendarId = calendar.Id.ToString();

            return Created(calendarId, calendar);
        }

        // PUT api/<CalendarController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] CalendarModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var calendar = this.service.EditCalendar(model, id);
            if (calendar == null)
            {
                return NotFound(calendar);
            }

            return Ok(new
            {
                data = calendar
            });
        }

        // DELETE api/<CalendarController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var calendar = this.service.DeleteCalendar(id);

            return Ok(new
            {
                data = calendar
            });
        }
    }
}
