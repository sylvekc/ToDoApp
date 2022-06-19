using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Models;
using ToDoAppAPI.Services;

namespace ToDoAppAPI.Controllers
{
    [Route("api/taskGroup")]
    [ApiController]

    public class TaskGroupController : ControllerBase
    {
        private readonly ITaskGroupService _taskGroupService;

        public TaskGroupController(ITaskGroupService taskGroupService)
        {
            _taskGroupService = taskGroupService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskGroup>> GetAllTaskGroups()
        {
            var taskGroups = _taskGroupService.GetAllTaskGroups();
            return Ok(taskGroups);
        }

        [HttpPost]
        public ActionResult AddTaskGroup(TaskGroupDto dto)
        {
            var taskGroupId = _taskGroupService.AddTaskGroup(dto);
            return Created($"/api/taskGroup/{taskGroupId}", null);
        }

        [HttpPatch("{id}")]
        public ActionResult ChangeTaskGroupName([FromForm]TaskGroupDto dto, [FromRoute]int id)
        {
            _taskGroupService.UpdateTaskGroup(dto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGroupName([FromRoute] int id)
        {
            _taskGroupService.DeleteTaskGroup(id);
            return NoContent();
        }

     
    }
}
