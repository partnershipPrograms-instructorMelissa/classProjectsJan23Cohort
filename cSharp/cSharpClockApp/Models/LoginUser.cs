#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cSharpClockApp.Models;

[NotMapped] // don't send to database
public class LoginUser{
    [EmailAddress]
    [Display(Name ="Email")]
    public string? LoginEmail {get; set;}

    [Display(Name = "Username")]
    public string? LoginUsername {get; set;}

    [Required]
    [DataType(DataType.Password)] // auto fills input type attr
    [Display(Name = "Password")]
    public string Password { get; set; }
}