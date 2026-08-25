namespace FitTracker.Workouts.API.Dtos
{
    public class ExerciseSetDto
    {
        public int Id { get; set; }
        public int Repetitions { get; set; }
        public float Weight { get; set; }
        public List<ExerciseSetSnapshotDto> ChangeHistory { get; set; } = new();
    }
}
