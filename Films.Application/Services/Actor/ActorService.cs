using AutoMapper;
using Films.Core.Application.Dtos;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Actor
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Log]
        public void AddActor(ActorCreationDto actorCreationDto)
        {
            //_unitOfWork.ActorRepository.Add(_mapper.Map<Domain.Entities.Actor>(actorCreationDto));
            //_unitOfWork.Save();
        }

        [Log]
        public Task<ActorDto?> GetActorById(Guid actorId)
        {
            throw new NotImplementedException();
        }

        [Log]
        public Task<ActorDto?> GetActorToUpdateById(Guid actorId)
        {
            throw new NotImplementedException();
        }

        [Log]
        public IQueryable<ActorDto> GetAllActors()
        {
            var actors = _unitOfWork.ActorRepository.GetAll();
            var actorsDtos = _mapper.ProjectTo<ActorDto>(actors);

            return actorsDtos;
        }

        [Log]
        public Task RemoveActor(ActorDto genderDto)
        {
            throw new NotImplementedException();
        }

        [Log]
        public Task UpdateActor(ActorDto genderDto)
        {
            throw new NotImplementedException();
        }
    }
}
