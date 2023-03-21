using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsHelpingDevs.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace DevsHelpingDevs.Controllers;

public class AdminController : Controller
{

    private MyContext db; 

    public AdminController(MyContext context)
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
// ! Admin Dashboard
    [AdminCheck]
    [SessionCheck]
    [HttpGet("/Admin/Dashboard")]
    public IActionResult AdminDash() {
        if(level == 24) {
            HttpContext.Session.SetString("side", "Super Admin");
        } else {
            HttpContext.Session.SetString("side", "Admin");
        }
        
        return View("AdminDash", "Admin");
    }
// ! Viewing All users
    [AdminCheck]
    [SessionCheck]
    [HttpGet("/Admin/Users")]
    public IActionResult AllUsers() {
        List<User> allUsers = db.Users
        .ToList();
        return View("AllUsers", allUsers);
    }
// ! Making user super admin
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/{userId}/MakeSuper")]
    public IActionResult MakeSuper(int userId) {
        User? aUser = db.Users
        .FirstOrDefault(aUser => aUser.UserId == userId);
        aUser.Level = 24;
        aUser.UpdatedAt = DateTime.Now;
        db.Users.Update(aUser);
        db.SaveChanges();
        return Redirect("/Admin/Users");
    }
// ! Making user admin
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/{userId}/MakeAdmin")]
    public IActionResult MakeAdmin(int userId) {
        User? aUser = db.Users
        .FirstOrDefault(aUser => aUser.UserId == userId);
        aUser.Level = 22;
        aUser.UpdatedAt = DateTime.Now;
        db.Users.Update(aUser);
        db.SaveChanges();
        return Redirect("/Admin/Users");
    }
// ! Reseting user back to new user
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/{userId}/RemoveAdmin")]
    public IActionResult RemoveAdmin(int userId) {
        User? aUser = db.Users
        .FirstOrDefault(aUser => aUser.UserId == userId);
        aUser.Level = 1;
        aUser.UpdatedAt = DateTime.Now;
        db.Users.Update(aUser);
        db.SaveChanges();
        return Redirect("/Admin/Users");
    }
// ! Organization codes table
    [AdminCheck]
    [SessionCheck]
    [HttpGet("/Admin/OrgCodes")]
    public IActionResult OrgCodes() {
        List<OrgKey> allCodes = db.OrgKeys
        .ToList();
        return View("OrgCodes", allCodes);
    }
// ! Creating an org code
    [AdminCheck]
    [SessionCheck]
    [HttpPost("/Admin/CreateCode")]
    public IActionResult CreateCode(OrgKey r) {
        Random rand = new Random();
        r.OKey = "";
        string avail = "abcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int size = avail.Length;
        while(r.OKey.Length < 13) {
            r.OKey += avail[rand.Next(size)];
        }
        db.OrgKeys.Add(r);
        db.SaveChanges();
        return Redirect("/Admin/OrgCodes");
    }
// ! Password Key page
// ! Password key form
// ! remove User
// ! remove password key
// ! remove organization
}