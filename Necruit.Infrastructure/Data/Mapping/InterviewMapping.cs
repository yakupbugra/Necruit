using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Models;

namespace Necruit.Infrastructure.Data.Mapping
{
    public class InterviewMapping : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.EndTime);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);
            builder.Property(x => x.StartTime);
            builder.HasMany(x => x.Interviewers).WithMany(y => y.Interviews);

           
        }
    }
}
