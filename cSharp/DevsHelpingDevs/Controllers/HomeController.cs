using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevsHelpingDevs.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DevsHelpingDevs.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext db; 

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
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

// ! Landing Page
    [HttpGet("")]
    public IActionResult Index() {
        if(uid != null) {
            return RedirectToAction("Dashboard");
        } else {
            return View("Index"); 
        }
    }
// ! Log/Reg Form
    [HttpGet("/LogReg")]
    public IActionResult LogReg () {
        if(uid != null) {
            return RedirectToAction("Dashboard");
        } else {
            HttpContext.Session.SetString("key", "Be3D#vS3rv1ce5");
            return View("LogReg");
        }
    }
// ! Reg - Post
    [HttpPost("/Reg")]
    public IActionResult Reg (User newUser) {
        if(ModelState.IsValid == false) {
            return View("LogReg");
        }
        if(ModelState.IsValid) {
            if(newUser.InviteCode != key) {
                ModelState.AddModelError("InviteCode", "WrongCode");
            }
            if(db.Users.Any(User => User.Email == newUser.Email)) {
                ModelState.AddModelError("Email", "Email is in system");
            }
            if(db.Users.Any(User => User.Username == newUser.Username)) {
                ModelState.AddModelError("Username", "Username is already taken");
            }
        }
        PasswordHasher<User> hash = new PasswordHasher<User>();
        newUser.Password = hash.HashPassword(newUser, newUser.Password);
        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.Clear();

        if(newUser.UserId == 1) {
            newUser.Level =24;
            db.Users.Update(newUser);
            db.SaveChanges();
        }
        HttpContext.Session.SetInt32("uid", newUser.UserId);
        HttpContext.Session.SetString("name", newUser.FullName());
        HttpContext.Session.SetInt32("level", newUser.Level);
        return RedirectToAction("AddProfile");
    }
// ! Add Profile - Load Button (try for pop up)
    [SessionCheck]
    [HttpGet("AddProfile")]
    public IActionResult AddProfile() {
        return View("AddProfile");
    }
// ! Create Profile - Post
    [SessionCheck]
    [HttpPost("CreateProfile")]
    public IActionResult CreateProfile(UserProfile up) {
        up.UserId = (int)uid;
        db.UserProfiles.Add(up);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }
// ! Login - Post
    [HttpPost("/Login")]
    public IActionResult Login (Login getUser) {
        if(!ModelState.IsValid) {
            return View("LogReg");
        } else {
            User? userInDb = db.Users.FirstOrDefault(u => u.Username == getUser.LoginUsername);
            if(userInDb == null) {
                ModelState.AddModelError("LoginUsername", "Invalid Username");
                return View("LogReg");
            } else {
                PasswordHasher<Login> hash = new PasswordHasher<Login>();
                var result = hash.VerifyHashedPassword(getUser, userInDb.Password, getUser.LoginPassword);
                if(result == 0)  { 
                    ModelState.AddModelError("LoginPassword", "Invalid Password");
                    return View("LogReg");
                } else {
                    userInDb.LastLogged = DateTime.Now;
                    db.Users.Update(userInDb);
                    db.SaveChanges();
                    HttpContext.Session.SetInt32("uid", userInDb.UserId);
                    HttpContext.Session.SetString("name", userInDb.FullName());
                    HttpContext.Session.SetInt32("level", userInDb.Level);
                    return RedirectToAction("Dashboard");
                }
            }
        }
    }

// ! Dashboard Router
    [SessionCheck]
    [HttpGet("/Dashboard")]
    public IActionResult Dashboard() {
        if(level > 20) {
            return Redirect("/Admin/Dashboard");
        }
        else if(level > 10) {
            return Redirect("/Org/Dashboard");
        }
        else {
            return Redirect("/Dev/Dashboard");
        }
    }

// ! Profile Page
    // [HttpGet("/Profile")]
    // public IActionResult Profile () {
    //     return View();
    // }
// ! Edit Profile Form
    // [HttpGet("/Profile/{UserId}/Edit")]
    // public IActionResult EditProfile () {
    //     return View();
    // }
// ! Update Profile - Post
    // [HttpPost("/Profile/{UserId}/Update")]
    // public IActionResult UpdateProfile () {
    //     return View();
    // }
// ! Edit Password Form
    // [HttpGet("/User/{KeyId}/Edit")]
    // public IActionResult EditPass () {
    //     return View();
    // }
// ! Update Password - Post
    // [HttpPost("/User/{KeyId}/Update")]
    // public IActionResult UpdatePass () {
    //     return View();
    // }

// ! logout
    [HttpGet("/Logout")]
    public IActionResult Logout () {
        HttpContext.Session.Clear();
        return View("Index");
    }
// ! logout
    [HttpGet("/Jobs")]
    public IActionResult Jobs () {
        return View("Jobs");
    }
// ! logout
    [HttpGet("/About")]
    public IActionResult About() {
        return View("About");
    }
// ! logout
    [HttpGet("/Contact")]
    public IActionResult Contact() {
        return View("Contact");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? uid = context.HttpContext.Session.GetInt32("uid");
        if(uid == null)
        {
            context.Result = new RedirectToActionResult("Index", "User", null);
        }
    }
}
public class AdminCheckAttribute : ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext context) {
        int? level = context.HttpContext.Session.GetInt32("level");
        if(level < 24) {
            Console.WriteLine("You are not authorized to view this page");
            context.Result = new RedirectToActionResult("NotAuth", "Home", 24);
            // !!!!! Can not have receiving page have view back on load
        }
    }
}