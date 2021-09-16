using MobileWorkerEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MobileWorkerEvents.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Event> Events { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
