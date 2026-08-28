using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Workouts.Core.Domain;
using FitTracker.Workouts.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FitTracker.Workouts.Infrastructure.Database.Repositories
{
    public class WorkoutDatabaseRepository : CrudDatabaseRepository<Workout, WorkoutsContext>, IWorkoutRepository
    {

        public WorkoutDatabaseRepository(WorkoutsContext context) : base(context)
        {
        }

        public Workout? GetAggregate(int id)
        {
            return DbContext.Workouts
                .Include(w => w.Exercises)
                    .ThenInclude(e => e.Sets)
                        .ThenInclude(s => s.ChangeHistory)
                .AsSplitQuery()
                .SingleOrDefault(w => w.Id == id);
        }

        public List<Workout> GetByTraineeId(int traineeId)
        {
            return DbContext.Workouts
                .Where(w => w.TraineeId == traineeId)
                .ToList();
        }

        public List<Workout> GetByTraineeInRange(int traineeId, DateOnly start, DateOnly end)
        {
            return DbContext.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.TraineeId == traineeId && w.Date >= start && w.Date <= end)
                .OrderBy(w => w.Date)
                .ToList();
        }
    }
}
