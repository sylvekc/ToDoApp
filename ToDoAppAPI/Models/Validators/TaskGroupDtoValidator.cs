using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Models.Validators
{
    public class TaskGroupDtoValidator : AbstractValidator<TaskGroupDto>
    {
        public TaskGroupDtoValidator(ToDoAppDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().Custom((value, context) =>
            {
                var isGroupNameExist = dbContext.TaskGroups.Any(x => x.Name == value);
                if (isGroupNameExist)
                {
                    context.AddFailure("Name", $"Task group {value} already exist.");
                }

            });
        }
    }
}
