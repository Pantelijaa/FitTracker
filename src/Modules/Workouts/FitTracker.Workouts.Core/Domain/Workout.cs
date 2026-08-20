using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.Workouts.Core.Domain
{
    public class Workout : Entity
    {
        public DateOnly Date { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public List<WorkoutExercise> Exercises { get; private set; } = new();

        public Workout()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            StartTime = TimeOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);
        }

        public Workout(DateOnly date, TimeOnly startTime, TimeOnly endTime)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
