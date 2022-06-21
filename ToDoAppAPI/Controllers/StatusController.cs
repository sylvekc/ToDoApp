using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Controllers
{
    [Route("api/status")]
    public class StatusController : ControllerBase
    {
        private readonly ToDoAppDbContext _dbContext;

        public StatusController(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetStatus()
        {
            var status = _dbContext.Status.ToList();
            return Ok(status);
        }


    }
}
