using FitTracker.BuildingBlocks.Infrastrucutre.Database;
using FitTracker.Stakeholders.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Stakeholders.Infrastructure.Database
{
    public class StakeholderUnitOfWork : UnitOfWork<StakeholdersContext>, IStakeholderUnitOfWork
    {
        public StakeholderUnitOfWork(StakeholdersContext context) : base(context)
        {
        }
    }
}
