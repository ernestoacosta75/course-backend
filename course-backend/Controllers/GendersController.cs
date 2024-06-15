using course_backend.Utilities;
using Films.Core.Application.Models;
using Films.Core.Application.Services.Gender;
using Films.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GendersController(IGenderService genderService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GenderDto>>> GetAllGenders([FromQuery] PaginationDto paginationDto)
    {
        var queryable = genderService.GetAllGenders();
        await HttpContext.InsertPaginationParametersInHeader(queryable);
        var genders = await queryable
            .OrderBy(x => x.Name)
            .Paginate(paginationDto)
            .ToListAsync();

        return genders;
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
