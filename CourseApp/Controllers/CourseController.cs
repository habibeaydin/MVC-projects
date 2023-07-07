using Microsoft.AspNetCore.Mvc;
using CourseApp.Models;

namespace CourseApp.Controllers;

public class CourseController : Controller 
{
    public IActionResult Index()
    {
        var student = Repository.Applications;
        return View(student);
    }

    public IActionResult Apply()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Apply([FromForm]Student student)
    {
        if(Repository.Applications.Any(c => c.Email.Equals(student.Email)))
        {
            ModelState.AddModelError("","There is already an application for you.");
        }

        if(ModelState.IsValid)
        {
            Repository.Add(student);
            return View("Feedback", student);
        }

        return View();
    }
}