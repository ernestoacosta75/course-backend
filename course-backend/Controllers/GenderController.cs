using course_backend.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace course_backend.Controllers;

public class GenderController : Controller
{
    private readonly IRepository _repository;

    public GenderController(IRepository repository)
    {
        _repository = repository;
    }
    public IActionResult Index()
    {
        return View();
    }
}
