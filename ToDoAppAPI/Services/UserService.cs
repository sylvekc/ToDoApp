using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Models;

namespace ToDoAppAPI.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        void AddUser(UserDto dto);

    }

    public class UserService : IUserService
    {
        private readonly ToDoAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ToDoAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = _dbContext.Users.Include(x => x.Tasks);
            return users;
        }

        public void AddUser(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
