using Films.Core.Application.Models;

namespace Films.Core.Application.Services.Gender
{
    public interface IGenderService
    {
        void AddGender(GenderCreationDto gender);
        Task UpdateGender(GenderDto genderDto);
        void RemoveGender(Domain.Entities.Gender gender);
        Task<GenderDto?> GetGenderById(Guid genderId);
        Task<GenderDto?> GetGenderToUpdateById(Guid genderId);
        IQueryable<GenderDto> GetAllGenders();
    }
}
