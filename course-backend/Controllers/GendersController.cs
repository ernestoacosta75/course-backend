using course_backend.Entities;
using course_backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GendersController : ControllerBase
{
    private readonly IRepository _repository;

    public GendersController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [HttpGet("list")]
    public ActionResult<List<Gender>> GetAllGenders()
    {
        return _repository.GetAllGenders();
    }
    
    [HttpGet("{genderId:int}")]
    public async Task<ActionResult<Gender>> GetGenderById(int genderId, [FromHeader] string name)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var gender = await _repository.GetGenderById(genderId);

        if (gender is null)
        {
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
