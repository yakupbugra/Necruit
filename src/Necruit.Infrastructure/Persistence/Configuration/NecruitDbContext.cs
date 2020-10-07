using Microsoft.EntityFrameworkCore;
using Necruit.Domain.Entities;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Necruit.Infrastructure.Persistence.Configuration
{
    public class NecruitDbContext : DbContext
    {
        public NecruitDbContext(DbContextOptions<NecruitDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString: "Server=DESKTOP-K5532TF;Database=Necruit;Integrated Security=True");
        }

        public DbSet<Interview> Interview { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Recruitment> Recruitment { get; set; }
        public DbSet<RecruitmentStage> RecruitmentStage { get; set; }
        public DbSet<Talent> Talent { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateTime = DateTime.Now;
                        entry.Entity.LastUpdateTime = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastUpdateTime = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}