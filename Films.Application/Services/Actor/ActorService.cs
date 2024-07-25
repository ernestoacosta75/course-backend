using Films.Core.Application.Dtos;

namespace Films.Core.Application.Services.Actor
{
    public class ActorService : IActorService
    {
        public void AddActor(ActorCreationDto gender)
        {
            throw new NotImplementedException();
        }

        public Task<ActorDto?> GetActorById(Guid actorId)
        {
            throw new NotImplementedException();
        }

        public Task<ActorDto?> GetActorToUpdateById(Guid actorId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ActorDto> GetAllActors()
        {
            throw new NotImplementedException();
        }

        public Task RemoveActor(ActorDto genderDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateActor(ActorDto genderDto)
        {
            throw new NotImplementedException();
        }
    }
}
