using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Exceptions;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Services
{
    public interface ITaskGroupService
    {
        int AddTaskGroup(TaskGroupDto dto);
        bool UpdateTaskGroup(TaskGroupDto dto, int id);
    }

    public class TaskGroupService : ITaskGroupService
    {
        private readonly ToDoAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskGroupService(ToDoAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public int AddTaskGroup(TaskGroupDto dto)
        {
            var taskGroup = _mapper.Map<TaskGroup>(dto);
            taskGroup.Name = taskGroup.Name;
            _dbContext.TaskGroups.Add(taskGroup);
            _dbContext.SaveChanges();
            return taskGroup.Id;
        }

        public bool UpdateTaskGroup(TaskGroupDto dto, int id)
        {
            var taskGroup = _dbContext.TaskGroups.FirstOrDefault(x => x.Id == id);
            if (taskGroup == null)
            {
                throw new NotFoundException($"Task group {taskGroup} doesn't exist");
            }
            taskGroup.Name = dto.Name;
            _dbContext.TaskGroups.Update(taskGroup);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
