using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Stakeholders.Core.Domain;
using FitTracker.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace FitTracker.Stakeholders.Infrastructure.Database.Repositories
{
    public class TraineeDatabaseRepository : CrudDatabaseRepository<Trainee, StakeholdersContext>, ITraineeRepository
    {
        public TraineeDatabaseRepository(StakeholdersContext context) : base(context)
        {
        }
    }
}
