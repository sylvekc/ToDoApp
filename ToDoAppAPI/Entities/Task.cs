using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppAPI.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Status { get; set; }
        public int TaskGroupId { get; set; }
        public virtual TaskGroup TaskGroup { get; set; }
    }
}
