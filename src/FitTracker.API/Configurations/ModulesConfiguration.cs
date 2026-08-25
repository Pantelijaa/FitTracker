using FitTracker.Workouts.Infrastructure;

namespace FitTracker.API.Configurations
{
    public static class ModulesConfiguration
    {
        public static IServiceCollection ConfigureModules(this IServiceCollection services)
        {
            services.ConfigureWorkoutsModules();
            return services;
        }
    }
}
