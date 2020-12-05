using EFSamples.Tests.Helpers;
using Shouldly;

namespace EFSamples.Tests
{
    public class Canary : TestBase
    {
        bool isExecuted = false;

        public Canary(ContainerFixture container) : base(container)
        {

        }

        public void GivenThereIsATest()
        {
            // 
        }

        public void WhenTheTestsAreExecuted()
        {
            isExecuted = true;
        }

        public void ThenTheTestIsRun()
        {
            // 
        }

        public void AndItPasses()
        {
            isExecuted.ShouldBeTrue();
        }
    }
}
