using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Stakeholders.Core.Domain;
using FitTracker.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Stakeholders.Infrastructure.Database.Repositories
{
    public class TrainerDatabaseRepository : CrudDatabaseRepository<Trainer, int>, ITrainerRepository
    {
    }
}
