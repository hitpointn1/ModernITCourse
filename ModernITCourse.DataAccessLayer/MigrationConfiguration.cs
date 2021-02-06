using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ModernITCourse.DataAccessLayer
{
    internal static class MigrationConfiguration
    {
        static MigrationConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            IsBuildForMigrations = Convert.ToBoolean(Configuration[nameof(IsBuildForMigrations)]);
        }

        internal static IConfiguration Configuration { get; set; }
        internal static bool IsBuildForMigrations { get; set; }
    }
}
