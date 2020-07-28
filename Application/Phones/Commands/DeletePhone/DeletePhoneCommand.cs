using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoProject.Application.Common.Exceptions;
using DemoProject.Application.Common.Interfaces;
using DemoProject.Domain.Entities;

namespace DemoProject.Application.Phones.Commands.DeletePhone
{
    public class DeletePhoneCommand : IRequest
    {
        public string PhoneNumber { get; set; }
    }

    public class DeletePhoneCommandHandler : IRequestHandler<DeletePhoneCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePhoneCommandHandler (IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePhoneCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Phones.FindAsync(request.PhoneNumber);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Phone), request.PhoneNumber);
            }

            _context.Phones.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
