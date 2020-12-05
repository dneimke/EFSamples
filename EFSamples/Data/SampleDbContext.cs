using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFSamples.Data
{
    public class SampleDbContext : DbContext
    {

        public SampleDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
