using Microsoft.Extensions.DependencyInjection;

namespace FitTracker.Workouts.Infrastructure
{
    public static class WorkoutsStartup
    {
        public static IServiceCollection ConfigureWorkoutsModules(this IServiceCollection services)
        {

            SetupCore(services);
            SetupInfrastucture(services);
            return services;
        }

        private static void SetupCore(IServiceCollection services)
        {
            // Register core services here
        }

        private static void SetupInfrastucture(IServiceCollection services)
        {
            // Register infrastructure repositories here
        }
    }
}
