using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Services
{
    public interface ITaskGroupService
    {
        int AddTaskGroup(AddTaskGroupDto dto);
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


        public int AddTaskGroup(AddTaskGroupDto dto)
        {
            var taskGroup = _mapper.Map<TaskGroup>(dto);
            taskGroup.Name = dto.Name;
            _dbContext.TaskGroups.Add(taskGroup);
            _dbContext.SaveChanges();
            return taskGroup.Id;
        }


    }
}
