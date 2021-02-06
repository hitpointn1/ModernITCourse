using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModernITCourse.Services;
using System;

namespace ModernITCourse.Configuration
{
    public static partial class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            services.ConfigureDataSource(configuration);
            services.AddScoped<IInitService, InitService>();
            services.AddScoped<IUniversitiesService, UniversitiesService>();

            return services;
        }
    }
}
