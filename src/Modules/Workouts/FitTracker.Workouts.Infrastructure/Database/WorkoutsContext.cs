using FitTracker.Workouts.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Workouts.Infrastructure.Database
{
    public class WorkoutsContext : DbContext
    {

        public DbSet<Workout> Workouts { get; set; }

        public WorkoutsContext(DbContextOptions<WorkoutsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("workouts");

            modelBuilder.Entity<Workout>(builder =>
            {
                builder.HasKey(w => w.Id);

                builder.Property(w => w.Date)
                    .IsRequired();
                builder.Property(w => w.StartTime)
                    .IsRequired();
                builder.Property(w => w.EndTime)
                    .IsRequired();

                builder.HasMany(w => w.Exercises)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<WorkoutExercise>(builder =>
            {
                builder.HasKey(we => we.Id);

                builder.Property(we => we.ExerciseId)
                    .IsRequired();

                builder.HasMany(we => we.Sets)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ExerciseSet>(builder =>
            {
                builder.HasKey(es => es.Id);

                builder.Property(es => es.Repetitions)
                    .IsRequired();

                builder.Property(es => es.Weight)
                    .IsRequired();

                builder.OwnsMany(s => s.ChangeHistory, snapshot =>
                {
                    snapshot.ToTable("ExerciseSetSnapshots");
                    snapshot.WithOwner().HasForeignKey("ExerciseSetId");
                    snapshot.Property(sn => sn.Repetitions)
                        .IsRequired();
                    snapshot.Property(sn => sn.Weight)
                        .IsRequired();
                    snapshot.Property(sn => sn.ChangedAt)
                        .IsRequired();
                });
            });
        }
    }
}
