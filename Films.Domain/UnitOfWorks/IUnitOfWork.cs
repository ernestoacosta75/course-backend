using Films.Domain.Entities;
using Films.Domain.Repositories;

namespace Films.Domain.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Gender> GenderRepository { get; }
        void Save();
    }
}
