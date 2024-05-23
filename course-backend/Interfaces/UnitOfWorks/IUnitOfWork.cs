using course_backend.Entities;
using course_backend.Interfaces.Repositories;

namespace course_backend.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<Gender> GenderRepository { get; }
    void Save();
}
