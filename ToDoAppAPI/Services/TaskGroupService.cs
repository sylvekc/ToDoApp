using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Exceptions;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Services
{
    public interface ITaskGroupService
    {
        int AddTaskGroup(TaskGroupDto dto);
        void UpdateTaskGroup(TaskGroupDto dto, int id);
        void DeleteTaskGroup(int id);
        IEnumerable<TaskGroup> GetAllTaskGroups();
        TaskGroup GetTaskGroupById(int id);
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
            taskGroup.Name = dto.Name[0].ToString().ToUpper() + dto.Name.Substring(1);
            _dbContext.TaskGroups.Add(taskGroup);
            _dbContext.SaveChanges();
            return taskGroup.Id;
        }

        public void UpdateTaskGroup(TaskGroupDto dto, int id)
        {
            var taskGroup = _dbContext.TaskGroups.FirstOrDefault(x => x.Id == id);
            if (taskGroup == null)
            {
                throw new NotFoundException($"Task group with ID {id} not found");
            }
            taskGroup.Name = dto.Name;
            _dbContext.SaveChanges();
        }

        public void DeleteTaskGroup(int id)
        {
            var taskGroup = _dbContext.TaskGroups.FirstOrDefault(x => x.Id == id);
            if (taskGroup == null)
            {
                throw new NotFoundException($"Task group with ID {id} not found");
            }
            _dbContext.TaskGroups.Remove(taskGroup);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TaskGroup> GetAllTaskGroups()
        {
            var taskGroups = _dbContext.TaskGroups.Include(x => x.Tasks);
            return taskGroups;
        }

        public TaskGroup GetTaskGroupById(int id)
        {
            var taskGroup = _dbContext.TaskGroups.Include(x => x.Tasks).FirstOrDefault(x => x.Id == id);
            if (taskGroup is null)
            {
                throw new NotFoundException($"Task group with id {id} doesn't exist.");
            }

            return taskGroup;
        }

    }
}
