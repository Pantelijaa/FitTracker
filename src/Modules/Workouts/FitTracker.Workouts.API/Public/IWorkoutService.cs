using FitTracker.Workouts.API.Dtos;
using FluentResults;

namespace FitTracker.Workouts.API.Public
{
    public interface IWorkoutService
    {
        Result<List<WorkoutCalendarDto>> GetCalendar(int traineeId, int year, int month);
    }
}
