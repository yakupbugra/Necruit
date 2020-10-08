using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Entities;

namespace Necruit.Infrastructure.Persistence.Configurations
{
    public class RecruitmentStageConfiguration : IEntityTypeConfiguration<RecruitmentStage>
    {
        public void Configure(EntityTypeBuilder<RecruitmentStage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Order).IsRequired();
            builder.HasMany(x => x.Recruitments).WithOne(x => x.Stage).HasForeignKey("StageId");
        }
    }
}