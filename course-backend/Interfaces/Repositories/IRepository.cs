using course_backend.Entities;

namespace course_backend.Interfaces.Repositories;

public interface IRepository
{
    List<Gender> GetAllGenders();
    Gender GetGenderById(int genderId);
}
