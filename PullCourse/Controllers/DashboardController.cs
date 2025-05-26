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

<<<<<<< HEAD
    [HttpGet("")]
    public async Task<IActionResult> Index([FromQuery] string office = "tlt")
    {
        var courses = await _courseService.GetAllCoursesAsync(office);
        
        foreach (var c in courses)
        {
            Console.WriteLine($"{c.CurrencyCode}: {c.Buy}/{c.Sell} ({c.City})");
        }
        ViewBag.CurrentCity = office; 
        
        
=======
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCoursesAsync();
>>>>>>> 602c8e743a7df97878ff6e6f63cdae25e59e3daa
        return View(courses.ToList());
    }
}