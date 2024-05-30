using course_backend_entities;

namespace course_backend_data_access.Repositories;

public class InMemoryRepository 
{
    private readonly List<Gender> _genders;
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

    public async Task<Gender> GetGenderById(int genderId)
    {
        Task.Delay(TimeSpan.FromSeconds(1));
        return _genders.Find(g => g.Id == genderId);
    }
}
