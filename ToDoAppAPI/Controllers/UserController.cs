using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Models;
using ToDoAppAPI.Services;

namespace ToDoAppAPI.Controllers
{
    [Route("api/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult AddUser(UserDto dto)
        {
            _userService.AddUser(dto);
            return Ok();
        }


    }
}
