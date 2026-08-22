using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.Workouts.Core.Domain
{
    public class Workout : Entity
    {
        public DateOnly Date { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public List<WorkoutExercise> Exercises { get; private set; } = new();
        public int TraineeId { get; private set; }

        public Workout()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            StartTime = TimeOnly.FromDateTime(DateTime.Now);
            EndTime = TimeOnly.FromDateTime(DateTime.Now);
            TraineeId = 0;
        }

        public Workout(DateOnly date, TimeOnly startTime, TimeOnly endTime, List<WorkoutExercise> exercises, int traineeId)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            Exercises = exercises;
            TraineeId = traineeId;
        }
    }
}
