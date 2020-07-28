using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoProject.Application.Common.Exceptions;
using DemoProject.Application.Common.Interfaces;
using DemoProject.Domain.Entities;

namespace DemoProject.Application.Phones.Commands.CreatePhone
{
    public class CreatePhoneCommand : IRequest<int>
    {
        public string ApplicationUserId { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePhoneCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.Phones.FirstOrDefaultAsync(o => o.ApplicationUserId == request.ApplicationUserId && o.PhoneNumber == request.PhoneNumber);

            if (entity != null) {
                throw new ValidationException();
            }

            entity = new Phone
            {
                ApplicationUserId = request.ApplicationUserId,
                PhoneNumber = request.PhoneNumber
            };

            _context.Phones.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
