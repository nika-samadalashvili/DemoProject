using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Application.Phones.Commands.CreatePhone
{
    class CreatePhoneCommandValidator : AbstractValidator<CreatePhoneCommand>
    {
        public CreatePhoneCommandValidator()
        {
            RuleFor(v => v.ApplicationUserId)
                .NotEmpty();

            RuleFor(v => v.PhoneNumber).NotEmpty();
        }
    }
}
