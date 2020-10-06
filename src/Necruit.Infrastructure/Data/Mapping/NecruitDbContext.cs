using Microsoft.EntityFrameworkCore;
using Necruit.Domain.Models;
using System.Reflection;

using Microsoft.EntityFrameworkCore.SqlServer;
namespace Necruit.Infrastructure.Data.Mapping
{
    public class NecruitDbContext : DbContext
    {
        public NecruitDbContext(DbContextOptions<NecruitDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString:"Server=DESKTOP-K5532TF;Database=Necruit;Integrated Security=True");
        }

        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Recruitment> Recruitment { get; set; }
        public DbSet<RecruitmentStage> RecruitmentStage { get; set; }
        public DbSet<Talent> Talent { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new InterviewMapping());
            modelBuilder.ApplyConfiguration(new JobMapping());
            modelBuilder.ApplyConfiguration(new RecruitmentMapping());
            modelBuilder.ApplyConfiguration(new RecruitmentStageMapping());
            modelBuilder.ApplyConfiguration(new TalentMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
