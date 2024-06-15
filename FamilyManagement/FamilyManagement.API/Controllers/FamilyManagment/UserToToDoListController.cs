using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{

    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserToToDoListController : ControllerBase
    {
        private readonly IUserToToDoListService service;

        public UserToToDoListController(IUserToToDoListService service)
        {
            this.service = service;
        }

        // GET: api/<UserToToDoListController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var userToToDoLists = this.service.GetAllUserToToDoLists();

            return Ok(userToToDoLists);
        }

        // GET api/<UserToToDoListController>/5
        [HttpGet("userToToDoListById/{id}")]
        public IActionResult GetById(int id)
        {
            var userToToDoList = this.service.GetUserToToDoListById(id);

            if (userToToDoList == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = userToToDoList
            });
        }

        // POST api/<UserToToDoListController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] UserToToDoListModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var userToToDoList = this.service.CreateUserToToDoList(model);

            var id = userToToDoList.Id.ToString();

            return Created(id, userToToDoList);
        }

        // PUT api/<UserToToDoListController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] UserToToDoListModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var userToToDoList = this.service.EditUserToToDoList(model, id);
            if (userToToDoList == null)
            {
                return NotFound(userToToDoList);
            }

            return Ok(new
            {
                data = userToToDoList
            });
        }

        // DELETE api/<UserToToDoListController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var userToToDoList = this.service.DeleteUserToToDoList(id);

            return Ok(new
            {
                data = userToToDoList
            });
        }
    }
}
