using System;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Micro.EventBus.Redis
{
    public class RedisStore
    {
        private static Lazy<ConnectionMultiplexer> _lazyConnection;

        public RedisStore(IOptions<RedisOptions> redisOptions)
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                {
                    redisOptions.Value.Fqdn
                },
                Password = redisOptions.Value.Password
            };

            _lazyConnection =
                new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public ConnectionMultiplexer Connection => _lazyConnection.Value;

        public IDatabase RedisCache => Connection.GetDatabase();
    }

    public class RedisOptions
    {
        public string Fqdn { get; set; } = "127.0.0.1:6379";
        public string Password { get; set; } = "letmein";
    }
}
