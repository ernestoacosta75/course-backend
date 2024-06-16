﻿using AutoMapper;
using Films.Core.Application.Models;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.Attributes;

namespace Films.Core.Application.Services.Gender
{
    public class GenderService(IUnitOfWork unitOfWork, IMapper mapper) : IGenderService
    {
        [Log]
        [Cache]
        public void AddGender(GenderCreationDto gender)
        {
            unitOfWork.GenderRepository.Add(mapper.Map<Domain.Entities.Gender>(gender));
            unitOfWork.Save();
        }

        public IQueryable<GenderDto> GetAllGenders()
        {
            var genders = unitOfWork.GenderRepository.GetAll();
            var genderDtos = mapper.ProjectTo<GenderDto>(genders);

            return genderDtos;
        }

        public async Task<GenderDto?> GetGenderById(Guid genderId)
        {
            var gender = await unitOfWork.GenderRepository.GetById(genderId);
            return mapper.Map<GenderDto>(gender);
        }

        public void RemoveGender(Domain.Entities.Gender gender)
        {
            var genderToDelete = unitOfWork.GenderRepository.GetById(gender.Id).Result;

            if (genderToDelete != null)
            {
                unitOfWork.GenderRepository.Delete(genderToDelete);
                unitOfWork.Save();
            }
        }

        public void UpdateGender(Domain.Entities.Gender gender)
        {
            unitOfWork.GenderRepository.Update(gender);
            unitOfWork.Save();
        }
    }
}
