using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Services.Area.Common.Constants;
using SC.App.Services.Area.Common.Managers.Cache;

namespace SC.App.Services.Area.Configurations.Extensions
{
    public static class CachingExtension
    {
        public static void AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetValue<string>(AppSettings.Cache.Configuration);

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = config;
            });

            services.AddSingleton<IDistributedCacheManager, DistributedCacheManager>();
        }
    }
}