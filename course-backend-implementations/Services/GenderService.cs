using course_backend_entities;
using course_backend_interfaces;

namespace course_backend_implementations.Services;

public class GenderService(IUnitOfWork unitOfWork) : IGenderService
{
    public void AddGender(Gender gender)
    {
        unitOfWork.GenderRepository.Add(gender);
        unitOfWork.Save();
    }

    public async Task<IEnumerable<Gender>> GetAllGenders()
    {
        return await unitOfWork.GenderRepository.GetAll();
    }

    public async Task<Gender?> GetGenderById(int genderId)
    {
        return await unitOfWork.GenderRepository.GetById(genderId);
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
