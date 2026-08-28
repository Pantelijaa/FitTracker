using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Workouts.API.Dtos
{
    public class WorkoutCalendarDto
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public List<int> ExerciseIds { get; set; } // After exercise module is added it should store a list of exercise types instead of just ids
    }
}
