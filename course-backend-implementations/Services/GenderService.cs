using AutoMapper;
using course_backend_aop.Attributes;
using course_backend_entities;
using course_backend_entities.Dtos;
using course_backend_interfaces;

namespace course_backend_implementations.Services;

public class GenderService(IUnitOfWork unitOfWork, IMapper mapper) : IGenderService
{
    [Log]
    [Cache]
    public void AddGender(GenderCreationDto gender)
    {
        unitOfWork.GenderRepository.Add(mapper.Map<Gender>(gender));
        unitOfWork.Save();
    }

    public IQueryable<GenderDto> GetAllGenders()
    {
        var genders = unitOfWork.GenderRepository.GetAll();
        var genderDtos = mapper.ProjectTo<GenderDto>(genders);

        return genderDtos;
    }

    public async Task<GenderDto?> GetGenderById(Guid genderId)
    {
        var gender = await unitOfWork.GenderRepository.GetById(genderId);
        return mapper.Map<GenderDto>(gender);
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
