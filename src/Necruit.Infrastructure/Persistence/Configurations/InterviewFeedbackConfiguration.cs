using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Entities;

namespace Necruit.Infrastructure.Persistence.Configurations
{
    public class InterviewFeedbackConfiguration : IEntityTypeConfiguration<InterviewFeedback>
    {
        public void Configure(EntityTypeBuilder<InterviewFeedback> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.Property(x => x.Rating);
        }
    }
}