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
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public ActionResult AddTask([FromForm] AddTaskDto dto)
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
    }
}
