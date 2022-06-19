using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI
{
    public class Seeder
    {
        private readonly ToDoAppDbContext _dbContext;

        public Seeder(ToDoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.TaskGroups.Any())
                {
                    var taskGroups = GetTaskGroups();
                    _dbContext.TaskGroups.AddRange(taskGroups);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Status.Any())
                {
                    var status = GetStatus();
                    _dbContext.Status.AddRange(status);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    FirstName = "Unassigned",
                    LastName = ""
                },

                new User()
                {
                    FirstName = "Marcin",
                    LastName = "Nowak"
                },

                new User()
                {
                    FirstName = "Mariusz",
                    LastName = "Kowalski"
                }
            };
            return users;
        }

        private IEnumerable<TaskGroup> GetTaskGroups()
        {
            var taskGroups = new List<TaskGroup>()
            {
                new TaskGroup()
                {
                    Name = "Backend"
                },
                new TaskGroup()
                {
                    Name = "Frontend"
                },
                new TaskGroup()
                {
                    Name = "Database"
                }
            };
            return taskGroups;
        }

        private IEnumerable<Status> GetStatus()
        {
            var status = new List<Status>()
            {
                new Status()
                {
                    Name = "New"
                },
                new Status()
                {
                    Name = "InProgress"
                },
                new Status()
                {
                    Name = "Completed"
                }
            };
            return status;
        }

    }
}