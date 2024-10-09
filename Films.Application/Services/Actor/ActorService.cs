using AutoMapper;
using Films.Core.Application.Dtos.Actor;
using Films.Core.Application.Services.Archives;
using Films.Core.Domain.Entities;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Actor
{
    public class ActorService : IActorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILocalArchiveStorageService _localArchiveStorageService;
        private readonly string container = "actors";

        public ActorService(IUnitOfWork unitOfWork, IMapper mapper,
            ILocalArchiveStorageService localArchiveStorageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localArchiveStorageService = localArchiveStorageService;
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
        public async Task<ActorDto?> GetActorToUpdateById(Guid actorId)
        {
            var actor = await _unitOfWork.ActorRepository.GetById(actorId);
            return _mapper.Map<ActorDto>(actor);
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
        public async Task UpdateActor(Guid id, ActorCreationDto actorCreationDto)
        {            
            var existingActor = await _unitOfWork.ActorRepository.GetById(id);
            string pictureUrl = existingActor.Picture;

            if (existingActor != null)
            {
                if (actorCreationDto.Picture != null)
                {
                    pictureUrl = await _localArchiveStorageService
                        .EditArchive(container, actorCreationDto.Picture, existingActor.Picture);
                }

                // Update properties of the existing entity with values from the Dto
                _mapper.Map(actorCreationDto, existingActor);
                existingActor.Picture = pictureUrl;

                // Save the updated entity
                _unitOfWork.ActorRepository.Update(existingActor);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
