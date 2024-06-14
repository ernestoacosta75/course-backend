using Films.Domain.DatabaseContext;
using Films.Domain.Entities;
using Films.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Films.Domain.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FilmsDbContext _dbContext;
        private bool _disposed = false;
        public IRepository<Gender> GenderRepository { get; private set; }

        public UnitOfWork(FilmsDbContext dbContext)
        {
            _dbContext = dbContext;
            GenderRepository = new Repository<Gender>(dbContext);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
