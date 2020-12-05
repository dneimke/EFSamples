using EFSamples.Data;
using EFSamples.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;

namespace EFSamples.Tests.Subjects
{
    public class CanCreateASubject : TestBase
    {
        Subject _subject;
        Subject _result;
        Person _joe;

        public CanCreateASubject(ContainerFixture fixture, DatabaseFixture database) : base(fixture, database)
        {
            _joe = Data.ObjectMother.People.Joe.Build();
        }

        public void GivenASubjectThatIsTaughtByJoe()
        {
            _subject = Data.ObjectMother.Subjects.Maths.IsTaughtBy(_joe);
        }

        public async Task WhenTheSubjectIsAddedToTheDatabase()
        {
            await _container.Db.AddAsync(_subject);
            await _container.Db.SaveChangesAsync();
        }

        public async Task ThenItExistsInTheDatabase()
        {
            _result = await _container.Db.Subjects.Include(x => x.TaughtBy).FirstAsync(x => x.Id == _subject.Id);
            _result.ShouldNotBeNull();
        }

        public void AndJoeShouldBeTheTeacher()
        {
            _result.TaughtBy.Id.ShouldBe(_joe.Id);
        }
    }
}
