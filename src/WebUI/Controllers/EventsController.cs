using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MobileWorkerEvents.Application.Events.Commands.CreateEventCommand;
using MobileWorkerEvents.Application.Events.Queries.GetEventsByHourQuery;
using MobileWorkerEvents.Application.Events.Queries.GetEventsCommand;
using MobileWorkerEvents.Application.Events.Queries.GetEventsQuery;

namespace MobileWorkerEvents.WebUI.Controllers
{
    public class EventsController : ApiControllerBase
    {
        [HttpPost("event")]
        public async Task<ActionResult<int>> Create(CreateEventCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("events")]
        public async Task<ActionResult<List<EventDto>>> GetEvents()
        {
            return await Mediator.Send(new GetEventsQuery());
        }

        [HttpGet("eventsByHour")]
        public async Task<ActionResult<List<GroupedEventDto>>> GetEventsByHour()
        {
            return await Mediator.Send(new GetEventsByHourQuery());
        }
    }
}
