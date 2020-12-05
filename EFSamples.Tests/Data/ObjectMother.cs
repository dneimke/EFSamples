using EFSamples.Data.Builders;
using System;

namespace EFSamples.Tests.Data
{
    public static class ObjectMother
    {
        public static class People
        {
            public static PersonBuilder Joe => new PersonBuilder()
                .WithId(Guid.Parse("d88325b0-7920-484e-9be8-55aabfb1e43f"))
                .WithName("Joe Bloggs");
        }

        public static class Subjects
        {
            public static SubjectBuilder Maths => new SubjectBuilder()
                .WithId(Guid.Parse("804bcc5c-4c1c-476a-9cfa-b775b127fd17"));
        }
    }
}
