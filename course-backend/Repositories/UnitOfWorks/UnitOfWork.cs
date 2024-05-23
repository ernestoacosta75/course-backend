using course_backend.Entities;
using course_backend.Interfaces.Repositories;
using course_backend.Interfaces.UnitOfWorks;

namespace course_backend.Repositories.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    public IRepository<Gender> GenderRepository { get; private set; }

    public UnitOfWork()
    {
        //GenderRepository = new Repository<Gender>(_context);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Save()
    {
        // _context.SaveChanges();
    }
}
