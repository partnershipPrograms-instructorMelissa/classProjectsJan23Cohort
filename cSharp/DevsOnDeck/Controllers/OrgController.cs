using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsOnDeck.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsOnDeck.Controllers;

public class OrgController: Controller 
{

    private MyContext db;  // or use _context instead of db (Make sure this matches on all controller files)
    
    public OrgController(MyContext context)
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
    [HttpPost("/Organization/CheckCode")]
    public IActionResult CheckCode(CheckCode code) {
        if(!ModelState.IsValid) {
            return View("Dashboard", "Home");
        }
        return View("Index");
    }
    

    // *** view profile
    // *** update profile
    // *** add jobs form
    // *** create job
    // *** add skills form
    // *** create skills
    // *** all jobs
    // *** all jobs with matched dev

    // !!!!!! BackLog Ideas
    // *** delete job
    // *** update job
}