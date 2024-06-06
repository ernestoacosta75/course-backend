using course_backend_entities;
using course_backend_entities.Dtos;
using course_backend_interfaces;
using Microsoft.AspNetCore.Mvc;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GendersController(IGenderService genderService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GenderDto>>> GetAllGenders()
    {
        var genders = await genderService.GetAllGenders();
        return genders.ToList();
    }
    
    [HttpGet("{genderId:int}")]
    public async Task<ActionResult<GenderDto>> GetGenderById(Guid genderId)
    {
        GenderDto? gender = await genderService.GetGenderById(genderId);
        return gender;
    }

    [HttpPost]
    public ActionResult Post([FromBody] GenderCreationDto gender)
    {
        genderService.AddGender(gender);
        return NoContent();
    }
    
    [HttpPut]
    public ActionResult Put([FromBody] Gender gender)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    public ActionResult Delete()
    {
        throw new NotImplementedException();
    }
}
