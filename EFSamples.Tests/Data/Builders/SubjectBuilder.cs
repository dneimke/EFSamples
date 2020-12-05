using System;
using TestStack.Dossier;

namespace EFSamples.Data.Builders
{
    public class SubjectBuilder : TestDataBuilder<Subject, SubjectBuilder>
    {
        Subject _subject = new() { Id = Guid.NewGuid() };

        public SubjectBuilder() 
            => Set(x => x.Id, Guid.NewGuid());

        public SubjectBuilder WithId(Guid id)
            => Set(x => x.Id, id);

        public SubjectBuilder IsTaughtBy(Person person)
            => Set(x => x.TaughtBy, person);
    }
}
