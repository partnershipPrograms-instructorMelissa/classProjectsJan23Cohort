using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using cSharpClockApp.Models;

namespace cSharpClockApp.Controllers;

public class SkillController : Controller
{

    private MyContext db;

    public SkillController( MyContext context)
    {
        db = context;
    }

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
