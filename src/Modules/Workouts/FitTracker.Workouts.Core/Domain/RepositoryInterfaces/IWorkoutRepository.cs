using FitTracker.BuildingBlocks.Core.UseCases;

namespace FitTracker.Workouts.Core.Domain.RepositoryInterfaces
{
    public interface IWorkoutRepository : ICrudRepository<Workout>
    {
        Workout? GetAggregate(int id);
        List<Workout> GetByTraineeId(int traineeId);
        List<Workout> GetByTraineeInRange(int traineeId, DateOnly start, DateOnly end);
    }
}
