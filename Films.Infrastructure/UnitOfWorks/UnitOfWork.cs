using Films.Core.Domain.Entities;
using Films.Core.DomainServices.DatabaseContext;
using Films.Core.DomainServices.Repositories;
using Films.Core.DomainServices.UnitOfWorks;

namespace Films.Infrastructure.UnitOfWorks
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
