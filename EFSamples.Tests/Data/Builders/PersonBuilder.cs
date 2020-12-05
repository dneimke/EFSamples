using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.Dossier;

namespace EFSamples.Data.Builders
{
    public class PersonBuilder : TestDataBuilder<Person, PersonBuilder>
    {
        private readonly List<Subject> _subjects = new();

        public PersonBuilder() => Set(x => x.Id, Guid.NewGuid());

        public PersonBuilder WithId(Guid id)
        {
            return Set(x => x.Id, id);
        }

        public PersonBuilder WithName(string name)
        {
            return Set(x => x.Name, name);
        }

        public PersonBuilder WithEmailAddress(string emailAddress)
        {
            return Set(x => x.Email, emailAddress);
        }

        public PersonBuilder EnrolledIn(params Subject[] subjects)
        {
            _subjects.AddRange(subjects);
            return this;
        }

        protected override Person BuildObject()
        {
            Person user = new()
            {
                Id = Get(x => x.Id),
                Name = Get(x => x.Name),
                Email = Get(x => x.Email)
            };

            if(_subjects.Any())
            {
                user.EnrolledSubjects.AddRange(_subjects);
            }

            return user;
        }
    }
}
