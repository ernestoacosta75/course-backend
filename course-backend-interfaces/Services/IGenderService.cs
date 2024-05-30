using course_backend_entities;

namespace course_backend_interfaces;

public interface IGenderService
{
    void AddGender(Gender gender);
    void UpdateGender(Gender gender);
    void RemoveGender(Gender gender);
    Task<Gender?> GetGenderById(int genderId);
    Task<IEnumerable<Gender>> GetAllGenders();

}
