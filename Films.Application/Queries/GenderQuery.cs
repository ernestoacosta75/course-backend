using Films.Application.Models;

namespace Films.Application.Queries
{
    public class GenderQuery : IGenderQuery
    {
        public Task<IReadOnlyCollection<GenderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
