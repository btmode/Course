using Microsoft.AspNetCore.Mvc;
using PullCourse.Service;

namespace PullCourse.Controllers;

[Route("Courses")]
public class DashboardController : Controller
{
    private readonly CourseService _courseService;

    public DashboardController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index([FromQuery] string office = "tlt")
    {
        var courses = await _courseService.GetAllCoursesAsync(office);
        
        foreach (var c in courses)
        {
            Console.WriteLine($"{c.CurrencyCode}: {c.Buy}/{c.Sell} ({c.City})");
        }
        ViewBag.CurrentCity = office; 
        
        
        return View(courses.ToList());
    }
}