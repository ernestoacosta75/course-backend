using AutoMapper;
using Films.Core.Application.Dtos;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Gender
{
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Log]
        public void AddGender(GenderCreationDto gender)
        {
            _unitOfWork.GenderRepository.Add(_mapper.Map<Domain.Entities.Gender>(gender));
            _unitOfWork.Save();
        }

        [Log]
        public IQueryable<GenderDto> GetAllGenders()
        {
            var genders = _unitOfWork.GenderRepository.GetAll();
            var genderDtos = _mapper.ProjectTo<GenderDto>(genders);

            return genderDtos;
        }

        public async Task<GenderDto?> GetGenderById(Guid genderId)
        {
            var gender = await _unitOfWork.GenderRepository.GetById(genderId);
            return _mapper.Map<GenderDto>(gender);
        }

        public async Task<GenderDto?> GetGenderToUpdateById(Guid genderId)
        {
            var gender = await _unitOfWork.GenderRepository.GetById(genderId);
            return _mapper.Map<GenderDto>(gender); 
        }

        public async Task RemoveGender(GenderDto genderDto)
        {
            var genderToDelete = _unitOfWork.GenderRepository.GetById(genderDto.Id).Result;

            if (genderToDelete != null)
            {
                _unitOfWork.GenderRepository.Delete(genderToDelete);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task UpdateGender(GenderDto genderDto)
        {
            var existingGender = await _unitOfWork.GenderRepository.GetById(genderDto.Id);

            if (existingGender != null)
            {
                // Update properties of the existing entity with values from the Dto
                _mapper.Map(genderDto, existingGender);

                // Save the updated entity
                _unitOfWork.GenderRepository.Update(existingGender);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
