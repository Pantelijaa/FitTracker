namespace FitTracker.Workouts.API.Dtos
{
    public class ExerciseSetSnapshotDto
    {
        public int Repetitions { get; set; }
        public float Weight { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
