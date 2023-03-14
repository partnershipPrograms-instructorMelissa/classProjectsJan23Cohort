#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DevsOnDeck.RegCode;
namespace DevsOnDeck.Models;

public class User {
    [Key]
    public int UserId {get; set;}
    [Required]
    public string FirstName {get; set;}
    [Required]
    public string LastName {get; set;}
    [Required]
    [EmailAddress]
    public string Email {get; set;}
    [Required]
    public string Username {get; set;}
    [Required]
    public string AccessType {get;set;} = "Developer";
    public int AccessLevel {get;set;} = 1;
    [Required]
    [DataType(DataType.Password)]
    public string Password {get; set;}
    [NotMapped]
    [Compare("Password", ErrorMessage="Dang it passwords don't match try your luck again")]
    public string Confirm {get; set;}

    // [NotMapped]
    // [Compare(RegCode.RegCode, ErrorMessage ="Wrong reg code")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // ******** One to one non id side
    public UserProfile? theProfile {get; set;}
    public Dev? myDev {get; set;}

    // ******* One to Many List side
    public List<Org> createdOrgs {get; set;} = new List<Org>();
    public List<OrgList> memberOf {get;set;} = new List<OrgList>();
    public List<RandKey> theKeys {get; set;} = new List<RandKey>();

    public string FullName() {
        return FirstName + " " + LastName;
    }
}