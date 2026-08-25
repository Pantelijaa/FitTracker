namespace FitTracker.Workouts.API.Dtos
{
    public class WorkoutExerciseDto
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public List<ExerciseSetDto> Sets { get; set; }
    }
}
