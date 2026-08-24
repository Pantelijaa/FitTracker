using FluentResults;
using Microsoft.EntityFrameworkCore;
using FitTracker.BuildingBlocks.Core.UseCases;
using Microsoft.EntityFrameworkCore.Storage;




namespace FitTracker.BuildingBlocks.Infrastrucutre.Database
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
            _transaction ??= _dbContext.Database.BeginTransaction();
        }

        public Result Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return Result.Ok();
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        public Result Commit()
        {
            if (_transaction is null) 
                return Result.Fail("No transaction to commit.");

            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
            return Result.Ok();
        }

        public Result Rollback()
        {
            if ( _transaction is null)
                return Result.Fail("No transaction to rollback.");

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
            return Result.Ok();
        }
    }
}
