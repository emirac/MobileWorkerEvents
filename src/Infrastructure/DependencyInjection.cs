using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MobileWorkerEvents.Application.Common.Interfaces;
using MobileWorkerEvents.Infrastructure.Persistence;

namespace MobileWorkerEvents.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("MobileWorkerEventsDb"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}