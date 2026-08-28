using AutoMapper;
using FitTracker.Workouts.API.Dtos;
using FitTracker.Workouts.Core.Domain;

namespace FitTracker.Workouts.Core.Mappers
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutDto>().ReverseMap();
            CreateMap<Workout, WorkoutCalendarDto>().ReverseMap();

            CreateMap<WorkoutExercise, WorkoutExerciseDto>().ReverseMap();

            CreateMap<ExerciseSet, ExerciseSetDto>().ReverseMap();

            CreateMap<ExerciseSetSnapshot, ExerciseSetSnapshotDto>().ReverseMap();
        }
    }
}
