using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Models;
using Films.Core.Application.Services.Gender;
using Films.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GendersController : ControllerBase
{
    private readonly IGenderService _genderService;

    public GendersController(IGenderService genderService)
    {
        _genderService = genderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GenderDto>>> GetAllGenders([FromQuery] PaginationDto paginationDto)
    {
        var queryable = _genderService.GetAllGenders();
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
        GenderDto? gender = await _genderService.GetGenderById(genderId);
        return gender;
    }

    [HttpPost]
    public ActionResult Post([FromBody] GenderCreationDto gender)
    {
        _genderService.AddGender(gender);
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
