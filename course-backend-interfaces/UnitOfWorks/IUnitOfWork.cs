using course_backend_entities;

namespace course_backend_interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Gender> GenderRepository { get; }
    void Save();
}
