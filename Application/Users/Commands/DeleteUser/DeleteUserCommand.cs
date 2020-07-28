using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoProject.Application.Common.Exceptions;
using DemoProject.Domain.Entities;

namespace DemoProject.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public string UserName { get; set; }

    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DeleteUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new NotFoundException();
            }

            await _userManager.DeleteAsync(user);

            return Unit.Value;
        }
    }
}

