using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Models;
using Films.Core.Application.Services.Gender;
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
    
    [HttpGet("{genderId:Guid}")]
    public async Task<ActionResult<GenderDto>> GetGenderById(Guid genderId)
    {
        GenderDto? gender = await _genderService.GetGenderById(genderId);

        if (gender == null) 
        { 
            return NotFound();
        }

        return gender;
    }

    [HttpPost]
    public ActionResult Post([FromBody] GenderCreationDto genderCreationDto)
    {
        _genderService.AddGender(genderCreationDto);
        return NoContent();
    }
    
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] GenderDto genderDto)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        GenderDto gender = await _genderService.GetGenderToUpdateById(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        if (gender == null)
        {
            return NotFound();
        }

        genderDto.Id = id;
        await _genderService.UpdateGender(gender);

        return NoContent();
    }
    
    [HttpDelete]
    public ActionResult Delete()
    {
        throw new NotImplementedException();
    }
}
