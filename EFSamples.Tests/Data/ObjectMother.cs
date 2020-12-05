using EFSamples.Data.Builders;

namespace EFSamples.Tests.Data
{
    public static class ObjectMother
    {
        public static class People
        {
            public static PersonBuilder Joe => new PersonBuilder().WithName("Joe Bloggs");
        }

        public static class Sessions
        {
            public static SubjectBuilder Session1 => new();
        }
    }
}
