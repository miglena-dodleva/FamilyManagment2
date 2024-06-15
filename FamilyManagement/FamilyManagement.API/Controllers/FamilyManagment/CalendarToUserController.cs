using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarToUserController : ControllerBase
    {
        private readonly ICalendarToUserService service;

        public CalendarToUserController(ICalendarToUserService service)
        {
            this.service = service;
        }

        // GET: api/<CalendarToUserController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var calendarToUsers = this.service.GetAllCalendarToUsers();

            return Ok(calendarToUsers);
        }

        // GET api/<CalendarToUserController>/5
        [HttpGet("calendarToUserById/{id}")]
        public IActionResult GetById(int id)
        {
            var calendarToUser = this.service.GetCalendarToUserById(id);

            if (calendarToUser == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = calendarToUser
            });
        }

        // POST api/<CalendarToUserController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] CalendarToUserModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var calendarToUser = this.service.CreateCalendarToUser(model);

            var id = calendarToUser.Id.ToString();

            return Created(id, calendarToUser);
        }

        // PUT api/<CalendarToUserController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] CalendarToUserModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var calendarToUser = this.service.EditCalendarToUser(model, id);
            if (calendarToUser == null)
            {
                return NotFound(calendarToUser);
            }

            return Ok(new
            {
                data = calendarToUser
            });
        }

        // DELETE api/<CalendarToUserController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var calendarToUser = this.service.DeleteCalendarToUser(id);

            return Ok(new
            {
                data = calendarToUser
            });
        }
    }
}
