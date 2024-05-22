using course_backend.Entities;
using course_backend.Interfaces.Repositories;

namespace course_backend.Repositories;

public class InMemoryRepository : IRepository
{
    private List<Gender> _genders;
    public InMemoryRepository()
    {
        _genders = new List<Gender>() 
        {
            new Gender() { Id = 1, Name = "Comedy" },
            new Gender() { Id = 2, Name = "Action" }
        };
    }

    public List<Gender> GetAllGenders()
    {
        return _genders;
    }

    public Gender GetGenderById(int genderId)
    {
        return _genders.FirstOrDefault(g => g.Id == genderId);
    }
}
