using Films.Core.Application.Dtos;

namespace Films.Core.Application.Services.Actor
{
    public interface IActorService
    {
        void AddActor(ActorDto actorDto);
        Task UpdateActor(ActorDto actorDto);
        Task RemoveActor(ActorDto actorDto);
        Task<ActorDto?> GetActorById(Guid actorId);
        Task<ActorCreationDto?> GetActorToUpdateById(Guid actorId);
        IQueryable<ActorDto> GetAllActors();
    }
}
