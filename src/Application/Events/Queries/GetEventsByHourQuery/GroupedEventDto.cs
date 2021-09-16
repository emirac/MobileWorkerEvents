using System;
using System.Collections.Generic;
using MobileWorkerEvents.Application.Events.Queries.GetEventsCommand;

namespace MobileWorkerEvents.Application.Events.Queries.GetEventsByHourQuery
{
    public class GroupedEventDto
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public bool IsExpense { get; set; }
        public List<EventDto> Events { get; set; }
    }
}
