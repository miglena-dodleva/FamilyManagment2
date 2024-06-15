using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListService service;
        public ToDoListController(IToDoListService service)
        {
            this.service = service;
        }

        // GET: api/<ToDoListController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var toDoLists = this.service.GetAllToDoLists();

            return Ok(toDoLists);
        }

        // GET api/<ToDoListController>/5
        [HttpGet("toDoListById/{id}")]
        public IActionResult GetById(int id)
        {
            var toDoLists = this.service.GetToDoListById(id);

            if (toDoLists == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = toDoLists
            });
        }

        // POST api/<ToDoListController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] ToDoListModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var toDoList = this.service.CreateToDoList(model);

            var toDoListId = toDoList.Id.ToString();

            return Created(toDoListId, toDoList);
        }

        // PUT api/<ToDoListController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] ToDoListModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var toDoList = this.service.EditToDoList(model, id);
            if (toDoList == null)
            {
                return NotFound(toDoList);
            }

            return Ok(new
            {
                data = toDoList
            });
        }

        // DELETE api/<ToDoListController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var toDoList = this.service.DeleteToDoList(id);

            return Ok(new
            {
                data = toDoList
            });
        }
    }
}
