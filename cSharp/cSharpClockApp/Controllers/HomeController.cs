using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cSharpClockApp.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace cSharpClockAppControllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext db;  // or use _context instead of db

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        db = context; // if you use _context above use it here too
    }

    public IActionResult Dashboard()
    {
        return View();  
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? uid = context.HttpContext.Session.GetInt32("uid");
        // Check to see if we got back null
        if(uid == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}