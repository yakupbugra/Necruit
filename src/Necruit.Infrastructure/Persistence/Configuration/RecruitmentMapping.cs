using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Entities;

namespace Necruit.Infrastructure.Persistence.Configuration
{
    public class RecruitmentMapping : IEntityTypeConfiguration<Recruitment>
    {
        public void Configure(EntityTypeBuilder<Recruitment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.HasMany(x => x.Interviews).WithOne(y => y.Recruitment);
        }
    }
}