using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsHelpingDevs.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsHelpingDevs.Controllers;

public class ForumController : Controller
{

    private MyContext db; 

    public ForumController(MyContext context)
    {
        db = context;
    }
// ! Session Getters
private string? key { // Invite code
    get {
        return HttpContext.Session.GetString("key");
    }
}
   private int? uid { // Session logged in
        get {
            return HttpContext.Session.GetInt32("uid");
        }
    }
    private int? level { // access level default 1
        get {
            return HttpContext.Session.GetInt32("level");
        }
    }
    private string? name { // fullname
        get {
            return HttpContext.Session.GetString("name");
        }
    }
    private string? side { // side visited last/on
        get {
            return HttpContext.Session.GetString("side");
        }
    }
    private string? logged { // last logged on
        get {
            return HttpContext.Session.GetString("logged");
        }
    }
    // ! Forum Home
    // [SessionCheck]
    [HttpGet("/Forum/Dashboard")]
    public IActionResult ForumDash() {
        return View("ForumDash");
    }
}