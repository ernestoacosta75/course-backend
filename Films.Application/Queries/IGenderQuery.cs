using Films.Application.Models;

namespace Films.Application.Queries
{
    public interface IGenderQuery
    {
        Task<IReadOnlyCollection<GenderDto>> GetAllAsync();
    }
}
