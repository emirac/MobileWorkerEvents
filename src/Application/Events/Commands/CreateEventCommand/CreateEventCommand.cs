using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MobileWorkerEvents.Application.Common.Interfaces;
using MobileWorkerEvents.Domain.Entities;

namespace MobileWorkerEvents.Application.Events.Commands.CreateEventCommand
{
    public class CreateEventCommand : IRequest<int>
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public bool IsExpense { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, int>
    {
        private readonly IApplicationDbContext context;

        public CreateEventCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event()
            {
                Date = request.Date,
                Quantity = request.Quantity,
                Price = request.Price,
                Name = request.Name,
                IsExpense = request.IsExpense
            };

            this.context.Events.Add(newEvent);
            await this.context.SaveChangesAsync(cancellationToken);
            return newEvent.Id;
        }
    }
}
