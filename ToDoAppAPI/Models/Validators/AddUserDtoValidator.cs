using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ToDoAppAPI.Models.Validators
{
    public class AddUserDtoValidator : AbstractValidator<UserDto>
    {
        public AddUserDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
