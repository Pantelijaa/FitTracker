using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Workouts.Core.UseCases;


namespace FitTracker.Workouts.Infrastructure.Database
{
    public class WorkoutsUnitOfWork : UnitOfWork<WorkoutsContext>, IWorkoutsUnitOfWork
    {
        public WorkoutsUnitOfWork(WorkoutsContext context) : base(context)
        {
        }
    }
}
