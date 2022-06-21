using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Models;
using Task = System.Threading.Tasks.Task;

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

                if (!_dbContext.Tasks.Any())
                {
                    var tasks = GetTasks();
                    _dbContext.Tasks.AddRange(tasks);
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

        private IEnumerable<Entities.Task> GetTasks()
        {
            var tasks = new List<Entities.Task>()
            {
                new Entities.Task()
                {
                    UserId = 2,
                    Description = "Add validators",
                    Status = "New",
                    TaskGroupId = 1,
                    Deadline = new DateTime(2022-7-12)
                },
                new Entities.Task()

                {
                    UserId = 3,
                    Description = "Add new components",
                    Status = "New",
                    TaskGroupId = 2,
                    Deadline = new DateTime(2022-7-14)
                },

                new Entities.Task()
                {
                    UserId = 3,
                    Description = "Add new features",
                    Status = "InProgress",
                    TaskGroupId = 2,
                    Deadline = new DateTime(2022-7-19)
                },

                new Entities.Task()
                {
                    UserId = 2,
                    Description = "Add new queries",
                    Status = "Completed",
                    TaskGroupId = 3,
                    Deadline = new DateTime(2022-8-11)
                },

                new Entities.Task()
                {
                    UserId = 2,
                    Description = "Add new functions",
                    Status = "New",
                    TaskGroupId = 3,
                    Deadline = new DateTime(2022-6-30)
                },

                new Entities.Task()
                {
                    UserId = 2,
                    Description = "Check if everything is working",
                    Status = "InProgress",
                    TaskGroupId = 3,
                    Deadline = new DateTime(2022-12-12)
                },
            };
            return tasks;
        }

    }
}