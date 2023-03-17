using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsOnDeck.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsOnDeck.Controllers;

public class SkillController : Controller {
    private MyContext db;  // or use _context instead of db (Make sure this matches on all controller files)  
    public SkillController(MyContext context)
    {
        db = context; // if you use _context above use it here too (Make sure this matches on all controller files)
    }
    private int? uid {
        get {
            return HttpContext.Session.GetInt32("uid");
        }
    }
    private int? level {
        get {
            return HttpContext.Session.GetInt32("level");
        }
    }
    private string? name {
        get {
            return HttpContext.Session.GetString("name");
        }
    }
    private string? type {
        get {
            return HttpContext.Session.GetString("type");
        }
    }
    private string? role {
        get {
            return HttpContext.Session.GetString("role");
        }
    }
    [SessionCheck]
    [HttpGet("/Skill/AllSkills")]
    public IActionResult AllSkills() {
        List<Skill> allSkills = db.Skills
        .ToList();
        return View("AllSkills", allSkills);
    }
    [SessionCheck]
    [HttpPost("/Skill/CreateSkill")]
    public IActionResult CreateSkill(Skill s) {
        db.Skills.Add(s);
        db.SaveChanges();
        return Redirect("/Skill/AllSkills");
    }
}