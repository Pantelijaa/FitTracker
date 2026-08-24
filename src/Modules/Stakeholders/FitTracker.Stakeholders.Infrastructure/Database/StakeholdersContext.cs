using FitTracker.Stakeholders.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace FitTracker.Stakeholders.Infrastructure.Database
{
    public class StakeholdersContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        public StakeholdersContext(DbContextOptions<StakeholdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("stakeholders");
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        }
    }
}
