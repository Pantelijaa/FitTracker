namespace FitTracker.Workouts.API.Dtos
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int TraineeId { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
    }
}
