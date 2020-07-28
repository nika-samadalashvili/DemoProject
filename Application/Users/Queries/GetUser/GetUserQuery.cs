
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoProject.Application.Common.Exceptions;
using DemoProject.Application.Common.Interfaces;
using DemoProject.Domain.Entities;

namespace DemoProject.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<string>
    {
        public string PhoneNumber { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, string>
    {
        private readonly IApplicationDbContext _context;

        public GetUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Phones.Include(o => o.ApplicationUser)
                                            .Where(o => o.PhoneNumber == request.PhoneNumber)
                                            .Select(o => o.ApplicationUser.UserName).SingleOrDefaultAsync();

            if (string.IsNullOrEmpty(user))
            {
                throw new NotFoundException(nameof(ApplicationUser), request.PhoneNumber);
            }

            return user;
        }
    }
}
