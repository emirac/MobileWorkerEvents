using System;
using AutoMapper;
using MobileWorkerEvents.Application.Common.Mappings;
using MobileWorkerEvents.Domain.Entities;

namespace MobileWorkerEvents.Application.Events.Queries.GetEventsCommand
{
    public class EventDto : IMapFrom<Event>
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public double Total { get; set; }
        public string Name { get; set; }
        public bool IsExpense { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Total, e => e.MapFrom(e => e.IsExpense && e.Price.HasValue
                    ? e.Quantity * (double)e.Price
                    : e.Quantity))
                .ForMember(dest => dest.EventId, e => e.MapFrom(e => e.Id));
        }
    }
}
