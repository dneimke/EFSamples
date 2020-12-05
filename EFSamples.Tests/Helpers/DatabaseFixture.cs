using EFSamples.Data;
using Microsoft.EntityFrameworkCore;
using Respawn;
using System;
using System.Threading.Tasks;

namespace EFSamples.Tests.Helpers
{
    public class DatabaseFixture : IDisposable
    {
        private static readonly string ConnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Database=EFSample.Tests;Integrated Security=true";
        public SampleDbContext DbContext => GetDbContext();

        private static readonly Checkpoint Checkpoint = new()
        {
            TablesToIgnore = new[]
            {
                "__EFMigrationsHistory"
            },
            SchemasToExclude = Array.Empty<string>()
        };

        static DatabaseFixture()
        {
            using var dbContext = GetDbContext();
            dbContext.Database.Migrate();
        }

        public static SampleDbContext GetDbContext()
        {
            var connectionString = ConnectionString;

            var options = new DbContextOptionsBuilder<SampleDbContext>()
               .UseSqlServer(connectionString)
               .Options;

            return new SampleDbContext(options);
        }

        public async Task ResetAsync() => await Checkpoint.Reset(ConnectionString);

        public void Dispose() => DbContext.Dispose();
    }
}
