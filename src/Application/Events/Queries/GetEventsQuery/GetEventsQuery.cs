using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileWorkerEvents.Application.Common.Interfaces;
using MobileWorkerEvents.Application.Events.Queries.GetEventsCommand;

namespace MobileWorkerEvents.Application.Events.Queries.GetEventsQuery
{
    public class GetEventsQuery : IRequest<List<EventDto>>
    {
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, List<EventDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await this.context.Events
                .AsNoTracking()
                .ProjectTo<EventDto>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
