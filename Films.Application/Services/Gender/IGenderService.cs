using Films.Application.Models;

namespace Films.Application.Services.Gender
{
    public interface IGenderService
    {
        void AddGender(GenderCreationDto gender);
        void UpdateGender(Domain.Entities.Gender gender);
        void RemoveGender(Domain.Entities.Gender gender);
        Task<GenderDto?> GetGenderById(Guid genderId);
        IQueryable<GenderDto> GetAllGenders();
    }
}
