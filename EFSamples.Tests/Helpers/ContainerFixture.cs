using EFSamples.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EFSamples.Tests.Helpers
{
    public class ContainerFixture : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ServiceCollection _services;

        public T GetService<T>() => _serviceProvider.GetService<T>();
        public SampleDbContext Db => GetService<SampleDbContext>();

        public ContainerFixture()
        {
            _services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true);

            var configuration = builder.Build();

            _services.AddScoped<IConfiguration>(p => configuration);
            _services.AddScoped(p => DatabaseFixture.GetDbContext());

            _serviceProvider = _services.BuildServiceProvider();
        }

        public void Dispose()
        {
            // clean-up
        }
    }
}
