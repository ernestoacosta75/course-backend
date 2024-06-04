using course_backend_entities;
using course_backend_entities.Dtos;
using course_backend_interfaces;
using Microsoft.AspNetCore.Mvc;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GendersController : ControllerBase
{
    private readonly ILogger<GendersController> _logger;
    private readonly IGenderService _genderService;

    public GendersController(IGenderService genderService, ILogger<GendersController> logger)
    {
        _genderService = genderService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<GenderDto>>> GetAllGenders()
    {
        _logger.LogInformation("Fetching all the genders");

        var genders = await _genderService.GetAllGenders();
        return genders.ToList();
    }
    
    [HttpGet("{genderId:int}")]
    public async Task<ActionResult<GenderDto>> GetGenderById(Guid genderId)
    {
        return await _genderService.GetGenderById(genderId);
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
