using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Models
{
    public class AddTaskDto
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int TaskGroupId { get; set; }
    }
}
