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

    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return View(courses.ToList());
    }
}