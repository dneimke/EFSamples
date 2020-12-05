using EFSamples.Data;
using EFSamples.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;

namespace EFSamples.Tests.People
{
    public class CanCreateAPerson : TestBase
    {
        Person _user;

        public CanCreateAPerson(ContainerFixture fixture) : base(fixture)
        {

        }

        public void GivenAUserNamedJoe()
        {
            _user = Data.ObjectMother.People.Joe;
        }
        public async Task WhenJoeIsAddedToTheDatabase()
        {
            await _container.Db.AddAsync(_user);
            await _container.Db.SaveChangesAsync();
        }

        public async Task ThenJoeExistsInTheDatabase()
        {
            var user = await _container.Db.Users.FirstAsync(x => x.Id == _user.Id);
            user.ShouldNotBeNull();
        }
    }
}
