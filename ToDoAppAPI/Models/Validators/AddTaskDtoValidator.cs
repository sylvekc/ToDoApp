using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToDoAppAPI.Entities;

namespace ToDoAppAPI.Models.Validators
{
    public class AddTaskDtoValidator : AbstractValidator<AddTaskDto>
    {
       
        private string[] possibleStatus = new[] { "New", "InProgress", "Completed" };

        public AddTaskDtoValidator(ToDoAppDbContext dbContext)
        {
            RuleFor(x => x.Deadline).GreaterThan(DateTime.Now);
            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Status).Must(value => possibleStatus.Contains(value))
                .WithMessage($"Status must be in [{string.Join(", ", possibleStatus)}]");

            RuleFor(x => x.TaskGroupId).Custom((value, context) =>
            {
                var isTaskGroupIdExist = dbContext.TaskGroups.Any(x => x.Id == value);
                if (!isTaskGroupIdExist)
                {
                    context.AddFailure("TaskGroupId",$"Task group with id {value} doesn't exist.");
                }
            });

            RuleFor(x => x.UserId).Custom((value, context) =>
            {
                var isUserIdExist = dbContext.Users.Any(x => x.Id == value);
                if (!isUserIdExist)
                {
                    context.AddFailure("UserId",$"User with Id {value} doesn't exist.");
                }
            });
        }
    }
}
