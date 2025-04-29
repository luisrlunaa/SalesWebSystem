using Microsoft.EntityFrameworkCore.Storage;

namespace SalesWebSystem.Infrastructure.Data.Contexts
{
    public class DataTransactionManager
    {
        protected readonly InvSysContext _context;
        private IDbContextTransaction _transaction;

        public DataTransactionManager(InvSysContext context)
        {
            _context = context;
        }

        protected async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        protected async Task<bool> CommitTransactionAsync()
        {
            try
            {
                var affected = await _context.SaveChangesAsync();
                if (affected <= 0)
                {
                    await RollbackTransactionAsync();
                    return false;
                }

                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }

                return true;
            }
            catch
            {
                await RollbackTransactionAsync();
                return false;
            }
        }

        protected async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}
