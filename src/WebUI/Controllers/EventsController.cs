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
        public async Task<ActionResult<List<EventDto>>> GetEvents([FromQuery] GetEventsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("eventsByHour")]
        public async Task<ActionResult<List<GroupedEventDto>>> GetEventsByHour([FromQuery] GetEventsByHourQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
