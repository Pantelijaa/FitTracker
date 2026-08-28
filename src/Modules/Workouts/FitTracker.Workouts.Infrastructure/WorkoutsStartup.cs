using AutoMapper;
using FitTracker.Workouts.API.Public;
using FitTracker.Workouts.Core.UseCases;
using FitTracker.Workouts.Core.Domain.RepositoryInterfaces;
using FitTracker.Workouts.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using FitTracker.Workouts.Core.Mappers;
using FitTracker.Workouts.Infrastructure.Database;

namespace FitTracker.Workouts.Infrastructure
{
    public static class WorkoutsStartup
    {
        public static IServiceCollection ConfigureWorkoutsModules(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(WorkoutProfile).Assembly);
            SetupCore(services);
            SetupInfrastucture(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
        }

        private static void SetupInfrastucture(IServiceCollection services)
        {
            services.AddScoped<IWorkoutRepository, WorkoutDatabaseRepository>();

            services.AddScoped<IWorkoutsUnitOfWork, WorkoutsUnitOfWork>();
        }
    }
}
