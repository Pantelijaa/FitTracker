using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Workouts.Core.Domain;
using FitTracker.Workouts.Core.Domain.RepositoryInterfaces;

namespace FitTracker.Workouts.Infrastructure.Database.Repositories
{
    public class WorkoutDatabaseRepository : CrudDatabaseRepository<Workout, WorkoutsContext>, IWorkoutRepository
    {

        public WorkoutDatabaseRepository(WorkoutsContext context) : base(context)
        {
        }
    }
}
