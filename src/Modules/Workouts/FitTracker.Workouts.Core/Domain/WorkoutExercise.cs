using FitTracker.BuildingBlocks.Core.Domain;

namespace FitTracker.Workouts.Core.Domain
{
    public class WorkoutExercise : Entity
    {
        public int ExerciseId { get; private set; }
        public List<ExerciseSet> Sets { get; private set; } = new();

        public WorkoutExercise() { }
        public WorkoutExercise(int exerciseId)
        {
            ExerciseId = exerciseId;
        }
    }
}
