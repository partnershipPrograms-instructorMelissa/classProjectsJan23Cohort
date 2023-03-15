using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using cSharpClockApp.Models;

namespace cSharpClockApp.Controllers;

public class SkillController : Controller
{

    private MyContext db;

    public SkillController( MyContext context)
    {
        db = context;
    }
    [SessionCheck]
    [HttpGet("addskill")]
    public IActionResult AddSkill() {
        return View("AddSkill");
    }
    [HttpPost("createskill")]
    public IActionResult CreateSkill(Skill newSkill) {
            if(ModelState.IsValid)       
            {
                db.Add(newSkill);
                db.SaveChanges();
                return Redirect("/");
            } 
        else
        {
                return View("addSkill");
        }
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
