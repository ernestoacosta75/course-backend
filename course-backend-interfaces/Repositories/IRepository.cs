namespace course_backend_interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetById(Guid id);
    IQueryable<TEntity> GetAll();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
