using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DemoProject.Application.Common.Interfaces;

namespace DemoProject.Application.Phones.Queries.GetPhones
{
    public class GetPhonesQuery : IRequest<IList<PhoneDto>>
    {
        public string ApplicaitonUserId { get; set; }
    }

    public class GetPhonesQueryHandler : IRequestHandler<GetPhonesQuery, IList<PhoneDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPhonesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<PhoneDto>> Handle(GetPhonesQuery request, CancellationToken cancellationToken)
        {
            var vm = new PhoneDto();

            var phones = await _context.Phones.Where(o => o.ApplicationUserId == request.ApplicaitonUserId)
                                              .ProjectTo<PhoneDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return phones;
        }
    }
}
