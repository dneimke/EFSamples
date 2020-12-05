using EFSamples.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFSamples
{

    class Program
    {

        static IServiceProvider _serviceProvider;
        static ServiceCollection _services;
        static IConfigurationRoot Configuration;

        public static T GetService<T>() => _serviceProvider.GetService<T>();

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true);
            Configuration = builder.Build();

            _services = new ServiceCollection();
            var connectionString = Configuration.GetConnectionString("Database");
            _services.AddDbContext<SampleDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            _services.AddScoped<IConfiguration>(p => Configuration);
            _serviceProvider = _services.BuildServiceProvider();

            var db = GetService<SampleDbContext>();
            db.Database.Migrate();

            Console.WriteLine("Running...");
        }
    }
}
