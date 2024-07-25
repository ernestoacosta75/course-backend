using Films.Core.Application.Dtos;

namespace Films.Core.Application.Services.Actor
{
    public interface IActorService
    {
        void AddActor(ActorCreationDto gender);
        Task UpdateActor(ActorDto genderDto);
        Task RemoveActor(ActorDto genderDto);
        Task<ActorDto?> GetActorById(Guid actorId);
        Task<ActorDto?> GetActorToUpdateById(Guid actorId);
        IQueryable<ActorDto> GetAllActors();
    }
}
