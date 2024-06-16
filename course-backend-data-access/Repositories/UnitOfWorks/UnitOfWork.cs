using course_backend_entities;
using course_backend_interfaces;

namespace course_backend_data_access;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _context;
    private bool _disposed = false;
    public IRepository<Gender> GenderRepository { get; private set; }

    public UnitOfWork(MyDbContext context)
    {
        _context = context;
        GenderRepository = new Repository<Gender>(_context);
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
            _context.Dispose();
        }

        _disposed = true;
    }

    public void Save()
    {
        _context.SaveChangesAsync();
    }
}
