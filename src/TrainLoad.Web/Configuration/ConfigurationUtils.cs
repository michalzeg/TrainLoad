using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace StruCal.Infrastructure.Configuration
{
    public static class ConfigurationUtils
    {
        public static IConfiguration Create(string env, IEnumerable<KeyValuePair<string, string>> inMemoryConfig = null)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .AddInMemoryCollection(inMemoryConfig)
                .Build();
            return builder;
        }

        public static IConfiguration Create(IWebHostEnvironment env, IEnumerable<KeyValuePair<string, string>> inMemoryConfig = null) => Create(env.EnvironmentName, inMemoryConfig);

        public static IWebHostBuilder AddCommonConfiguration(this IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((host, config) =>
            {
                var cfg = Create(host.HostingEnvironment);
                config.AddConfiguration(cfg);
            });

            return builder;
        }
    }
}