﻿using EFSamples.Tests.Helpers;
using Shouldly;

namespace EFSamples.Tests
{
    public class Canary : TestBase
    {
        bool isExecuted = false;

        public Canary(ContainerFixture fixture, DatabaseFixture database) : base(fixture, database)
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