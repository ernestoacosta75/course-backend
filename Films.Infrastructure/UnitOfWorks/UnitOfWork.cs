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
        public IRepository<Gender> GenderRepository { get; }
        public IRepository<Actor> ActorRepository { get; }

        public UnitOfWork(FilmsDbContext dbContext, IRepository<Gender> genderRepository, IRepository<Actor> actorRepository)
        {
            _dbContext = dbContext;
            GenderRepository = genderRepository;
            ActorRepository = actorRepository;
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
                _dbContext?.Dispose();
            }

            _disposed = true;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
