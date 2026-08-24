using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Stakeholders.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Stakeholders.Infrastructure.Database
{
    public class StakeholdersUnitOfWork : UnitOfWork<StakeholdersContext>, IStakeholderUnitOfWork
    {
        public StakeholdersUnitOfWork(StakeholdersContext context) : base(context)
        {
        }
    }
}
