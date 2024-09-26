using AutoMapper;
using Films.Core.Application.Dtos;
using Films.Core.Domain.Entities;
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
        public void AddActor(ActorDto actorDto)
        {
            _unitOfWork.ActorRepository.Add(_mapper.Map<Domain.Entities.Actor>(actorDto));
            _unitOfWork.Save();
        }

        [Log]
        public async Task<ActorDto?> GetActorById(Guid actorId)
        {
            var actor = await _unitOfWork.ActorRepository.GetById(actorId);
            return _mapper.Map<ActorDto>(actor);
        }

        [Log]
        public async Task<ActorCreationDto?> GetActorToUpdateById(Guid actorId)
        {
            var actor = await _unitOfWork.ActorRepository.GetById(actorId);
            return _mapper.Map<ActorCreationDto>(actor);
        }

        [Log]
        public IQueryable<ActorDto> GetAllActors()
        {
            var actors = _unitOfWork.ActorRepository.GetAll();
            var actorsDtos = _mapper.ProjectTo<ActorDto>(actors);

            return actorsDtos;
        }

        [Log]
        public async Task RemoveActor(ActorDto actorDto)
        {
            var actorToDelete = _unitOfWork.ActorRepository.GetById(actorDto.Id).Result;

            if (actorToDelete != null)
            {
                _unitOfWork.ActorRepository.Delete(actorToDelete);
                await _unitOfWork.SaveAsync();
            }
        }

        [Log]
        public async Task UpdateActor(ActorDto actorDto)
        {
            var existingActor = await _unitOfWork.ActorRepository.GetById(actorDto.Id);

            if (existingActor != null)
            {
                // Update properties of the existing entity with values from the Dto
                _mapper.Map(actorDto, existingActor);

                // Save the updated entity
                _unitOfWork.ActorRepository.Update(existingActor);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
