using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoProject.Application.Common.Exceptions;
using DemoProject.Domain.Entities;

namespace DemoProject.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.Users.AnyAsync(o => o.UserName == request.UserName))
            {
                throw new ValidationException();
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName
            };

            var identityResult = await _userManager.CreateAsync(user, request.Password);

            if (identityResult.Succeeded)
            {
                return user.Id;
            }

            IEnumerable<T> Yield<T>(T data) { yield return data; }

            throw new ValidationException
            {
                Errors = identityResult.Errors.ToDictionary(o => o.Code, o => Yield(o.Description).ToArray())
            };
        }
    }
}
