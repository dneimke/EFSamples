using EFSamples.Data;
using EFSamples.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;
using static EFSamples.Tests.Data.ObjectMother;

namespace EFSamples.Tests.Users
{
    public class CanCreateAPerson : TestBase
    {
        Person _user;

        public CanCreateAPerson(ContainerFixture fixture, DatabaseFixture database) : base(fixture, database)
        {

        }

        public void GivenAUserNamedJoe()
        {
            _user = People.Joe;
        }
        public async Task WhenJoeIsAddedToTheDatabase()
        {
            await _container.Db.AddAsync(_user);
            await _container.Db.SaveChangesAsync();
        }

        public void ThenJoeExistsInTheDatabase()
        {
            var user = _container.Db.Users.FirstAsync(x => x.Id == _user.Id);
            user.ShouldNotBeNull();
        }
    }
}
