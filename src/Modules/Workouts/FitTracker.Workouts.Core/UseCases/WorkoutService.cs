using AutoMapper;
using FitTracker.Workouts.API.Dtos;
using FitTracker.Workouts.API.Public;
using FitTracker.Workouts.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Workouts.Core.UseCases
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        public WorkoutService(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public Result<List<WorkoutCalendarDto>> GetCalendar(int traineeId, int year, int month)
        {
            DateOnly from = new DateOnly(year, month, 1);
            DateOnly to = from.AddMonths(1).AddDays(-1);

            var workouts = _workoutRepository.GetByTraineeInRangeWithExercises(traineeId, from, to);

            var workoutDtos = _mapper.Map<List<WorkoutCalendarDto>>(workouts);

            return Result.Ok(workoutDtos);
        }

    }
}
