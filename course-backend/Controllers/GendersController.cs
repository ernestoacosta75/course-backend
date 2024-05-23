using course_backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GendersController : ControllerBase
{
    private readonly ILogger<GendersController> _logger;

    public GendersController(ILogger<GendersController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<List<Gender>> GetAllGenders()
    {
        _logger.LogInformation("Fetching all the genders");

        return new List<Gender>();
    }
    
    [HttpGet("{genderId:int}")]
    public Task<ActionResult<Gender>> GetGenderById(int genderId, [FromHeader] string name)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult Post([FromBody] Gender gender)
    {
        throw new NotImplementedException();
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
