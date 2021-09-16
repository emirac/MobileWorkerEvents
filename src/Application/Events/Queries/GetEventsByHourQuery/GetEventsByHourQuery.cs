using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MobileWorkerEvents.Application.Common.Interfaces;
using MobileWorkerEvents.Application.Events.Queries.GetEventsCommand;

namespace MobileWorkerEvents.Application.Events.Queries.GetEventsByHourQuery
{
    public class GetEventsByHourQuery : IRequest<List<GroupedEventDto>>
    {
    }

    public class GetEventsByHourQueryHandler : IRequestHandler<GetEventsByHourQuery, List<GroupedEventDto>>
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH";
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetEventsByHourQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GroupedEventDto>> Handle(GetEventsByHourQuery request, CancellationToken cancellationToken)
        {
            var events = await this.context.Events
                .AsNoTracking()
                .ProjectTo<EventDto>(this.mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return events
                .GroupBy(e => new { DateHour = e.Date.ToString(DATE_FORMAT), e.Name, e.IsExpense })
                .Select(e => new GroupedEventDto()
                {
                    Date = e.Key.DateHour,
                    Name = e.Key.Name,
                    IsExpense = e.Key.IsExpense,
                    Events = e.ToList()
                })
                .ToList();
        }
    }
}
