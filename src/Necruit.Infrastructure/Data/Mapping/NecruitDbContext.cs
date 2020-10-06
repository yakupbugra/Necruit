using Microsoft.EntityFrameworkCore;
using Necruit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Necruit.Infrastructure.Data.Mapping
{
    public class NecruitDbContext : DbContext
    {
        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Recruitment> Recruitment { get; set; }
        public DbSet<RecruitmentStage> RecruitmentStage { get; set; }
        public DbSet<Talent> Talent { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
            modelBuilder.ApplyConfiguration(new InterviewFeedbackMapping());
            //modelBuilder.ApplyConfiguration(new InterviewMapping());
            //modelBuilder.ApplyConfiguration(new JobMapping());
            //modelBuilder.ApplyConfiguration(new RecruitmentMapping());
            //modelBuilder.ApplyConfiguration(new RecruitmentStageMapping());
            //modelBuilder.ApplyConfiguration(new TalentMapping());
            //modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
