using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Models;

namespace ToDoAppAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskGroupDto, TaskGroup>();
            CreateMap<TaskDto, Entities.Task>();
            CreateMap<UserDto, User>();
        }
    }
}
