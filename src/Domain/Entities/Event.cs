using System;

namespace MobileWorkerEvents.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public string Name { get; set; }
        public bool IsExpense { get; set; }
    }
}
