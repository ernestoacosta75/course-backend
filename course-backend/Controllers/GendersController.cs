using course_backend.Entities;
using course_backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GendersController : ControllerBase
{
    private readonly IRepository _repository;
    private readonly ILogger<GendersController> _logger;

    public GendersController(IRepository repository, ILogger<GendersController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    [HttpGet("list")]
    // [ResponseCache(Duration = 60)] // This won't work if in the request headers is present Authorization
    public ActionResult<List<Gender>> GetAllGenders()
    {
        _logger.LogInformation("Fetching all the genders");

        return _repository.GetAllGenders();
    }
    
    [HttpGet("{genderId:int}")]
    public async Task<ActionResult<Gender>> GetGenderById(int genderId, [FromHeader] string name)
    {
        _logger.LogDebug($"Fetching the gender with id: {genderId}");

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var gender = await _repository.GetGenderById(genderId);

        if (gender is null)
        {
            _logger.LogWarning($"There isn't any gender with id: {genderId}");
            return NotFound();
        }

        return gender;
    }

    [HttpPost]
    public ActionResult Post([FromBody] Gender gender)
    {
        return NoContent();
    }
    
    [HttpPut]
    public ActionResult Put([FromBody] Gender gender)
    {
        return NoContent();
    }
    
    [HttpDelete]
    public ActionResult Delete()
    {
        return NoContent();
    }
}
