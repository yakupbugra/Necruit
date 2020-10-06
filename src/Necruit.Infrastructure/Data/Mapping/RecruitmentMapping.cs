using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Models;

namespace Necruit.Infrastructure.Data.Mapping
{
    public class RecruitmentMapping : IEntityTypeConfiguration<Recruitment>
    {
        public void Configure(EntityTypeBuilder<Recruitment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.Property(x => x.Stage);
            builder.HasMany(x => x.Interviews).WithOne(y => y.Recruitment);

        }
    }
}
