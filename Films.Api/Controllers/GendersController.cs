using course_backend.Utilities;
using Films.Api.Utilities;
using Films.Core.Application.Dtos;
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
        var gender = await _genderService.GetGenderToUpdateById(id);

        if (gender == null)
        {
            return NotFound();
        }

        genderDto.Id = id;
        await _genderService.UpdateGender(genderDto);

        return NoContent();
    }
    
    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var gender = await _genderService.GetGenderById(id);

        if (gender == null)
        {
            return NotFound();
        }

        await _genderService.RemoveGender(gender);

        return NoContent();
    }
}
