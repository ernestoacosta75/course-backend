using course_backend.Entities;
using course_backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace course_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenderController : ControllerBase
{
    private readonly IRepository _repository;

    public GenderController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public List<Gender> GetAllGenders()
    {
        return _repository.GetAllGenders();
    }
    
    [HttpGet]
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
