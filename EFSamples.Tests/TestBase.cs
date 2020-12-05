using EFSamples.Tests.Helpers;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace EFSamples.Tests
{
    [Collection("Sequential")]
    public class TestBase : IAsyncLifetime, IClassFixture<ContainerFixture>, IClassFixture<DatabaseFixture>
    {
        protected readonly ContainerFixture _container;
        private DatabaseFixture _database;

        public TestBase(ContainerFixture fixture, DatabaseFixture database)
        {
            _container = fixture;
            _database = database;
        }

        [Fact]
        public virtual void ExecuteScenario() => this.BDDfy(GetType().Name);

        public Task InitializeAsync()
        {
            _database = new DatabaseFixture();
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            _container.Dispose();
            await _database.ResetAsync();
            _database.Dispose();
        }
    }
}
