using course_backend_entities;
using course_backend_entities.Dtos;

namespace course_backend_interfaces;

public interface IGenderService
{
    void AddGender(GenderCreationDto gender);
    void UpdateGender(Gender gender);
    void RemoveGender(Gender gender);
    Task<GenderDto?> GetGenderById(Guid genderId);
    Task<IEnumerable<GenderDto>> GetAllGenders();

}
