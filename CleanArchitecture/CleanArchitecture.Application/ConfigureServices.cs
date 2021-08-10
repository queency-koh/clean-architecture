using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
