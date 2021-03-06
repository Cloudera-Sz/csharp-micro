using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Micro.Infrastructure.Domain;

namespace Micro.EventBus
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainEventBus(this IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Singleton<IDomainEventDispatcher, DomainEventDispatcher>());
            return services;
        }
    }
}
