using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModernITCourse.DataAccessLayer;
using System;

namespace ModernITCourse.Configuration
{
    public static partial class ServiceExtensions
    {
        public static IServiceCollection ConfigureDataSource(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseContext>(ConfigureOptions(configuration));
            return services;
        }

        internal static Action<DbContextOptionsBuilder> ConfigureOptions(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var connection = configuration.GetConnectionString(nameof(CourseContext));
            return o => o.UseSqlite(connection);
        }
    }
}
