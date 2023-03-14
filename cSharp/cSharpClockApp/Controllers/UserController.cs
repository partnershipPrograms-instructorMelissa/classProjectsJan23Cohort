using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using cSharpClockApp.Models;

namespace cSharpClockApp.Controllers;

public class UserController : Controller
{

    private MyContext _context;

    public UserController( MyContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index(){
        if(HttpContext.Session.GetInt32("uid") != null){
            return RedirectToAction("Dashboard", "Home");
        }
        else{
            return View();
        }
    }

    [HttpPost("register")]
    public IActionResult Register(User newUser){
        if(ModelState.IsValid){
            PasswordHasher<User> hash = new PasswordHasher<User>(); // create new instance of the password hasher so that we can use it on the next line
            newUser.Password = hash.HashPassword(newUser, newUser.Password);
            // let newUser.Password = hashed version of the password
            _context.Users.Add(newUser);
            _context.SaveChanges();

            HttpContext.Session.SetInt32("uid", newUser.UserId);
            HttpContext.Session.SetString("Name", newUser.FullName());
            return RedirectToAction("Dashboard", "Home");
        }
        return View("Index");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser login){
        if(login.Password != null){
            // Console.WriteLine($"====YOU ARE NOW IN LOGIN====");
            if(login.LoginEmail != null){ // i want email to not be null
                // assign user to first or default email
                User? user = _context.Users.FirstOrDefault(u => u.Email == login.LoginEmail);

                if(user == null){
                    ModelState.AddModelError("LoginEmail", "Invalid Email");
                }
                else{
                    PasswordHasher<LoginUser> hash = new PasswordHasher<LoginUser>();
                    var result = hash.VerifyHashedPassword(login, user.Password, login.Password);
                    if(result == 0){// not a match
                        ModelState.AddModelError("LoginEmail", "Invalid Password");
                    }
                    else{
                        HttpContext.Session.SetInt32("uid", user.UserId);
                        HttpContext.Session.SetString("Name", user.FullName());
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
            }
            else if(login.LoginUsername != null){ // i want username to not be null
                // assign user to first or default username
                User? user = _context.Users.FirstOrDefault(u => u.Username == login.LoginUsername);

                if(user == null){
                    ModelState.AddModelError("LoginUsername", "Invalid Username");
                }
                else{
                    PasswordHasher<LoginUser> hash = new PasswordHasher<LoginUser>();
                    var result = hash.VerifyHashedPassword(login, user.Password, login.Password);
                    if(result == 0){// not a match
                        ModelState.AddModelError("LoginUsername", "Invalid Password");
                    }
                    else{
                        HttpContext.Session.SetInt32("uid", user.UserId);
                        HttpContext.Session.SetString("Name", user.FullName());
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
            }
            else { // both are null ?!?!
                // ModelState.ValidationResult("");
                ModelState.AddModelError("LoginUsername", "An Email or Username is required.");
                ModelState.AddModelError("LoginEmail", "An Email or Username is required.");
            }
        }
        return View("Index");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}