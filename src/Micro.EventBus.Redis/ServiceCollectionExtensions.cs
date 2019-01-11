using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Micro.EventBus.Redis
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisBus(this IServiceCollection services)
        {
            var resolver = services.BuildServiceProvider();
            using (var scope = resolver.CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();
                var redisOptions = config.GetSection("Features:Redis");

                services.Configure<RedisOptions>(o =>
                {
                    o.Fqdn = redisOptions.GetValue<string>("FQDN");
                    o.Password = redisOptions.GetValue<string>("Password");
                });

                services.AddSingleton<RedisStore>();
                services.AddSingleton<IDispatchedEventBus, DispatchedEventBus>();
                return services;
            }
        }
    }
}
