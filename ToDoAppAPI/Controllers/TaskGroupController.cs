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
    [Route("api/taskGroup")]

    public class TaskGroupController : ControllerBase
    {
        private readonly ITaskGroupService _taskGroupService;

        public TaskGroupController(ITaskGroupService taskGroupService)
        {
            _taskGroupService = taskGroupService;
        }
        [HttpPost]
        public ActionResult AddTaskGroup([FromForm]AddTaskGroupDto dto)
        {
            var taskGroupId = _taskGroupService.AddTaskGroup(dto);
            return Created($"/api/taskGroup/{taskGroupId}", null);
        }
    }
}
