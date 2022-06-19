using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Exceptions;
using ToDoAppAPI.Models;
using Task = ToDoAppAPI.Entities.Task;

namespace ToDoAppAPI.Services
{
    public interface ITaskService
    {
        int AddTask(TaskDto dto);
        void DeleteTask(int id);
        IEnumerable<Entities.Task> GetAllTasks();
        void UpdateTask(TaskDto dto, int id);
    }

    public class TaskService : ITaskService
    {
        private readonly ToDoAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(ToDoAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int AddTask(TaskDto dto)
        {
            var task = _mapper.Map<Entities.Task>(dto);
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return task.Id;
        }

        public void DeleteTask(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                throw new NotFoundException($"Task with ID {id} not found");
            }
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Entities.Task> GetAllTasks()
        {
            var tasks = _dbContext.Tasks;
            return tasks;
        }

        public void UpdateTask(TaskDto dto, int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            
            if (task == null)
            {
                throw new NotFoundException($"Task with ID {id} not found");
            }

            task.Status = dto.Status;
            task.Deadline = dto.Deadline;
            task.Description = dto.Description;
            task.TaskGroupId = dto.TaskGroupId;
            task.UserId = dto.UserId;

            _dbContext.SaveChanges();
        }

    }
}
