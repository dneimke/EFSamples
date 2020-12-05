using System;
using TestStack.Dossier;

namespace EFSamples.Data.Builders
{
    public class SubjectBuilder : TestDataBuilder<Subject, SubjectBuilder>
    {
        Subject _subject = new() { Id = Guid.NewGuid() };

        public SubjectBuilder() => Set(x => x.Id, Guid.NewGuid());

        public SubjectBuilder WithId(Guid id)
        {
            _subject.Id = id;
            return this;
        }

        public SubjectBuilder TaughtBy(Person user)
        {
            _subject.TaughtBy = user;
            return this;
        }
    }
}
