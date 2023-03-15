using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsOnDeck.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsOnDeck.Controllers;

public class AdminController: Controller 
{

    private MyContext db;  // or use _context instead of db (Make sure this matches on all controller files)
    
    public AdminController(MyContext context)
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
    
    [AdminCheck]
    [SessionCheck]
    [HttpGet("/Admin/Dashboard")]
    public IActionResult AdminDash() {
        if(level == 24) {
            HttpContext.Session.SetString("type", "Super Admin");
        } else {
            HttpContext.Session.SetString("type", "Admin");
        }
        
        return View("AdminDash", "Admin");
    }
    [AdminCheck]
    [SessionCheck]
    [HttpGet("/Admin/Users")]
    public IActionResult AllUsers() {
        List<User> allUsers = db.Users
        .ToList();
        return View("AllUsers", allUsers);
    }
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/{userId}/MakeSuper")]
    public IActionResult MakeSuper(int userId) {
        User? aUser = db.Users
        .FirstOrDefault(aUser => aUser.UserId == userId);
        aUser.AccessLevel = 24;
        aUser.AccessType = "SuperAdmin";
        aUser.UpdatedAt = DateTime.Now;
        db.Users.Update(aUser);
        db.SaveChanges();
        return Redirect("/Admin/Users");
    }
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/{userId}/MakeAdmin")]
    public IActionResult MakeAdmin(int userId) {
        User? aUser = db.Users
        .FirstOrDefault(aUser => aUser.UserId == userId);
        aUser.AccessLevel = 22;
        aUser.AccessType = "Admin";
        aUser.UpdatedAt = DateTime.Now;
        db.Users.Update(aUser);
        db.SaveChanges();
        return Redirect("/Admin/Users");
    }
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/{userId}/RemoveAdmin")]
    public IActionResult RemoveAdmin(int userId) {
        User? aUser = db.Users
        .FirstOrDefault(aUser => aUser.UserId == userId);
        aUser.AccessLevel = 1;
        aUser.AccessType = "Gen";
        aUser.UpdatedAt = DateTime.Now;
        db.Users.Update(aUser);
        db.SaveChanges();
        return Redirect("/Admin/Users");
    }
    [AdminCheck]
    [SessionCheck]
    [HttpGet("/Admin/OrgCodes")]
    public IActionResult OrgCodes() {
        List<RandKey> allCodes = db.RandKeys
        .ToList();
        return View("OrgCodes", allCodes);
    }

    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/CreateCode")]
    public IActionResult CreateCode(RandKey r) {
        r.UserId = (int)uid;
        Random rand = new Random();
        r.RKey = "";
        string avail = "abcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int size = avail.Length;
        while(r.RKey.Length < 13) {
            r.RKey += avail[rand.Next(size)];
        }
        db.RandKeys.Add(r);
        db.SaveChanges();
        return Redirect("/Admin/OrgCodes");
    }

// !!!! BackLog Ideas

// *** Remove User
// *** Remove Org
// *** Update Password Link (/user/{key}/updatePassword)
    // [AdminCheck]
    // [SessionCheck]

    
}