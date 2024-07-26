using Films.Core.Domain.Entities;
using Films.Core.DomainServices.Repositories;

namespace Films.Core.DomainServices.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Gender> GenderRepository { get; }
        IRepository<Actor> ActorRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
