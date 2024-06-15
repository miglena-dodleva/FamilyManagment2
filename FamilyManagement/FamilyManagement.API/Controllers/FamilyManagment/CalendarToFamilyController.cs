using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarToFamilyController : ControllerBase
    {
        private readonly ICalendarToFamilyService service;

        public CalendarToFamilyController(ICalendarToFamilyService service)
        {
            this.service = service;
        }

        // GET: api/<CalendarToFamilyController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var calendarToFamilies = this.service.GetAllCalendarToFamilies();

            return Ok(calendarToFamilies);
        }

        // GET api/<CalendarToFamilyController>/5
        [HttpGet("calendarToFamilyById/{id}")]
        public IActionResult GetById(int id)
        {
            var calendarToFamily = this.service.GetCalendarToFamilyById(id);

            if (calendarToFamily == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = calendarToFamily
            });
        }

        // POST api/<CalendarToFamilyController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] CalendarToFamilyModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var calendarToFamily = this.service.CreateCalendarToFamily(model);

            var id = calendarToFamily.Id.ToString();

            return Created(id, calendarToFamily);
        }

        // PUT api/<CalendarToFamilyController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] CalendarToFamilyModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var calendarToFamily = this.service.EditCalendarToFamily(model, id);
            if (calendarToFamily == null)
            {
                return NotFound(calendarToFamily);
            }

            return Ok(new
            {
                data = calendarToFamily
            });
        }

        // DELETE api/<CalendarToFamilyController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var calendarToFamily = this.service.DeleteCalendarToFamily(id);

            return Ok(new
            {
                data = calendarToFamily
            });
        }
    }
}
