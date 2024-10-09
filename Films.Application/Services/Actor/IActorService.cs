using Films.Core.Application.Dtos.Actor;

namespace Films.Core.Application.Services.Actor
{
    public interface IActorService
    {
        void AddActor(ActorDto actorDto);
        Task UpdateActor(Guid id, ActorCreationDto actorCreationDto);
        Task RemoveActor(ActorDto actorDto);
        Task<ActorDto?> GetActorById(Guid actorId);
        Task<ActorDto?> GetActorToUpdateById(Guid actorId);
        IQueryable<ActorDto> GetAllActors();
    }
}
