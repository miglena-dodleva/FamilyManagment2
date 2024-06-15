using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using Microsoft.AspNetCore.Mvc;

namespace FamilyManagement.API.Controllers.FamilyManagment
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service;
        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        // GET: api/<TaskController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var tasks = this.service.GetAllTasks();

            return Ok(tasks);
        }

        // GET api/<TaskController>/5
        [HttpGet("taskById/{id}")]
        public IActionResult GetById(int id)
        {
            var task = this.service.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                data = task
            });
        }

        // POST api/<TaskController>
        [HttpPost("create")]
        public IActionResult Post([FromBody] TaskModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var task = this.service.CreateTask(model);

            var taskId = task.Id.ToString();

            return Created(taskId, task);
        }

        // PUT api/<TaskController>/5
        [HttpPatch("edit/{id}")]
        public IActionResult Put(int id, [FromBody] TaskModel model)
        {
            var isModelStateValid = ModelState.IsValid;

            if (!isModelStateValid)
            {
                return NotFound();
            }

            var task = this.service.EditTask(model, id);
            if (task == null)
            {
                return NotFound(task);
            }

            return Ok(new
            {
                data = task
            });
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var task = this.service.DeleteTask(id);

            return Ok(new
            {
                data = task
            });
        }
    }
}
