using Films.Core.DomainServices.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Films.Core.DomainServices.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly FilmsDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(FilmsDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
