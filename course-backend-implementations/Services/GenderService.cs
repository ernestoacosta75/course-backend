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
        return mapper.Map<IQueryable<GenderDto>>(unitOfWork.GenderRepository.GetAll());
        //return mapper.Map<IEnumerable<GenderDto>>(await unitOfWork.GenderRepository.GetAll());
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
