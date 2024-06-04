using AutoMapper;
using course_backend_entities;
using course_backend_entities.Dtos;
using course_backend_interfaces;

namespace course_backend_implementations.Services;

public class GenderService(IUnitOfWork unitOfWork, IMapper mapper) : IGenderService
{
    public void AddGender(GenderCreationDto gender)
    {
        unitOfWork.GenderRepository.Add(mapper.Map<Gender>(gender));
        unitOfWork.Save();
    }

    public async Task<IEnumerable<GenderDto>> GetAllGenders()
    {
        return mapper.Map<IEnumerable<GenderDto>>(await unitOfWork.GenderRepository.GetAll());
    }

    public async Task<GenderDto?> GetGenderById(Guid genderId)
    {
        return mapper.Map<GenderDto>(await unitOfWork.GenderRepository.GetById(genderId));
    }

    public void RemoveGender(Gender gender)
    {
        var genderToDelete = unitOfWork.GenderRepository.GetById(gender.Id).Result;
        if (genderToDelete != null) 
        {
            unitOfWork.GenderRepository.Delete(genderToDelete);
            unitOfWork.Save();
        }
    }

    public void UpdateGender(Gender gender)
    {
        unitOfWork.GenderRepository.Update(gender);
        unitOfWork.Save();
    }
}
