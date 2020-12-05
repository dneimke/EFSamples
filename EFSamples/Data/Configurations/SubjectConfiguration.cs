using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFSamples.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");

            builder.HasOne(p => p.TaughtBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Participants)
              .WithMany(x => x.EnrolledSubjects);
        }
    }
}
