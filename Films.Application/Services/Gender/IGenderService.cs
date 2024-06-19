using Films.Core.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Films.Core.Application.Services.Gender
{
    public interface IGenderService
    {
        void AddGender(GenderCreationDto gender);
        void UpdateGender(GenderDto genderDto);
        void RemoveGender(Domain.Entities.Gender gender);
        Task<GenderDto?> GetGenderById(Guid genderId);
        Task<GenderDto?> GetGenderToUpdateById(Guid genderId);
        IQueryable<GenderDto> GetAllGenders();
    }
}
