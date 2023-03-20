using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsHelpingDevs.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsHelpingDevs.Controllers;

public class DevController : Controller
{

    private MyContext db; 

    public DevController(MyContext context)
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
    // ! Developer Dashboard
    [SessionCheck]
    [HttpGet("/Dev/Dashboard")]
    public IActionResult DevDash() {
        MyViews userInfo = new MyViews {
            AllDevSkills = (List<DevSkill>)db.Users
            .Where(u => u.UserId == (int)uid)
            .Select(u => u.mySkills.Select(ds => ds.mySkill.Name))
            .FirstOrDefault(),
            userProfile = (UserProfile)db.Users
            .Where(u => u.UserId == (int)uid)
            .Select(u => u.myProfile)
        };
        return View("DevDash", userInfo);
    }
// ! add dev skill
// ! create dev skill
    [SessionCheck]
    [HttpPost("/Dev/DevSkills/Create")]
    public IActionResult CreateDevSkill(DevSkill ds) {
        return RedirectToAction("DevDash");
    }

}