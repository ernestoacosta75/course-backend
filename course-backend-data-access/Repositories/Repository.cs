using course_backend_interfaces;
using Microsoft.EntityFrameworkCore;

namespace course_backend_data_access;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public void Add(TEntity entity)
    {
        _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
    }
}
