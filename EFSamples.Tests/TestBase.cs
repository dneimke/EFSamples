using EFSamples.Tests.Helpers;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace EFSamples.Tests
{
    [Collection("Sequential")]
    public class TestBase : IAsyncLifetime, IClassFixture<ContainerFixture>
    {
        protected readonly ContainerFixture _container;
       
        public TestBase(ContainerFixture fixture)
        {
            _container = fixture;
        }

        [Fact]
        public virtual void ExecuteScenario() => this.BDDfy(GetType().Name);

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task DisposeAsync()
        {
            await _container.DisposeAsync();
        }
    }
}
