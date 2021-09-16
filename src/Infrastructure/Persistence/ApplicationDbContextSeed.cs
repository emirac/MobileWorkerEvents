using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileWorkerEvents.Domain.Entities;

namespace MobileWorkerEvents.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            var random = new Random();
            var date = DateTime.Now;
            var events = new List<Event>();

            for (var i = 0; i < 9; i++)
            {
                var group = i < 5 ? 1 : 2;
                var isExpense = i % 2 == 1 ? true : false;
                var testEvent = new Event()
                {
                    Date = date.AddHours(random.Next(1, 4)).AddMinutes(random.Next(-20, 20)),
                    Name = $"Test event {group}",
                    Quantity = random.Next(1, 100),
                    IsExpense = isExpense,
                    Price = isExpense ? random.Next(1, 100) : null
                };
                events.Add(testEvent);
            }

            context.Events.AddRange(events);
            await context.SaveChangesAsync();
        }
    }
}
