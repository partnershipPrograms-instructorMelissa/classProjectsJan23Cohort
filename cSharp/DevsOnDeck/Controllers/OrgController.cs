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
    

    // [SessionCheck]
    // [HttpPost("/Organization/CreateOrgId")]
    // public IActionResult CreateOrgId(Dev d) {
    //     d.UserId = (int)uid;
    //     db.Devs.Add(d);
    //     db.SaveChanges();
    //     return Redirect("/Organization/Dashboard");
    // }

    // [AdminCheck]
    // [SessionCheck]
    // [HttpGet("/Organization/Dashboard")]
    // public IActionResult OrgDash() {
    //     HttpContext.Session.SetString("type", "Org");
    //     User? theUser = db.Users.FirstOrDefault(u => uid == u.UserId);
    //     Console.WriteLine($"uid: {uid}, userId {theUser.UserId}, accessLevel: {theUser.AccessLevel}");
    //     if(theUser.AccessLevel == 1) {
    //         theUser.AccessLevel = 2;
    //         db.Users.Update(theUser);
    //         db.SaveChanges();
    //     }
        
    //     return View("OrgDash", "Org");
    // }

    // *** view profile
    // *** update profile
    // *** add jobs form
    // *** create job
    // *** add skills form
    // *** create skills
    // *** all jobs
    // *** all jobs with matched dev
    // *** delete job
    // *** update job
}