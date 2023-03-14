#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace cSharpClockApp.Models;

public class User {
    [Key]
    public int UserId {get; set;}
    // add more attributes here
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    [UniqueEmail]
    public string Email {get; set;}
    [Required]
    [UniqueUsername]
    public string Username {get; set;}
    [Required]
    public string Password {get; set;}
    [NotMapped]
    [Compare("Password", ErrorMessage="Dang it passwords don't match try your luck again")]
    public string Confirm {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    // ***** Many to Many List Side
    public List<UserSkills> mySkills = new List<UserSkills>();

    // ***** One to Many List side
    public List<Image> allImages = new List<Image>();

    public string FullName() {
        return FirstName + " " + LastName;
    }
}
public class UniqueEmailAttribute : ValidationAttribute {
    protected override ValidationResult? IsValid(object? value, ValidationContext valContext) {
        if(value == null) {
            return new ValidationResult("Email is required");
        }
        MyContext _context = (MyContext)valContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Email == value.ToString())) {
            return new ValidationResult("Email is in use");
        } else {
            return ValidationResult.Success;
        }
    }
}
public class UniqueUsernameAttribute : ValidationAttribute {
    protected override ValidationResult? IsValid(object? value, ValidationContext valContext) {
        if(value == null) { // if username input is empty
            return new ValidationResult("Username is required");
        }
        MyContext _context = (MyContext)valContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Username == value.ToString())) {
            return new ValidationResult("Username is in use"); // if email is in database
        } else {
            return ValidationResult.Success; // email not in database good to go
        }
    }
}