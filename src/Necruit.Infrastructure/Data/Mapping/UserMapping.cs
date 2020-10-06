﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Necruit.Domain.Models;

namespace Necruit.Infrastructure.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.LastUpdateTime);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Location).HasMaxLength(250);
            builder.Property(x => x.MobilePhone).HasMaxLength(20);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);

            builder.HasMany(x => x.InterviewFeedbacks).WithOne(x => x.User).HasForeignKey("UserId");
            builder.HasMany(x => x.Talents).WithOne(x => x.Owner).HasForeignKey("UserId");
            builder.HasMany(x => x.Interviews).WithMany(x => x.Users);
        }
    }
}
