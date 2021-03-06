﻿using EFSamples.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EFSamples.Tests.Helpers
{
    public class ContainerFixture : IAsyncLifetime
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ServiceCollection _services;
        private readonly DatabaseFixture _database;

        public T GetService<T>() => _serviceProvider.GetService<T>();
        public SampleDbContext Db => GetService<SampleDbContext>();

        public ContainerFixture()
        {
            _services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true);
            _services.AddScoped<IConfiguration>(p => builder.Build());
            
            _database = new DatabaseFixture();
            _services.AddScoped(p => _database.DbContext);

            _serviceProvider = _services.BuildServiceProvider();
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public async Task DisposeAsync()
        {
            await _database.ResetAsync();
            _database.Dispose();
        }
    }
}
