using Microsoft.Extensions.DependencyInjection;

namespace Micro.Infrastructure.Features
{
    public static class FeatureExtensions
    {
        public static void AddFeatureToggle(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IFeature), typeof(Feature));
        }
    }
}
