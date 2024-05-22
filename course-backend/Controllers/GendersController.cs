using course_backend.Entities;
using course_backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    public List<Gender> GetAllGenders()
    {
        return _repository.GetAllGenders();
    }
    
    [HttpGet("{genderId:int}")]
    public Gender GetGenderById(int genderId)
    {
        var gender = _repository.GetGenderById(genderId);

        if (gender is null)
        {
            //return NotFound();
        }

        return gender;
    }

    [HttpPost]
    public void Post()
    {

    }
    
    [HttpPut]
    public void Put()
    {

    }
    
    [HttpDelete]
    public void Delete()
    {

    }
}
