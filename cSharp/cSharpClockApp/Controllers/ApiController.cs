using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using cSharpClockApp.Models;

namespace cSharpClockApp.Controllers;

public class ApiController : Controller
{

    private MyContext db;

    public ApiController( MyContext context)
    {
        db = context;
    }

    [HttpGet("/apiRoot")]
    public IActionResult ApiRoot() {
        return View("ApiRoot");
    }

}
