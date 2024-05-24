using course_backend_entities;
using course_backend_interfaces;

namespace course_backend_implementations.Services;

public class GenderService : IGenderService
{
    private readonly IUnitOfWork _unitOfWork;

    public GenderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddGender(Gender gender)
    {
        _unitOfWork.GenderRepository.Add(gender);
        _unitOfWork.Save();
    }

    public IEnumerable<Gender> GetAllGenders()
    {
        return _unitOfWork.GenderRepository.GetAll();
    }

    public async Task<Gender> GetGenderById(int genderId)
    {
        return await _unitOfWork.GenderRepository.GetById(genderId);
    }

    public void RemoveGender(Gender gender)
    {
        var genderToDelete = _unitOfWork.GenderRepository.GetById(gender.Id).Result;
        if (genderToDelete != null) 
        {
            _unitOfWork.GenderRepository.Delete(genderToDelete);
            _unitOfWork.Save();
        }
    }

    public void UpdateGender(Gender gender)
    {
        _unitOfWork.GenderRepository.Update(gender);
        _unitOfWork.Save();
    }
}
