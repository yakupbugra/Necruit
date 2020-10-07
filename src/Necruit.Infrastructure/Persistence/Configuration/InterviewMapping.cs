using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Entities;

namespace Necruit.Infrastructure.Persistence.Configuration
{
    public class InterviewMapping : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.Property(x => x.EndTime);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.StartTime);
            builder.HasMany(x => x.Users).WithMany(y => y.Interviews);
            builder.HasMany(x => x.InterviewFeedbacks).WithOne(x => x.Interview).HasForeignKey("InterviewId");
        }
    }
}