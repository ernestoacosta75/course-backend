using Films.Core.Application.Dtos;

namespace Films.Core.Application.Services.Actor
{
    public interface IActorService
    {
        void AddActor(ActorCreationDto actorCreationDto);
        Task UpdateActor(ActorDto actorDto);
        Task RemoveActor(ActorDto actorDto);
        Task<ActorDto?> GetActorById(Guid actorId);
        Task<ActorDto?> GetActorToUpdateById(Guid actorId);
        IQueryable<ActorDto> GetAllActors();
    }
}
