using Microsoft.EntityFrameworkCore;
using MobileWorkerEvents.Application.Common.Interfaces;
using MobileWorkerEvents.Domain.Entities;

namespace MobileWorkerEvents.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Event> Events { get; set; }
    }
}
