using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Models;
using ToDoAppAPI.Services;

namespace ToDoAppAPI.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entities.Task>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public ActionResult AddTask([FromForm] TaskDto dto)
        {
            var taskId = _taskService.AddTask(dto);
            return Created($"/api/task/{taskId}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask([FromRoute] int id)
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateTask([FromForm] TaskDto dto, [FromRoute] int id)
        {
            _taskService.UpdateTask(dto, id);
            return Ok();
        }


    }
}
