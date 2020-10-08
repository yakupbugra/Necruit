using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Entities;

namespace Necruit.Infrastructure.Persistence.Configurations
{
    public class TalentConfiguration : IEntityTypeConfiguration<Talent>
    {
        public void Configure(EntityTypeBuilder<Talent> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.Property(x => x.Cv).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ExpectedSalary);
            builder.Property(x => x.IsInPool).IsRequired();
            builder.Property(x => x.Linkedin).HasMaxLength(250);
            builder.Property(x => x.Location).HasMaxLength(250);
            builder.Property(x => x.MobilePhone).HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Skype).HasMaxLength(250);

            builder.HasMany(x => x.Recruitments).WithOne(x => x.Talent).HasForeignKey("TalentId");
        }
    }
}