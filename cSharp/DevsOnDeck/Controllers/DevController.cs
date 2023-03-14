using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsOnDeck.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsOnDeck.Controllers;

public class DevController: Controller 
{

    private MyContext db;  // or use _context instead of db (Make sure this matches on all controller files)
    
    public DevController(MyContext context)
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
    [HttpPost("/Developer/CreateDevId")]
    public IActionResult CreateDevId(Dev d) {
        d.UserId = (int)uid;
        db.Devs.Add(d);
        db.SaveChanges();
        return Redirect("/Developer/Dashboard");
    }

    // [AdminCheck]
    [SessionCheck]
    [HttpGet("/Developer/Dashboard")]
    public IActionResult DevDash() {
        HttpContext.Session.SetString("type", "Dev");
        User? theUser = db.Users.FirstOrDefault(u => uid == u.UserId);
        Console.WriteLine($"uid: {uid}, userId {theUser.UserId}, accessLevel: {theUser.AccessLevel}");
        if(theUser.AccessLevel == 1) {
            theUser.AccessLevel = 2;
            db.Users.Update(theUser);
            db.SaveChanges();
        }
        
        return View("DevDash", "Dev");
    }

    // *** profile
    // *** update profile
    // *** add skills page
    // *** add skills function
    // *** view jobs - all
    // *** view jobs - skill based
}