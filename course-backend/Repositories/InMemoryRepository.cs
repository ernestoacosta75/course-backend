using course_backend.Entities;
using course_backend.Interfaces.Repositories;

namespace course_backend.Repositories;

public class InMemoryRepository // : IRepository
{
    private readonly ILogger<InMemoryRepository> _logger;
    private List<Gender> _genders;
    public InMemoryRepository(ILogger<InMemoryRepository> logger)
    {
        _genders = new List<Gender>() 
        {
            new Gender() { Id = 1, Name = "Comedy" },
            new Gender() { Id = 2, Name = "Action" }
        };

        _logger = logger;
    }

    public List<Gender> GetAllGenders()
    {
        return _genders;
    }

    public async Task<Gender> GetGenderById(int genderId)
    {
        Task.Delay(TimeSpan.FromSeconds(1));
        return _genders.FirstOrDefault(g => g.Id == genderId);
    }
}
